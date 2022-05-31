using AutoMapper;
using FluentAssertions;
using System.Threading.Tasks;
using TruckRegistration.Application.AutoMapper;
using TruckRegistration.Domain.Entities;
using TruckRegistration.Tests.Entities;
using Xunit;

namespace TruckRegistration.Tests.UnitTests.Application.AutoMapper
{
    public class AutoMapperMappingTests
    {
        private readonly IMapper _mapper;

        public AutoMapperMappingTests()
        {
            //Auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperMappingProfile());
            });

            _mapper = mockMapper.CreateMapper();
        }

        [Fact(DisplayName = "Validate Map AddTruckRequest To Truck Test is valid")]
        public async Task Validate_Map_AddTruckRequestToTruck_Test_Is_Valid()
        {
            // Arrange
            var truckRequest = TruckEntityMock.GetAddTruckRequest();

            // Act
            var result = _mapper.Map<Truck>(truckRequest);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(new System.Guid());
            result.Description.Should().Be(truckRequest.Description);
            result.Model.Should().Be(truckRequest.Model);
            result.ManufactureYear.Should().Be(truckRequest.ManufactureYear);
            result.ModelYear.Should().Be(truckRequest.ModelYear);
            result.Renavam.Should().Be(truckRequest.Renavam);
            result.Color.Should().Be(truckRequest.Color);
        }
    }
}
