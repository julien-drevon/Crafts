using Autofac.Extras.DynamicProxy;

namespace AopExemple
{
    //[Intercept("log-call")]
    public interface IMUseCase<TQuery, TReturn>
    {
        TReturn Execute(TQuery query);
    }
}