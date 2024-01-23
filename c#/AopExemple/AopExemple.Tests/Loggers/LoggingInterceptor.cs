using Castle.DynamicProxy;

namespace AopExemple.Tests.Loggers;

public class LoggingInterceptor : IInterceptor
{
    public LoggingInterceptor(ILog logger)
    {
        Logger = logger;
    }

    public ILog Logger { get; }

    public void Intercept(IInvocation invocation)
    {
        Logger.Log($"Execute : {invocation.Arguments.FirstOrDefault()}");
        invocation.Proceed();

    }
}