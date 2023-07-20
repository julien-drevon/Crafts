using ElegantCode.Fundamental.Core;

namespace ElegantCode.Fundamental.Tests.Samples;

public class ExempleDriverAdapter<Tout>
{
    private readonly IPresenter<ExempleUseCaseResponse, Tout> _DoExemplePresenter;

    public ExempleDriverAdapter(IPresenter<ExempleUseCaseResponse, Tout> doExemplePresenter)
    {
        _DoExemplePresenter = doExemplePresenter;
    }

    public async Task<(Tout Entity, Error Error)> DoAnExemple(ExempleDriverAdapterRequest aRequestForDriverAdapter, CancellationToken cancellation = default)
    {
        var query = new ExempleUseCaseQuery() { CorrelationToken = aRequestForDriverAdapter.CorrelationToken, TheResponse = aRequestForDriverAdapter.TheResponse };
        if (aRequestForDriverAdapter.TheResponse != "42")
        {
            _DoExemplePresenter.Present(null, new Error("Formatage incorrect"), cancellation);

        }
        else
        {
            _DoExemplePresenter.Present(await new ExempleUseCase().Execute(query, cancellation), null, cancellation);
        }
        return await _DoExemplePresenter.View();
    }
}