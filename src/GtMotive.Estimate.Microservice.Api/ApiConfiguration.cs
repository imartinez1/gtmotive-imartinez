using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using GtMotive.Estimate.Microservice.Api.Authorization;
using GtMotive.Estimate.Microservice.Api.DependencyInjection;
using GtMotive.Estimate.Microservice.Api.Filters;
using GtMotive.Estimate.Microservice.ApplicationCore;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Commands.CreateVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Queries.GetVehicles;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

[assembly: CLSCompliant(false)]

namespace GtMotive.Estimate.Microservice.Api
{
    [ExcludeFromCodeCoverage]
    public static class ApiConfiguration
    {
        public static void ConfigureControllers(MvcOptions options)
        {
            ArgumentNullException.ThrowIfNull(options);

            options.Filters.Add<BusinessExceptionFilter>();
        }

        public static IMvcBuilder WithApiControllers(this IMvcBuilder builder)
        {
            ArgumentNullException.ThrowIfNull(builder);

            builder.AddApplicationPart(typeof(ApiConfiguration).GetTypeInfo().Assembly);

            AddApiDependencies(builder.Services);

            return builder;
        }

        public static void AddApiDependencies(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            AddCustomApplicationAutoMapper(services);

            services.AddAuthorization(AuthorizationOptionsExtensions.Configure);
            services.AddMediatR(typeof(ApiConfiguration).GetTypeInfo().Assembly);
            services.AddUseCases();
            services.AddPresenters();
            services.AddMediatR(typeof(GetVehiclesQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(CreateVehicleCommand).GetTypeInfo().Assembly);
            services.AddIdentity<User, Role>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            services.AddAuthorization(AuthorizationOptionsExtensions.Configure);
        }

        public static void AddCustomApplicationAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(VehiclesProfile).Assembly);
        }
    }
}
