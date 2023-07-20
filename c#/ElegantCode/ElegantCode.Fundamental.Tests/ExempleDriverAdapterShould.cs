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

            driverResponse.Should().BeEquivalentTo(CreateMyExpectAssert(aRequestForDriverAdapter.CorrelationToken, "42", error: null));
        }


        [Fact]
        public async Task ForElegantCode_INeedToValidateMyRequest_BeforeExecuteUseCase()
        {
            ExempleDriverAdapterRequest aRequestForDriverAdapter = CreateDriverRequest("La question");

            var driverAdapter = new ExempleDriverAdapter<ExempleUseCaseResponse>(new SimplePresenter<ExempleUseCaseResponse>());

            var driverResponse = await driverAdapter.DoAnExemple(aRequestForDriverAdapter);

            driverResponse.Should().BeEquivalentTo(CreateMyErrorExpectAssert("Formatage incorrect"));
        }

        private static ExempleDriverAdapterRequest CreateDriverRequest(string theResponse)
        {
            return new ExempleDriverAdapterRequest(Guid.NewGuid())
            {
                TheResponse = theResponse
            };
        }

        private static (ExempleUseCaseResponse Entity, Error Error) CreateMyErrorExpectAssert(string error)
        {
            return new(null, new Error(error));
        }

        private static (ExempleUseCaseResponse Entity, Error Error) CreateMyExpectAssert(Guid token, string response, string error)
        {
            return new(new(token, response), error == null ? null : new Error(error));
        }
    }


}