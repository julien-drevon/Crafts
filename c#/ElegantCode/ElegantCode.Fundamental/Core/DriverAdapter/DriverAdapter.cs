using ElegantCode.Fundamental.Core.Errors;
using ElegantCode.Fundamental.Core.Presenter;
using ElegantCode.Fundamental.Core.UsesCases;

namespace ElegantCode.Fundamental.Core.DriverAdapter
{
    public static class DriverAdapter
    {
        public static async Task<(Tout Entity, Error Error)> CreateUseCaseWorflow<Tout, TUseCaseQuery, TUseCaseResult>(
            IValidateRequest<TUseCaseQuery> aRequestForDriverAdapter,
            IUseCaseAsync<TUseCaseQuery, TUseCaseResult> myUseCAse,
            IPresenter<TUseCaseResult, Tout> doExemplePresenter,
            CancellationToken cancellation = default)
            where TUseCaseQuery : IUSeCaseQuery
        {
            var validation = aRequestForDriverAdapter.ValidateRequest();

            doExemplePresenter.PresentError(validation.Error);

            if (validation.Error.IsError() is false)
            {
                await ExecuteUseCase(myUseCAse, doExemplePresenter, validation, cancellation);
            }

            return await doExemplePresenter.View();
        }

        public static async Task ExecuteUseCase<Tout, TUseCaseQuery, TUseCaseResult>(
            IUseCaseAsync<TUseCaseQuery, TUseCaseResult> myUseCAse,
            IPresenter<TUseCaseResult, Tout> doExemplePresenter,
            (TUseCaseQuery UseCaseQuery, Error Error) validation,
            CancellationToken cancellation = default)
            where TUseCaseQuery : IUSeCaseQuery
        {
            var useCaseQuery = validation.UseCaseQuery;
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