using AutoMapper;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals.Commands.CreateRental;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals.Commands.DeleteRental;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals
{
    /// <summary>
    /// VehiclesProfile.
    /// </summary>
    public class RentalsProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RentalsProfile"/> class.
        /// </summary>
        public RentalsProfile()
        {
            DomainToApplication();
        }

        private void DomainToApplication()
        {
            CreateMap<Rental, CreateRentalResponse>()
                .ForMember(dest => dest.Success, opt => opt.MapFrom(src => true));

            CreateMap<Rental, DeleteRentalResponse>()
                .ForMember(dest => dest.Success, opt => opt.MapFrom(src => true));
        }
    }
}
