using FluentValidation;

namespace edu_rooms_api.DTOs;

public class CreateReservationDtoValidator : AbstractValidator<CreateReservationDto> {

    public CreateReservationDtoValidator() {
        RuleFor(reservation => reservation.StartTime)
            .GreaterThanOrEqualTo(DateTime.Now);
        RuleFor(reservation => reservation.EndTime)
            .GreaterThan(reservation => reservation.StartTime);
    }
}