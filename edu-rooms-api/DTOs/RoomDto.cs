namespace edu_rooms_api.DTOs;

public class RoomDto {
    
    public int Id { get; set; }
    public required string Name { get; set; }
    public int Capacity { get; set; }
    public bool HasProjector { get; set; }
    public bool IsActive { get; set; }
    
}