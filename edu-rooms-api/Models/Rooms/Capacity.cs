namespace edu_rooms_api.Models;

public class Capacity {
    
    public int Value { get; private set; }

    public Capacity(int capacity) {
        if (capacity < 1)
            throw new ArgumentException("Minimum allowed capacity is 1", nameof(capacity));
        Value = capacity;
    }
}