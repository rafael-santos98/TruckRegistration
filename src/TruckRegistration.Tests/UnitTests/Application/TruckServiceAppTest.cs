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
    public class TruckServiceAppTest
    {

        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<ITruckCommandHandler> _truckCommandHandlerMock;
        private readonly Mock<ITruckRepository> _truckRepositoryMock;
        private readonly TruckAppService _truckAppService;

        public TruckServiceAppTest()
        {
            _mapperMock = new Mock<IMapper>();
            _truckCommandHandlerMock = new Mock<ITruckCommandHandler>();
            _truckRepositoryMock = new Mock<ITruckRepository>();

            _truckAppService = new TruckAppService(_mapperMock.Object,
                _truckCommandHandlerMock.Object,
                _truckRepositoryMock.Object);
        }

        //[Fact(DisplayName = "Get All Trucks with items")]
        [Fact]
        public void GetAll_Test()
        {
            // Arrange
            _mapperMock.Setup(m => m.Map<IEnumerable<TruckResponse>>(It.IsAny<List<Truck>>()))
                .Returns(TruckEntityMock.GetTruckResponseList);

            _truckRepositoryMock.Setup(m => m.GetAll(false)).ReturnsAsync(TruckEntityMock.GetTruckList);

            // Act
            var result = _truckAppService.GetAll().GetAwaiter().GetResult();

            // Assert
            result.Should().NotBeNullOrEmpty();
        }
    }
}