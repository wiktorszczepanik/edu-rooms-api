using System.ComponentModel.DataAnnotations;

namespace edu_rooms_api.DTOs;

public class ReadRoomDto {
    
    [Required]
    [Range(1, int.MaxValue)]
    public int Id { get; set; }
    [Required] 
    [StringLength(100, MinimumLength = 1)]
    public required string Name { get; set; }
    [Required]
    public char BuildingCode { get; set; }
    [Range(1, 500)]
    public int Capacity { get; set; }
    public bool HasProjector { get; set; }
    public bool IsActive { get; set; }
    
}