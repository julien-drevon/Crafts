namespace ElegantCode.Fundamental.Core
{
    public class SimplePresenter<TData> : IPresenter<TData, TData>
    {
        private TData _Data = default;

        public virtual async Task<TData> View(CancellationToken cancelToken = default)
        {
            return await new ValueTask<TData>(_Data);
        }

        public virtual async void Present(TData data, CancellationToken cancelToken = default)
        {
            _Data = data;
            await Task.CompletedTask;
        }
    }
}