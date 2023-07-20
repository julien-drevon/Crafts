using ElegantCode.Fundamental.Core.Errors;
using System.Runtime.Serialization;
namespace ElegantCode.Fundamental.Core.Presenter;

public class SimplePresenter<TData> : IPresenter<TData, TData> where TData : class
{
    private TData _Data = null;
    private Error _Error = null;

    public virtual async Task<(TData Entity, Error Error)> View(CancellationToken cancelToken = default)
    {
        return await Task.FromResult<(TData Entity, Error Error)>(new(_Data, _Error));
    }

    public void PresentData(TData data)
    {
        _Data = data;
    }

    public void PresentError(Error error)
    {
        _Error = error;
    }
}
