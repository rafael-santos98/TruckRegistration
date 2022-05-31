using AutoMapper;
using FluentAssertions;
using Moq;
using Moq.AutoMock;
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

        [Fact(DisplayName = "Get All Trucks contains items")]
        public async Task GetAll_Test_Contais_Items()
        {
            // Arrange
            _truckRepositoryMock.Setup(m => m.GetAll(It.IsAny<bool>()))
                .ReturnsAsync(TruckEntityMock.GetTruckList);

            _mapperMock.Setup(m => m.Map<IEnumerable<TruckResponse>>(It.IsAny<List<Truck>>()))
                .Returns(TruckEntityMock.GetTruckResponseList);

            // Act
            var result = await _truckAppService.GetAll();

            // Assert
            result.Should().NotBeNullOrEmpty();
        }

        [Fact(DisplayName = "Get All Trucks not contains items")]
        public async Task GetAll_Test_NotContais_Items()
        {
            // Arrange
            _truckRepositoryMock.Setup(m => m.GetAll(It.IsAny<bool>()))
                .ReturnsAsync(It.IsAny<List<Truck>>());

            _mapperMock.Setup(m => m.Map<IEnumerable<TruckResponse>>(It.IsAny<List<Truck>>()))
                .Returns(It.IsAny<List<TruckResponse>>());

            // Act
            var result = await _truckAppService.GetAll();

            // Assert
            result.Should().BeNullOrEmpty();
        }
    }
}