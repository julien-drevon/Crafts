using ElegantCode.Fundamental.Core.DriverAdapter;
using ElegantCode.Fundamental.Core.Errors;

namespace ElegantCode.Fundamental.Core.Utils;

public static class ValidationUtils
{
    public static Func<Error> CreateErrorRule(this bool isItBad, string error, Guid correlationToken = default)
    {
        if (isItBad)
            return () => new Error(correlationToken, error);

        return null;
    }

    public static Func<Error> CreateErrorRule<K>(this K me, Func<K, bool> testARule, string error, Guid correlationToken = default)
    {
        return testARule(me).CreateErrorRule(error, correlationToken);
    }

    public static (TUseCaseQuery UseCaseQuery, Error Error) ValidationWorkflow<TUseCaseQuery>(this IValidateRequest<TUseCaseQuery> validationModel, TUseCaseQuery valueIfIsGood, params Func<Error>[] prediacateErrors)
            where TUseCaseQuery : class, IGotCorrelationToken
    {
        var errors = prediacateErrors.Select(x => x?.Invoke()).Where(x => x != null);
        if (errors.IsAny()) return (null, new Error(validationModel.CorrelationToken, errors));
        return (valueIfIsGood, null);
    }
}