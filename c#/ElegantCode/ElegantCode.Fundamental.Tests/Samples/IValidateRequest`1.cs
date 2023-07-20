using ElegantCode.Fundamental.Core;

namespace ElegantCode.Fundamental.Tests.Samples;

public interface IValidateRequest<TUseCaseQuery>
{
    public (TUseCaseQuery UseCaseQuery, Error Error) ValidateRequest();
}