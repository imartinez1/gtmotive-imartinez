using MediatR;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Commands.CreateVehicle
{
    /// <summary>
    /// CreateVehicleCommand.
    /// </summary>
    public class CreateVehicleCommand : IRequest<CreateVehicleResponse>
    {
        /// <summary>
        /// Gets or sets RegistrationNumber.
        /// </summary>
        public string RegistrationNumber { get; set; }

        /// <summary>
        /// Gets or sets Year.
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Gets or sets Brand.
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Gets or sets Model.
        /// </summary>
        public string Model { get; set; }
    }
}
