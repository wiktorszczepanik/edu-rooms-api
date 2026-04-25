using edu_rooms_api.DTOs;
using edu_rooms_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace edu_rooms_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomsController : ControllerBase {

    private RoomService _roomService;

    public RoomsController(RoomService roomService) {
        _roomService = roomService;
    }

    [HttpGet]
    public IActionResult Get([FromQuery] int? minCapacity, [FromQuery] bool? hasProjector, [FromQuery] bool? activeOnly) {
        var rooms = _roomService.GetRooms(minCapacity, hasProjector, activeOnly);
        var result = rooms.Select(room => new RoomResponseDto {
            Id = room.Id,
            Name = room.Name.Value,
            BuildingCode = room.BuildingCode.Value,
            Capacity = room.Capacity.Value,
            HasProjector = room.HasProjector,
            IsActive = room.IsActive
        });
        return Ok(result.ToList());
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult GetById([FromRoute] int id) {
        var room = _roomService.GetRoomById(id);
        if (room == null) return NotFound();
        var result = new RoomResponseDto {
            Id = room.Id,
            Name = room.Name.Value,
            BuildingCode = room.BuildingCode.Value,
            Capacity = room.Capacity.Value,
            HasProjector = room.HasProjector,
            IsActive = room.IsActive
        };
        return Ok(result);
    }

    [HttpGet]
    [Route("/building/{buildingCode}")]
    public IActionResult GetByBuildingCode([FromRoute] char buildingCode) {
        var rooms = _roomService.GetRoomsByBuildingCode(buildingCode);
        if (rooms == null) {
            return BadRequest("Invalid building code format");
        }
        if (rooms.Count == 0) {
            return NoContent();
        }
        var result = rooms.Select(room => new RoomResponseDto {
            Id = room.Id,
            Name = room.Name.Value,
            BuildingCode = room.BuildingCode.Value,
            Capacity = room.Capacity.Value,
            HasProjector = room.HasProjector,
            IsActive = room.IsActive
        });
        return Ok(result.ToList());
    }
    
}