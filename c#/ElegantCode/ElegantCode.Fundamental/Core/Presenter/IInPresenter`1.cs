
using ElegantCode.Fundamental.Core.Errors;

namespace ElegantCode.Fundamental.Core.Presenter;

public interface IInPresenter<in TData>
{
    void Present(TData data, Error error);
    void PresentData(TData data);
    void PresentError(Error error);
}