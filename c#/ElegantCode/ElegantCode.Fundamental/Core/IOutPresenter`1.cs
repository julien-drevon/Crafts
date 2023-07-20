namespace ElegantCode.Fundamental.Core;

public interface IOutPresenter<TDataOut>
{
    Task<(TDataOut Entity, Error Error)> View(CancellationToken cancelToken = default);
}
