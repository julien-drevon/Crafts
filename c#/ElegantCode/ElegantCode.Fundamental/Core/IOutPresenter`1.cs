namespace ElegantCode.Fundamental.Core
{
    public interface IOutPresenter<TDataOut>
    {
        Task<TDataOut> View(CancellationToken cancelToken = default);
    }
}