using ElegantCode.Fundamental.Core.DriverAdapter;
using ElegantCode.Fundamental.Core.Errors;
using ElegantCode.Fundamental.Core.Utils;
using System.Runtime.CompilerServices;

namespace ElegantCode.Fundamental.Tests.Samples;

public class ExempleDriverAdapterRequest : IValidateRequest<ExempleUseCaseQuery>
{
    public ExempleDriverAdapterRequest(Guid correlationToken)
    {
        CorrelationToken = correlationToken;
    }

    public Guid CorrelationToken { get; }


    public string TheResponse { get; set; }

    public (ExempleUseCaseQuery UseCaseQuery, Error Error) ValidateRequest()
    {
        return this.ValidationWorkflow(new ExempleUseCaseQuery(CorrelationToken, TheResponse), TheResponse.CreateErrorRule(x=> x!="42" && x!="24", "Formatage incorrect"));        //if (this.TheResponse == "42" || this.TheResponse == "24") return (new(CorrelationToken, TheResponse), null);
        //return (null, new Error(CorrelationToken, "Formatage incorrect"));
    }
}
