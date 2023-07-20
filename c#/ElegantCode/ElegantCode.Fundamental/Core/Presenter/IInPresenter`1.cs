
using ElegantCode.Fundamental.Core.Errors;

namespace ElegantCode.Fundamental.Core.Presenter;

public interface IInPresenter<in TData>
{
    void PresentData(TData data);
    void PresentError(Error error);
}