namespace ElegantCode.Fundamental.Core
{
    public interface IPresenter<in TDataIn, TDataOut> : IOutPresenter<TDataOut>, IInPresenter<TDataIn>
    {
    }
}