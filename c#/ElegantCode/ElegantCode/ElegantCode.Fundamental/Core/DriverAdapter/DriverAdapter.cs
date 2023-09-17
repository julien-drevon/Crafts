using ElegantCode.Fundamental.Core.Entities;
using ElegantCode.Fundamental.Core.Errors;
using ElegantCode.Fundamental.Core.Presenter;
using ElegantCode.Fundamental.Core.UsesCases;

namespace ElegantCode.Fundamental.Core.DriverAdapter;

public static class DriverAdapter
{
    public static async Task<(Tout Entity, Error Error)> CreateUseCaseWorkflow<Tout, TUseCaseQuery, TUseCaseResult>(
        IValidateRequest<TUseCaseQuery> aRequestForDriverAdapter,
        IUseCaseAsync<TUseCaseQuery, TUseCaseResult> myUseCase,
        IPresenter<TUseCaseResult, Tout> presenter,
        CancellationToken cancellation = default)
        where TUseCaseQuery : IGotCorrelationToken
    {
        var validationResult = aRequestForDriverAdapter.ValidateRequest();
        presenter.PresentError(validationResult.Error);

        if (validationResult.IsNotOnError())
            await ExecuteUseCase(myUseCase, presenter, validationResult, cancellation);

        return await presenter.View();
    }

    public static async Task ExecuteUseCase<Tout, TUseCaseQuery, TUseCaseResult>(
        IUseCaseAsync<TUseCaseQuery, TUseCaseResult> myUseCAse,
        IPresenter<TUseCaseResult, Tout> doExemplePresenter,
        (TUseCaseQuery UseCaseQuery, Error Error) validationResult,
        CancellationToken cancellation = default)
        where TUseCaseQuery : IGotCorrelationToken
    {
        var useCaseQuery = validationResult.UseCaseQuery;
        try
        {
            doExemplePresenter.PresentData(await myUseCAse.Execute(useCaseQuery, cancellation));
        }
        catch (UseCaseException ex)
        {
            doExemplePresenter.PresentError(new(useCaseQuery.CorrelationToken, ex.Message));
        }
    }
}