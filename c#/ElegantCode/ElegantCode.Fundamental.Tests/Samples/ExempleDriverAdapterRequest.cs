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

public static class ValidationUtims
{

    public static (TUseCaseQuery UseCaseQuery, Error Error) ValidationWorkflow<TUseCaseQuery>(this IValidateRequest<TUseCaseQuery> validationModel, TUseCaseQuery valueIfIsGood, params Func<Error>[] predicatesForError)
    where TUseCaseQuery : class, IUSeCaseQuery
    {

        var errors = predicatesForError.Select(x => x?.Invoke()).Where(x => x != null);
        if (errors.IsAny()) return (null, new Error(validationModel.CorrelationToken, errors));
        return (valueIfIsGood, null);
    }

    public static Func<Error> CreateErrorRule(this bool isItBad, string error, Guid correlationToken = default)
    {
        if (isItBad)
        {
            return () => new Error(correlationToken, error);
        }
        return null;
    }
    public static Func<Error> CreateErrorRule<K>(this K me, Func<K, bool> testARule, string error, Guid correlationToken = default)
    {
        return CreateErrorRule(testARule(me), error, correlationToken);
    }
}