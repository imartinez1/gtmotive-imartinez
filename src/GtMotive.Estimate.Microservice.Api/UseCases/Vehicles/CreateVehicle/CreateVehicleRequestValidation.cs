using System;
using FluentValidation;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.CreateVehicle
{
    public class CreateVehicleRequestValidation : AbstractValidator<CreateVehicleRequest>
    {
        public CreateVehicleRequestValidation()
        {
            RuleFor(item => item.RegistrationNumber)
                .MaximumLength(7)
                .NotEmpty().WithMessage("The registration number is required.");

            RuleFor(item => item.Year)
                .NotNull().WithMessage("The manufacturing year is required.")
                .GreaterThanOrEqualTo(DateTime.UtcNow.Year - 5)
                .WithMessage($"The vehicle cannot be older than 5 years. It must be from {DateTime.UtcNow.Year - 5} or newer.");
        }
    }
}
