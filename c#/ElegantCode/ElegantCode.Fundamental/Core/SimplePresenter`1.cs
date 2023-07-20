namespace ElegantCode.Fundamental.Core
{
    public class SimplePresenter<TData> : IPresenter<TData, TData> where TData : class
    {
        private TData _Data = null;
        private Error _Error = null;

        public virtual async Task<(TData Entity, Error Error)> View(CancellationToken cancelToken = default)
        {
            return await Task.FromResult<(TData Entity, Error Error)>(new(_Data, _Error));
        }

        public virtual async void Present(TData data, Error error)
        {
            _Data = data;
            _Error = error;
            await Task.CompletedTask;
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
}