using FluentValidation;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Rentals.CreateRental
{
    public class CreateRentalRequestValidation : AbstractValidator<CreateRentalRequest>
    {
        public CreateRentalRequestValidation()
        {
            RuleFor(item => item.DateFrom).NotNull().NotEmpty().WithMessage("The Date from id is required.");
            RuleFor(item => item.DateTo).NotNull().NotEmpty().WithMessage("The Date to is required.");
            RuleFor(item => item.VehicleId).NotNull().NotEmpty().WithMessage("The Vehicle id is required.");
        }
    }
}
