using System.ComponentModel.DataAnnotations;

namespace edu_rooms_api.DTOs;

public class UpdateRoomDto {
    
    [StringLength(100, MinimumLength = 1)]
    public required string Name { get; set; }
    public char BuildingCode { get; set; }
    public int Floor { get; set; }
    [Range(1, 500)]
    public int Capacity { get; set; }
    public bool HasProjector { get; set; }
    public bool IsActive { get; set; }
    
}