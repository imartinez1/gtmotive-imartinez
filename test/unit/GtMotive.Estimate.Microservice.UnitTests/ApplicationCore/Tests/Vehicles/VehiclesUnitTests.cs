using AutoMapper;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Commands.CreateVehicle;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Repository;
using Microsoft.Extensions.Logging;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace GtMotive.Estimate.Microservice.UnitTests.ApplicationCore.Tests.Vehicles
{
    /// <summary>
    /// VehiclesUnitTests.
    /// </summary>
    public class VehiclesUnitTests
    {
        /// <summary>
        /// HandleShouldCreateVehicleWhenValidCommand.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task HandleShouldCreateVehicleWhenValidCommand()
        {
            var mockVehicleRepository = new Mock<IBaseRepository<Vehicle>>();
            var mockMapper = new Mock<IMapper>();
            var mockLogger = new Mock<ILogger<CreateVehicleCommandHandler>>();

            var command = new CreateVehicleCommand
            {
                Model = "Corolla",
                Brand = "Toyota",
                Year = 2024,
                RegistrationNumber = "1111RRR"
            };

            var vehicle = new Vehicle
            {
                Model = "Corolla",
                Brand = "Toyota",
                Year = 2024,
                RegistrationNumber = "1111RRR"
            };

            var response = new CreateVehicleResponse
            {
                Success = true,
                ErrorMessage = null
            };

            mockVehicleRepository
                .Setup(repo => repo.Create(It.IsAny<Vehicle>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(vehicle);

            mockMapper
                .Setup(mapper => mapper.Map<CreateVehicleResponse>(It.IsAny<Vehicle>()))
                .Returns(response);

            var handler = new CreateVehicleCommandHandler(
                mockVehicleRepository.Object,
                mockMapper.Object,
                mockLogger.Object);

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.Null(result.ErrorMessage);

            mockVehicleRepository.Verify(repo => repo.Create(It.Is<Vehicle>(v => v.RegistrationNumber == "1111RRR"), It.IsAny<CancellationToken>()), Times.Once);
            mockMapper.Verify(mapper => mapper.Map<CreateVehicleResponse>(It.IsAny<Vehicle>()), Times.Once);
        }
    }
}
