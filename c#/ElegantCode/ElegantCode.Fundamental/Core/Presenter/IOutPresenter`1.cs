using ElegantCode.Fundamental.Core.Errors;

namespace ElegantCode.Fundamental.Core.Presenter;

public interface IOutPresenter<TDataOut>
{
    Task<(TDataOut Entity, Error Error)> View(CancellationToken cancelToken = default);
}
