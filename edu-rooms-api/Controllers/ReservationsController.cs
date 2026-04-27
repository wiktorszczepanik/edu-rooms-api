using edu_rooms_api.DTOs;
using edu_rooms_api.Models;
using edu_rooms_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace edu_rooms_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservationsController : ControllerBase {
    
    private ReservationService _reservationService;

    public ReservationsController(ReservationService roomService) {
        _reservationService = roomService;
    }

    [HttpGet]
    public IActionResult Get([FromQuery] DateTime? date, [FromQuery] Status? status, [FromQuery] RoomId? roomId) {
        var reservations = _reservationService.GetReservations(date, status, roomId);
        var results = reservations.Select(reservation => new ReadReservationDto {
            Id = reservation.Id,
            RoomId = reservation.RoomId.Value,
            OrganizerName = reservation.OrganizerName.Value,
            Topic = reservation.Topic.Value,
            StartTime = reservation.StartTime.Value,
            EndTime = reservation.EndTime.Value,
        });
        return Ok(results.ToList());
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult GetById([FromRoute] int id) {
        var reservation = _reservationService.GetReservationById(id);
        if (reservation == null) return NotFound();
        var result = new ReadReservationDto {
            Id = reservation.Id,
            RoomId = reservation.RoomId.Value,
            OrganizerName = reservation.OrganizerName.Value,
            Topic = reservation.Topic.Value,
            StartTime = reservation.StartTime.Value,
            EndTime = reservation.EndTime.Value
        };
        return Ok(result);
    }

    [HttpPost]
    public IActionResult Post(CreateReservationDto createDto) {
        if (!ModelState.IsValid) {
            return BadRequest(ModelState);
        }
        Reservation? reservation;
        try {
            reservation = _reservationService.CreateReservation(
                createDto.RoomId,
                createDto.OrganizerName,
                createDto.Topic,
                createDto.StartTime,
                createDto.EndTime
            );
        } catch (Exception) {
            return Conflict();
        }
        if (reservation == null) return NotFound();
        var result = new ReadReservationDto {
            Id = reservation.Id,
            RoomId = reservation.RoomId.Value,
            OrganizerName = reservation.OrganizerName.Value,
            Topic = reservation.Topic.Value,
            StartTime = reservation.StartTime.Value,
            EndTime = reservation.EndTime.Value
        };
        return Ok(result);
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult Put(int id, UpdateReservationDto updateDto) {
        if (!ModelState.IsValid) {
            return BadRequest(ModelState);
        }
        var reservation = _reservationService.UpdateReservation(id, updateDto.OrganizerName, updateDto.Topic);
        if (reservation == null) return NotFound();
        var result = new ReadReservationDto {
            Id = reservation.Id,
            RoomId = reservation.RoomId.Value,
            OrganizerName = reservation.OrganizerName.Value,
            Topic = reservation.Topic.Value,
            StartTime = reservation.StartTime.Value,
            EndTime = reservation.EndTime.Value
        };
        return Ok(result);
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult Delete(int id) {
        var reservation = _reservationService.DeleteReservation(id);
        if (reservation) return NotFound();
        return NoContent();
    }
}