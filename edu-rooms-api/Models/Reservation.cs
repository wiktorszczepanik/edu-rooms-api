namespace edu_rooms_api.Models;

public class Reservation {

    private static int _idCounter;
    public int Id { get; }
    private int _roomId;
    public int RoomId {
        get => _roomId;
        set {
            if (value <= 0)
                throw new ArgumentException("Room id must be greater then 0", nameof(value));
            _roomId = value;
        }
    }
    private string _organizerName = string.Empty;
    public string OrganizerName {
        get => _organizerName;
        set {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Organizer name cannot be null or empty", nameof(value));
            _organizerName = value;
        }
    }

    private string _topic = string.Empty;
    public string Topic {
        get => _topic;
        set => _topic = value ?? throw new ArgumentNullException(nameof(value));
    }
    public DateTime Date { get; }
    private DateTime _startTime;
    public DateTime StartTime {
        get => _startTime;
        set {
            if (value < Date)
                throw new ArgumentException("Start date cannot be older then reservation date", nameof(value));
            _startTime = value;
        }
    }
    private DateTime _endTime;
    public DateTime EndTime {
        get => _endTime;
        set {
            if (value < Date || value < EndTime)
                throw new ArgumentException("End date cannot be earlier then Start date", nameof(value));
            _endTime = value;
        }
    }
    public Status Status { get; set; }

    public Reservation(int roomId, string organizerName, string topic, DateTime startTime, DateTime endTime) {
        Id = ++_idCounter;
        RoomId = roomId;
        OrganizerName = organizerName;
        Topic = topic;
        Date = DateTime.Now;
        StartTime = startTime;
        EndTime = endTime;
        Status = Status.Planned;
    }
    
}