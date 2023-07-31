using ElegantCode.Fundamental.Core.Errors;
using ElegantCode.Fundamental.Core.Presenter;
using ElegantCode.Fundamental.Core.UsesCases;
using ElegantCode.Fundamental.Core.Utils;

namespace ElegantCode.Fundamental.Core.DriverAdapter
{
    public static class DriverAdapter
    {
        public static async Task<(Tout Entity, Error Error)> CreateUseCaseWorflow<Tout, TUseCaseQuery, TUseCaseResult>(
            IValidateRequest<TUseCaseQuery> aRequestForDriverAdapter,
            IUseCaseAsync<TUseCaseQuery, TUseCaseResult> myUseCAse,
            IPresenter<TUseCaseResult, Tout> doExemplePresenter,
            CancellationToken cancellation = default)
            where TUseCaseQuery : IGotCorrelationToken
        {
            var validationResult = aRequestForDriverAdapter.ValidateRequest();
            doExemplePresenter.PresentError(validationResult.Error);

            if (validationResult.Error.IsError() is false)
                await ExecuteUseCase(myUseCAse, doExemplePresenter, validationResult, cancellation);


            return await doExemplePresenter.View();
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
            catch (UseCaseExecption ex)
            {
                doExemplePresenter.PresentError(new(useCaseQuery.CorrelationToken, ex.Message));
            }
        }
    }
}