using ElegantCode.Fundamental.Core.DriverAdapter;

namespace ElegantCode.Fundamental.Tests.Samples;

public class ExampleDriverAdapter<Tout> where Tout : class
{
    private readonly IPresenter<ExampleUseCaseResponse, Tout> _DoExemplePresenter;

    public ExampleDriverAdapter(IPresenter<ExampleUseCaseResponse, Tout> doExemplePresenter)
    { _DoExemplePresenter = doExemplePresenter; }

    public async Task<(Tout Entity, Error Error)> DoAnExample(
        ExampleDriverAdapterRequest aRequestForDriverAdapter,
        CancellationToken cancellation = default)
    {
        return await DriverAdapter.CreateUseCaseWorkflow(aRequestForDriverAdapter, new ExempleUseCase(), _DoExemplePresenter, cancellation);
    }
}