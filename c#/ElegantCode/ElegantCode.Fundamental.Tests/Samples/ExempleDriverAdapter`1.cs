using ElegantCode.Fundamental.Core;

namespace ElegantCode.Fundamental.Tests.Samples;

public class ExempleDriverAdapter<Tout>
{
    private readonly IPresenter<ExempleUseCaseResponse, Tout> _DoExemplePresenter;

    public ExempleDriverAdapter(IPresenter<ExempleUseCaseResponse, Tout> doExemplePresenter)
    {
        _DoExemplePresenter = doExemplePresenter;
    }

    public async Task<Tout> DoAnExemple(ExempleDriverAdapterRequest aRequestForDriverAdapter, CancellationToken cancellation = default)
    {
        var query = new ExempleUseCaseQuery() { CorrelationToken = aRequestForDriverAdapter.CorrelationToken, TheResponse = aRequestForDriverAdapter.TheResponse };
        _DoExemplePresenter.Present(await new ExempleUseCase().Execute(query, cancellation));
        return await _DoExemplePresenter.View();
    }
}