namespace ElegantCode.Fundamental.Core
{
    public interface IInPresenter<in TData>
    {
        void Present(TData data, CancellationToken cancelToken = default);
    }
}