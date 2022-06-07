using System.Threading.Tasks;
using TruckRegistration.Services.Api;
using TruckRegistration.Tests.ComponentTests.Config;
using Xunit;

namespace TruckRegistration.Tests.ComponentTests
{
    [Collection(nameof(IntegrationApiTestsFixtureCollection))]
    public class TruckRegistrationApiControllerTruckTest
    {
        private readonly IntegrationTestsFixture<StartupTest> _testsFixture;

        public TruckRegistrationApiControllerTruckTest(IntegrationTestsFixture<StartupTest> testsFixture)
        {
            _testsFixture = testsFixture;
        }

        [Fact(DisplayName = "Get All Trucks contains items")]
        public async Task GetAll_Test_Contains_Items()
        {
            // Arrange & Act
            var response = await _testsFixture.Client.GetAsync("truck-registration/v1/trucks");

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
