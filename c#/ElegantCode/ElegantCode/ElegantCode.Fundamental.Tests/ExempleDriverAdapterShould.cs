namespace ElegantCode.Fundamental.Tests;

public class ExampleDriverAdapterShould
{
    [Fact]
    public async Task ForElegantCode_INeedToDesign_AWorkflowUseCase()
    {
        ExampleDriverAdapterRequest aRequestForDriverAdapter = CreateDriverRequest("42");
        var driverResponse = await CreateDriverAdapter().DoAnExample(aRequestForDriverAdapter);
        driverResponse.Should().BeEquivalentTo(CreateMyExpectAssert(aRequestForDriverAdapter.CorrelationToken
                                                                    , response: "42", error: null));
    }

    [Fact]
    public async Task ForElegantCode_INeedToValidateMyRequest_BeforeExecuteUseCase()
    {
        ExampleDriverAdapterRequest aRequestForDriverAdapter = CreateDriverRequest("La question");
        var driverResponse = await CreateDriverAdapter().DoAnExample(aRequestForDriverAdapter);
        driverResponse.Should().BeEquivalentTo(CreateMyErrorExpectAssert(error: "Formatage incorrect"
                                                                         , aRequestForDriverAdapter.CorrelationToken));
    }

    [Fact]
    public async Task ForElegantCode_WhenErrorBusinessIsThrow_ThenBePrintASpecificError()
    {
        ExampleDriverAdapterRequest aRequestForDriverAdapter = CreateDriverRequest("24");
        var driverResponse = await CreateDriverAdapter().DoAnExample(aRequestForDriverAdapter);
        driverResponse.Should().BeEquivalentTo(CreateMyErrorExpectAssert(error: "La reponse Fournie n'est pas LA reponse"
                                                                         , aRequestForDriverAdapter.CorrelationToken));
    }

    private static ExampleDriverAdapter<ExampleUseCaseResponse> CreateDriverAdapter()
    {
        return new ExampleDriverAdapter<ExampleUseCaseResponse>(new SimplePresenter<ExampleUseCaseResponse>());
    }

    private static ExampleDriverAdapterRequest CreateDriverRequest(string theResponse)
    {
        return new ExampleDriverAdapterRequest(Guid.NewGuid())
        {
            TheResponse = theResponse
        };
    }

    private static (ExampleUseCaseResponse Entity, Error Error) CreateMyErrorExpectAssert(string error, Guid correlationToken)
    {
        return new(null, new Error(correlationToken, error));
    }

    private static (ExampleUseCaseResponse Entity, Error Error) CreateMyExpectAssert(Guid token, string response, string error)
    {
        return new(new(response), error.IsNull() ? null : new Error(token, error));
    }
}