using System.ComponentModel.DataAnnotations;

namespace edu_rooms_api.DTOs;

public class UpdateReservationDto {
    
    [StringLength(100, MinimumLength = 1)]
    public required string OrganizerName { get; set; }
    [StringLength(100, MinimumLength = 1)]
    public required string Topic { get; set; }
    
}