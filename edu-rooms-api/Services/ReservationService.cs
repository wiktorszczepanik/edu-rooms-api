using System.ComponentModel.DataAnnotations;
using edu_rooms_api.Models;

namespace edu_rooms_api.Services;

public class ReservationService {

    private IList<Reservation> _reservations;
    private IList<Room> _rooms;

    public ReservationService(IList<Reservation> reservations, IList<Room> rooms) {
        _reservations = reservations;
        _rooms = rooms;
    }

    public IList<Reservation> GetReservations(DateTime? date, Status? status, int? roomId) {
        var query = _reservations.AsQueryable();
        if (date.HasValue) {
            var dayStart = date.Value.Date;
            var dayEnd = date.Value.Date.AddDays(1).AddTicks(-1);
            query = query.Where(reservation =>
                reservation.StartTime.Value < dayEnd 
                && reservation.EndTime.Value > dayStart
            );
        }
        if (status.HasValue) {
            query = query.Where(reservation => reservation.Status == status);
        }
        if (roomId.HasValue) {
            query = query.Where(reservation => reservation.RoomId.Value == roomId);
        }
        return query.ToList();
    }

    public Reservation? GetReservationById(int id) {
        var query = _reservations.AsQueryable();
        var reservation = query.FirstOrDefault(reservation => reservation.Id == id);
        return reservation;
    }

    public Reservation? CreateReservation(int roomId, string organizerName, string topic, DateTime start,
        DateTime end) {
        var room = _rooms.FirstOrDefault(room => room.Id == roomId);
        if (room == null) return null;
        if (!room.IsActive) return null;
        var roomReservationsFromTimeRange = _reservations.AsQueryable();
        var overlapping = roomReservationsFromTimeRange
            .Any(reservation =>
                reservation.RoomId.Value == roomId
                && (start >= reservation.StartTime.Value && start <= reservation.EndTime.Value)
                && (end >= reservation.StartTime.Value && start <= reservation.EndTime.Value)
            );
        if (overlapping) {
            throw new ValidationException();
        }
        return Reservation.Create(roomId, organizerName, topic, start, end);
    }

    public Reservation? UpdateReservation(int id, string organizerName, string topic) {
        var reservation = GetReservationById(id);
        if (reservation == null) return null;
        reservation.UpdateFields(organizerName, topic);
        return reservation;
    }

    public bool DeleteReservation(int id) {
        var reservation = GetReservationById(id);
        if (reservation == null) return false;
        _reservations.Remove(reservation);
        return true;
    }
}