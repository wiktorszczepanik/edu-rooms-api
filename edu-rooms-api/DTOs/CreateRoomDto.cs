using System.ComponentModel.DataAnnotations;

namespace edu_rooms_api.DTOs;

public class CreateRoomDto {
    
    [Required]
    [StringLength(100, MinimumLength = 1)]
    public required string Name { get; set; }
    [Required]
    public char BuildingCode { get; set; }
    [Required]
    public int floor { get; set; }
    [Required]
    [Range(1, 500)]
    public int Capacity { get; set; }
    public bool HasProjector { get; set; } = false;

}