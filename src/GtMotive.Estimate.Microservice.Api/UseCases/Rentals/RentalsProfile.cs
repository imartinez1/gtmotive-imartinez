using AutoMapper;
using GtMotive.Estimate.Microservice.Api.UseCases.Rentals.CreateRental;
using GtMotive.Estimate.Microservice.Api.UseCases.Rentals.DeleteRental;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals.Commands.CreateRental;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals.Commands.DeleteRental;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Rentals
{
    public class RentalsProfile : Profile
    {
        public RentalsProfile()
        {
            ApiToApplication();
        }

        private void ApiToApplication()
        {
            CreateMap<CreateRentalRequest, CreateRentalCommand>();
            CreateMap<DeleteRentalRequest, DeleteRentalCommand>();
        }
    }
}
