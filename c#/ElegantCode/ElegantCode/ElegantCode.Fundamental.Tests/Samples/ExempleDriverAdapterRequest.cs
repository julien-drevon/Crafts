using ElegantCode.Fundamental.Core.DriverAdapter;

namespace ElegantCode.Fundamental.Tests.Samples;

public class ExempleDriverAdapterRequest : IValidateRequest<ExempleUseCaseQuery>
{
    public ExempleDriverAdapterRequest(Guid correlationToken)
    { CorrelationToken = correlationToken; }

    public Guid CorrelationToken { get; }

    public string TheResponse { get; set; }

    public (ExempleUseCaseQuery UseCaseQuery, Error Error) ValidateRequest()
    {
        return this.ValidationWorkflow(
           valueIfIsGood: new ExempleUseCaseQuery(CorrelationToken, TheResponse),
           prediacateErrors: TheResponse.CreateErrorRule(theResponse => theResponse.Any(c => !Char.IsDigit(c)), "Formatage incorrect"));
    }
}