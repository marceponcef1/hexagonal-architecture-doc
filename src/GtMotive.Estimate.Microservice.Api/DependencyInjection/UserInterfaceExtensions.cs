using GtMotive.Estimate.Microservice.Api.UseCases.CreateRental;
using GtMotive.Estimate.Microservice.Api.UseCases.CreateVehicle;
using GtMotive.Estimate.Microservice.Api.UseCases.ListAvailableVehicles;
using GtMotive.Estimate.Microservice.Api.UseCases.ReturnVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateRental;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ListAvailableVehicles;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Factories;
using GtMotive.Estimate.Microservice.Domain.Specifications;
using Microsoft.Extensions.DependencyInjection;

namespace GtMotive.Estimate.Microservice.Api.DependencyInjection
{
    public static class UserInterfaceExtensions
    {
        public static IServiceCollection AddPresenters(this IServiceCollection services)
        {
            services.AddScoped<CreateRentalPresenter>();
            services.AddScoped<ICreateRentalOutputPort>(x => x.GetRequiredService<CreateRentalPresenter>());
            services.AddScoped<ICreateRentalPresenter>(x => x.GetRequiredService<CreateRentalPresenter>());
            services.AddScoped<IRentalFactory, RentalFactory>();
            services.AddScoped<ISpecification<Customer>, CustomerCanRentSpecification>();

            services.AddScoped<CreateVehiclePresenter>();
            services.AddScoped<ICreateVehicleOutputPort>(x => x.GetRequiredService<CreateVehiclePresenter>());
            services.AddScoped<ICreateVehiclePresenter>(x => x.GetRequiredService<CreateVehiclePresenter>());

            services.AddScoped<ListAvailableVehiclesPresenter>();
            services.AddScoped<IListAvailableVehiclesOutputPort>(x => x.GetRequiredService<ListAvailableVehiclesPresenter>());
            services.AddScoped<IListAvailableVehiclesPresenter>(x => x.GetRequiredService<ListAvailableVehiclesPresenter>());

            services.AddScoped<ReturnVehiclePresenter>();
            services.AddScoped<IReturnVehicleOutputPort>(x => x.GetRequiredService<ReturnVehiclePresenter>());
            services.AddScoped<IReturnVehiclePresenter>(x => x.GetRequiredService<ReturnVehiclePresenter>());

            return services;
        }
    }
}
