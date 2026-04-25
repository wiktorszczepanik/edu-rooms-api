namespace edu_rooms_api.Models;

public class EndTime {
    
    public DateTime Value { get; private set; }

    public EndTime(DateTime reservationDate, DateTime startTime, DateTime endTime) {
        if (endTime < startTime || endTime < reservationDate)
            throw new ArgumentException("End date cannot be earlier then Start date", nameof(endTime));
        Value = endTime;
    }
}