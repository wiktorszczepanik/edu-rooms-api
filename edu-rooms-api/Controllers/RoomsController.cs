using edu_rooms_api.DTOs;
using edu_rooms_api.Storage;
using Microsoft.AspNetCore.Mvc;

namespace edu_rooms_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomsController : ControllerBase {

    [HttpGet]
    public IActionResult Get([FromQuery] int? minCapacity, [FromQuery] bool? hasProjector, [FromQuery] bool? activeOnly) {
        var query = Data.Rooms.AsQueryable();
        if (minCapacity.HasValue) {
            query = query.Where(room => room.Capacity >= minCapacity);
        }
        if (hasProjector.HasValue) {
            query = query.Where(room => room.HasProjector == hasProjector.Value);
        }
        if (activeOnly.HasValue) {
            query = query.Where(room => room.IsActive == activeOnly.Value);
        }
        var result = query.Select(room => new RoomDto {
            Id = room.Id,
            Name = room.Name,
            Capacity = room.Capacity,
            HasProjector = room.HasProjector,
            IsActive = room.IsActive
        });
        return Ok(result.ToList());
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult GetById([FromRoute] int id) {
        var query = Data.Rooms.AsQueryable();
        var room = query.FirstOrDefault(room => room.Id == id);
        if (room == null) {
            return NotFound();
        }
        var result = new RoomDto {
            Id = room.Id,
            Name = room.Name,
            Capacity = room.Capacity,
            HasProjector = room.HasProjector,
            IsActive = room.IsActive
        };
        return Ok(result);
    }

    [HttpGet]
    [Route("/building/{buildingCode}")]
    public IActionResult GetByBuildingCode([FromRoute] char buildingCode) {
        if (!char.IsAsciiLetter(buildingCode)) {
            return BadRequest("Code as an one letter ascii");
        }
        var code = char.ToUpper(buildingCode);
        var query = Data.Rooms
            .Where(room => room.BuildingCode == code)
            .ToList();
        if (query.Count == 0) {
            return NoContent();
        }
        var result = query.Select(room => new RoomDto {
            Id = room.Id,
            Name = room.Name,
            Capacity = room.Capacity,
            HasProjector = room.HasProjector,
            IsActive = room.IsActive
        });
        return Ok(result.ToList());
    }
    
}