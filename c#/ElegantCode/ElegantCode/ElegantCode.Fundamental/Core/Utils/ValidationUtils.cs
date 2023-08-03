using ElegantCode.Fundamental.Core.DriverAdapter;
using ElegantCode.Fundamental.Core.Entities;
using ElegantCode.Fundamental.Core.Errors;

namespace ElegantCode.Fundamental.Core.Utils;

public static class ValidationUtils
{
    /// <summary>
    /// Creates the Func error rule if is bad.
    /// </summary>
    /// <param name="isBad">if set to <c>true</c> [is bad].</param>
    /// <param name="error">The error.</param>
    /// <param name="correlationToken">The correlation token.</param>
    /// <returns></returns>
    public static Func<Error> CreateErrorRule(this bool isBad, string error, Guid correlationToken = default)
    {
        if (isBad)
            return () => new Error(correlationToken, error);

        return null;
    }

    /// <summary>
    /// Creates the error rule.
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <param name="me">Me.</param>
    /// <param name="testARule">The test a rule.</param>
    /// <param name="error">The error.</param>
    /// <param name="correlationToken">The correlation token.</param>
    /// <returns></returns>
    public static Func<Error> CreateErrorRule<K>(this K me, Func<K, bool> testARule, string error, Guid correlationToken = default)
    {
        return testARule(me).CreateErrorRule(error, correlationToken);
    }

    /// <summary>
    /// Validating the workflow. check if predicate contains errors, if isBad return error else return valueIfIsGood
    /// </summary>
    /// <typeparam name="TUseCaseQuery">The type of the use case query.</typeparam>
    /// <param name="validationModel">The validation model.</param>
    /// <param name="valueIfIsGood">The value if is good.</param>
    /// <param name="prediacateErrors">The prediacate errors.</param>
    /// <returns>Tuple (UseCaseQuery, Error) </returns>
    public static (TUseCaseQuery UseCaseQuery, Error Error) ValidationWorkflow<TUseCaseQuery>(
        this IValidateRequest<TUseCaseQuery> validationModel,
        TUseCaseQuery valueIfIsGood,
        params Func<Error>[] prediacateErrors)
            where TUseCaseQuery : class, IGotCorrelationToken
    {
        var errors = prediacateErrors.Select(x => x?.Invoke()).Where(x => x.IsNotNull());
        if (errors.IsAny())
            return (null, new Error(validationModel.CorrelationToken, errors));

        return (valueIfIsGood, null);
    }
}