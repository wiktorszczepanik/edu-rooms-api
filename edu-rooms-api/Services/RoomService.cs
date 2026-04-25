using edu_rooms_api.Models;

namespace edu_rooms_api.Services;

public class RoomService {

    private IList<Room> _rooms;

    public RoomService(IList<Room> rooms) {
        _rooms = rooms;
    }

    public IList<Room> GetRooms(int? minCapacity, bool? hasProjector, bool? activeOnly) {
        var query = _rooms.AsQueryable();
        if (minCapacity.HasValue) {
            query = query.Where(room => room.Capacity.Value >= minCapacity);
        }
        if (hasProjector.HasValue) {
            query = query.Where(room => room.HasProjector == hasProjector.Value);
        }
        if (activeOnly.HasValue) {
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
            .Where(room => room.BuildingCode == code)
            .ToList();
        return query.ToList();
    }
}