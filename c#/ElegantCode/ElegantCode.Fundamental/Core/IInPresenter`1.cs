namespace ElegantCode.Fundamental.Core
{
    public interface IInPresenter<in TData>
    {
        void Present(TData data, Error error, CancellationToken cancelToken = default);
    }
}