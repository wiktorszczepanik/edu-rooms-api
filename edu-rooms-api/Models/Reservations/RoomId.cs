namespace edu_rooms_api.Models;

public class RoomId {
    
    public int Value { get; private set; }

    public RoomId(int roomId) {
        if (roomId <= 0)
            throw new ArgumentException("Room id must be greater then 0", nameof(roomId));
        Value = roomId;
    }
    
}