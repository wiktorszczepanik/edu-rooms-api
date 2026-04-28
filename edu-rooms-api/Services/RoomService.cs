using edu_rooms_api.Models;

namespace edu_rooms_api.Services;

public class RoomService {

    private IList<Room> _rooms;
    private IList<Reservation> _reservations;

    public RoomService(IList<Room> rooms, IList<Reservation> reservations) {
        _rooms = rooms;
        _reservations = reservations;
    }

    public IList<Room> GetRooms(int? minCapacity, bool? hasProjector, bool? activeOnly) {
        var query = _rooms.AsQueryable();
        if (minCapacity.HasValue) {
            query = query.Where(room => room.Capacity.Value >= minCapacity);
        }
        if (hasProjector.HasValue) {
            query = query.Where(room => room.HasProjector == hasProjector.Value);
        }
        if (activeOnly.HasValue && (bool) activeOnly) {
            query = query.Where(room => room.IsActive == activeOnly.Value);
        }
        return query.ToList();
    }

    public Room? GetRoomById(int id) {
        var query = _rooms.AsQueryable();
        var room = query.FirstOrDefault(room => room.Id == id);
        return room;
    }

    public IList<Room>? GetRoomsByBuildingCode(char buildingCode) {
        BuildingCode code;
        try {
            code = new BuildingCode(buildingCode);
        } catch (Exception) {
            return null;
        }
        var query = _rooms
            .Where(room => room.BuildingCode.Value == code.Value);
        return query.ToList();
    }

    public Room? CreateRoom(string name, char buildingCode, int floor, int capacity, bool hasProjector) {
        Room room;
        try {
            room = Room.Create(name, buildingCode, floor, capacity, hasProjector);
            _rooms.Add(room);
        } catch (Exception) {
            return null;
        }
        return room;
    }

    public Room? UpdateRoom(int id, string name, char buildingCode, int floor, int capacity, bool hasProjector, bool isActive) {
        var room = GetRoomById(id);
        if (room == null) return null;
        room.UpdateFields(name, buildingCode, floor, capacity, hasProjector, isActive);
        return room;
    }

    public bool? DeleteRoom(int id) {
        var room = GetRoomById(id);
        if (room == null) return null;
        var overlapping = _reservations
            .Where(reservation => reservation.StartTime.Value >= DateTime.Now)
            .Any(reservation => reservation.RoomId.Value == room.Id);
        if (overlapping) return false;
        _rooms.Remove(room);
        return true;
    }
}
