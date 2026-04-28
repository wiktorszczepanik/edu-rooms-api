namespace edu_rooms_api.Models;

public class StartTime {
    
    public DateTime Value { get; private set; }

    public StartTime(DateTime reservationDate, DateTime startTime) {
        if (startTime < reservationDate)
            throw new ArgumentException("Start date cannot be older then reservation date", nameof(startTime));
        Value = startTime;
    }
    
}