namespace edu_rooms_api.Models;

public class Reservation {

    private static int _idCounter;
    public int Id { get; }
    public RoomId RoomId { get; private set; }
    public OrganizerName OrganizerName { get; private set; }
    public Topic Topic { get; private set; }
    public DateTime ReservationTime { get; private set; }
    public StartTime StartTime { get; private set; }
    public EndTime EndTime { get; private set; }
    public Status Status { get; set; }

    private Reservation(RoomId roomId, OrganizerName organizerName, Topic topic, DateTime reservationReservationTime, StartTime startTime, EndTime endTime) {
        Id = ++_idCounter;
        RoomId = roomId;
        OrganizerName = organizerName;
        Topic = topic;
        ReservationTime = reservationReservationTime;
        StartTime = startTime;
        EndTime = endTime;
        Status = Status.Confirmed;
    }

    public static Reservation Create(int roomId, string organizerName, string topic, DateTime startTime, DateTime endTime) {
        var reservationDate = DateTime.Now;
        return new Reservation(
            new RoomId(roomId),
            new OrganizerName(organizerName),
            new Topic(topic),
            reservationDate,
            new StartTime(reservationDate, startTime),
            new EndTime(reservationDate, startTime, endTime)
        );
    }

    public void UpdateFields(string organizerName, string topic) {
        OrganizerName = new OrganizerName(organizerName);
        Topic = new Topic(topic);
    }
}