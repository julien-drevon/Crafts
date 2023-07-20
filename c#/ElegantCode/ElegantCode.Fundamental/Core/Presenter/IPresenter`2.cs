namespace ElegantCode.Fundamental.Core.Presenter
{
    public interface IPresenter<in TDataIn, TDataOut> : IOutPresenter<TDataOut>, IInPresenter<TDataIn>
    {
    }
}