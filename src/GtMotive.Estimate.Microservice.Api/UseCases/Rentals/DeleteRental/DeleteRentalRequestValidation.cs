using FluentValidation;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Rentals.DeleteRental
{
    public class DeleteRentalRequestValidation : AbstractValidator<DeleteRentalRequest>
    {
        public DeleteRentalRequestValidation()
        {
            RuleFor(item => item.Id).NotNull().NotEmpty().WithMessage("The id is required.");
        }
    }
}
