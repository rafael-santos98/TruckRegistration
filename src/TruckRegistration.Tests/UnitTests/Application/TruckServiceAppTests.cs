using AutoMapper;
using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TruckRegistration.Application.Models.Response;
using TruckRegistration.Application.Services;
using TruckRegistration.Domain.Contracts.Commands;
using TruckRegistration.Domain.Contracts.Repositories;
using TruckRegistration.Domain.Entities;
using TruckRegistration.Tests.Entities;
using Xunit;

namespace TruckRegistration.Tests.UnitTests.Application
{
    public class TruckServiceAppTests
    {
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<ITruckCommandHandler> _truckCommandHandlerMock;
        private readonly Mock<ITruckRepository> _truckRepositoryMock;
        private readonly TruckAppService _truckAppService;

        public TruckServiceAppTests()
        {
            _mapperMock = new Mock<IMapper>();
            _truckCommandHandlerMock = new Mock<ITruckCommandHandler>();
            _truckRepositoryMock = new Mock<ITruckRepository>();

            _truckAppService = new TruckAppService(_mapperMock.Object,
                _truckCommandHandlerMock.Object,
                _truckRepositoryMock.Object);
        }

        [Fact(DisplayName = "Get All Trucks with items")]
        public async Task GetAll_Test_With_Items()
        {
            // Arrange
            _mapperMock.Setup(m => m.Map<IEnumerable<TruckResponse>>(It.IsAny<List<Truck>>()))
                .Returns(TruckEntityMock.GetTruckResponseList);

            _truckRepositoryMock.Setup(m => m.GetAll(false)).ReturnsAsync(TruckEntityMock.GetTruckList);

            // Act
            var result = await _truckAppService.GetAll();

            // Assert
            result.Should().NotBeNullOrEmpty();
        }
    }
}