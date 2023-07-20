using ElegantCode.Fundamental.Core;
using ElegantCode.Fundamental.Tests.Samples;
using FluentAssertions;

namespace ElegantCode.Fundamental.Tests
{
    public class ExempleDriverAdapterShould
    {
        [Fact]
        public async Task ForElegantCode_INeedToDesign_AWorkflowUseCase()
        {
            ExempleDriverAdapterRequest aRequestForDriverAdapter = CreateDriverRequest("42");

            var driverAdapter = new ExempleDriverAdapter<ExempleUseCaseResponse>(new SimplePresenter<ExempleUseCaseResponse>());

            var driverResponse = await driverAdapter.DoAnExemple(aRequestForDriverAdapter);

            driverResponse.Should().BeEquivalentTo(new
            {
                TheResponse = "42",
                CorrelationToken = aRequestForDriverAdapter.CorrelationToken
            });
        }

        private static ExempleDriverAdapterRequest CreateDriverRequest(string theResponse)
        {
            return new ExempleDriverAdapterRequest(Guid.NewGuid())
            {
                TheResponse = theResponse
            };
        }
    }
}