using FluentAssertions;
using Moq;
using System.Threading.Tasks;
using TruckRegistration.Domain.Commands;
using TruckRegistration.Domain.Contracts.Commands;
using TruckRegistration.Domain.Contracts.Repositories;
using TruckRegistration.Domain.Entities;
using TruckRegistration.Tests.Entities;
using Xunit;

namespace TruckRegistration.Tests.UnitTests.Domain
{
    public class TruckCommandHandlerTests
    {
        private readonly Mock<ITruckRepository> _truckRepositoryMock;
        private readonly TruckCommandHandler _truckCommandHandler;
        public TruckCommandHandlerTests()
        {
            _truckRepositoryMock = new Mock<ITruckRepository>();

            _truckCommandHandler = new TruckCommandHandler(_truckRepositoryMock.Object);
        }

        [Fact(DisplayName = "Add Truck with success")]
        public async Task Add_Truck_Test_With_Success()
        {
            // Arrange
            _truckRepositoryMock.Setup(m => m.SaveOrUpdate(It.IsAny<Truck>()))
                .ReturnsAsync(TruckEntityMock.GetTruck);

            _truckRepositoryMock.Setup(m => m.Commit());

            // Act
            var result = await _truckCommandHandler.Add(TruckEntityMock.GetTruck());

            // Assert
            result.ValidationResult.IsValid.Should().BeTrue();
        }

        [Fact(DisplayName = "Add Truck with errors")]
        public async Task Add_Truck_Test_With_Errors()
        {
            // Arrange
            _truckRepositoryMock.Setup(m => m.SaveOrUpdate(It.IsAny<Truck>()))
                .ReturnsAsync(It.IsAny<Truck>());

            // Act
            var result = await _truckCommandHandler.Add(new Truck());

            // Assert
            result.ValidationResult.IsValid.Should().BeFalse();
            result.ValidationResult.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}
