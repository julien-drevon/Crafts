using ElegantCode.Fundamental.Core.DriverAdapter;

namespace ElegantCode.Fundamental.Tests.Samples;

public class ExampleDriverAdapterRequest : BaseDriverAdapterRequest<ExampleUseCaseQuery>
{
    public ExampleDriverAdapterRequest(Guid correlationToken) : base(correlationToken)
    { }

    public string TheResponse { get; set; }

    public override (ExampleUseCaseQuery UseCaseQuery, Error Error) ValidateRequest()
    {
        return this.ValidationWorkflow(
           valueIfIsGood: new ExampleUseCaseQuery(CorrelationToken, TheResponse),
           prediacateErrors: TheResponse.CreateErrorRule(theResponse => theResponse.Any(c => !Char.IsDigit(c)), "Formatage incorrect"));
    }
}