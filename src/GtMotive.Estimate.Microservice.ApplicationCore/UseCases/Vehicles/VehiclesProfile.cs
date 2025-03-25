using AutoMapper;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Commands.CreateVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Queries.GetVehicles;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles
{
    /// <summary>
    /// VehiclesProfile.
    /// </summary>
    public class VehiclesProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VehiclesProfile"/> class.
        /// </summary>
        public VehiclesProfile()
        {
            DomainToApplication();
        }

        private void DomainToApplication()
        {
            CreateMap<Vehicle, GetVehiclesResponse>();
            CreateMap<Vehicle, CreateVehicleResponse>()
                .ForMember(dest => dest.Success, opt => opt.MapFrom(src => true));
        }
    }
}
