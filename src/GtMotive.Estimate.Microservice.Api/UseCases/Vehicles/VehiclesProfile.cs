using AutoMapper;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.CreateVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Commands.CreateVehicle;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles
{
    public class VehiclesProfile : Profile
    {
        public VehiclesProfile()
        {
            ApiToApplication();
        }

        private void ApiToApplication()
        {
            CreateMap<CreateVehicleRequest, CreateVehicleCommand>();
        }
    }
}
