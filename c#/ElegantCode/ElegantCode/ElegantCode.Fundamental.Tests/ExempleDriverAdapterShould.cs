namespace ElegantCode.Fundamental.Tests;

public class ExempleDriverAdapterShould
{
    [Fact]
    public async Task ForElegantCode_INeedToDesign_AWorkflowUseCase()
    {
        ExempleDriverAdapterRequest aRequestForDriverAdapter = CreateDriverRequest("42");

        var driverResponse = await CreateDriverAdapter().DoAnExemple(aRequestForDriverAdapter);

        driverResponse.Should().BeEquivalentTo(CreateMyExpectAssert(aRequestForDriverAdapter.CorrelationToken, "42", error: null));
    }

    [Fact]
    public async Task ForElegantCode_INeedToValidateMyRequest_BeforeExecuteUseCase()
    {
        ExempleDriverAdapterRequest aRequestForDriverAdapter = CreateDriverRequest("La question");

        var driverResponse = await CreateDriverAdapter().DoAnExemple(aRequestForDriverAdapter);

        driverResponse.Should().BeEquivalentTo(CreateMyErrorExpectAssert("Formatage incorrect", aRequestForDriverAdapter.CorrelationToken));
    }

    [Fact]
    public async Task ForElegantCode_WhenErrorBusinessIsThrow_ThenBePrintASpecificError()
    {
        ExempleDriverAdapterRequest aRequestForDriverAdapter = CreateDriverRequest("24");

        var driverResponse = await CreateDriverAdapter().DoAnExemple(aRequestForDriverAdapter);

        driverResponse.Should().BeEquivalentTo(CreateMyErrorExpectAssert("La reponse Fournie n'est pas LA reponse", aRequestForDriverAdapter.CorrelationToken));
    }

    private static ExempleDriverAdapter<ExempleUseCaseResponse> CreateDriverAdapter()
    {
        return new ExempleDriverAdapter<ExempleUseCaseResponse>(new SimplePresenter<ExempleUseCaseResponse>());
    }

    private static ExempleDriverAdapterRequest CreateDriverRequest(string theResponse)
    {
        return new ExempleDriverAdapterRequest(Guid.NewGuid())
        {
            TheResponse = theResponse
        };
    }

    private static (ExempleUseCaseResponse Entity, Error Error) CreateMyErrorExpectAssert(string error, Guid correlationToken)
    {
        return new(null, new Error(correlationToken, error));
    }

    private static (ExempleUseCaseResponse Entity, Error Error) CreateMyExpectAssert(Guid token, string response, string error)
    {
        return new(new(token, response), error == null ? null : new Error(token, error));
    }
}