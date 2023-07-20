namespace ElegantCode.Fundamental.Core
{
    public interface IInPresenter<in TData>
    {
        void Present(TData data, Error error);
        void PresentData(TData data);
        void PresentError(Error error);
    }
}