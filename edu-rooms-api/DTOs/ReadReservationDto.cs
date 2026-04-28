using System.ComponentModel.DataAnnotations;

namespace edu_rooms_api.DTOs;

public class ReadReservationDto {
    
    [Required]
    public int Id { get; set; }
    [Required]
    public int RoomId { get; set; }
    [Required]
    [StringLength(100, MinimumLength = 1)]
    public required string OrganizerName { get; set; }
    [Required]
    [StringLength(100, MinimumLength = 1)]
    public required string Topic { get; set; }
    [Required]
    public DateTime ReservationTime { get; set; }
    [Required]
    public DateTime StartTime { get; set; }
    [Required]
    public DateTime EndTime { get; set; }
    
}