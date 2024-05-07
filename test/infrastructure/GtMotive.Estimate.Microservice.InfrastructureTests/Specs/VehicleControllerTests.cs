using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases.ListAvailableVehicles;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Repositories;
using GtMotive.Estimate.Microservice.InfrastructureTests.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;
using Xunit;

namespace GtMotive.Estimate.Microservice.InfrastructureTests.Specs
{
    public class VehicleControllerTests : InfrastructureTestBase
    {
        private readonly HttpClient _client;

        public VehicleControllerTests()
        {
            _client = Server.CreateClient();
        }

        [Fact]
        public async Task ListAvailableVehiclesReturnsSuccessStatusCode()
        {
            // Arrange
            var fleetId = Guid.Parse("00000000-0000-0000-0000-000000000001");

            // Act
            // Send a GET request to the ListAvailableVehicles endpoint
            var uri = new Uri(Server.BaseAddress, $"/api/Vehicle/ListAvailableVehicles/{fleetId}");
            var response = await _client.GetAsync(uri);

            // Assert
            // Check that the response has a successful status code and content
            var responseData = await response.Content.ReadFromJsonAsync<ListAvailableVehiclesResponse>();
            Assert.True(response.IsSuccessStatusCode);
            Assert.NotEmpty(responseData.Vehicles);
            Assert.NotNull(response);
        }

        protected override void ConfigureTestServices(IServiceCollection services)
        {
            var vehicleRepositoryMock = new Mock<IVehicleRepository>();

            var brand = "Brand-Test";
            var vehiclemodel = "Model-Test";
            var color = "Color-Test";
            var vin = "VIN-Test";
            var manufactureDate = DateOnly.FromDateTime(DateTime.Now.AddYears(-2));
            var fleetId = new Guid("00000000-0000-0000-0000-000000000001");
            var vehicle = new Vehicle(brand, vehiclemodel, color, manufactureDate, vin, fleetId);

            vehicleRepositoryMock.Setup(repo => repo.AddAsync(vehicle)).Returns(Task.CompletedTask);
            vehicleRepositoryMock.Setup(repo => repo.GetAvailableVehicleAsync(vehicle.Id)).ReturnsAsync(vehicle);

            services.Replace(new ServiceDescriptor(typeof(IVehicleRepository), vehicleRepositoryMock.Object));
        }
    }
}
