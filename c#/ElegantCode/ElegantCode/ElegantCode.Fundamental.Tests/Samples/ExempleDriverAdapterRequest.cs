using ElegantCode.Fundamental.Core.DriverAdapter;

namespace ElegantCode.Fundamental.Tests.Samples;

public class ExampleDriverAdapterRequest : IValidateRequest<ExampleUseCaseQuery>
{
    public ExampleDriverAdapterRequest(Guid correlationToken)
    { CorrelationToken = correlationToken; }

    public Guid CorrelationToken { get; }

    public string TheResponse { get; set; }

    public (ExampleUseCaseQuery UseCaseQuery, Error Error) ValidateRequest()
    {
        return this.ValidationWorkflow(
           valueIfIsGood: new ExampleUseCaseQuery(CorrelationToken, TheResponse),
           prediacateErrors: TheResponse.CreateErrorRule(theResponse => theResponse.Any(c => !Char.IsDigit(c)), "Formatage incorrect"));
    }
}