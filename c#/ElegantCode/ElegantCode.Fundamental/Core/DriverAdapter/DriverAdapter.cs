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


            return await doExemplePresenter.View();
        }
    }
}