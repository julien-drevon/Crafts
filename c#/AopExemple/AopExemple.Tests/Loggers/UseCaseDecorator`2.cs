using AopExemple.Aop;
using Autofac.Features.Decorators;

namespace AopExemple.Tests.Loggers;

public class UseCaseDecorator<TQuery, TReturn> : IMUseCase<TQuery, TReturn>
{
    public UseCaseDecorator(IMUseCase<TQuery, TReturn> useCase, IDecoratorContext context, ILog logger)
    {
        UseCase = useCase;
        Context = context;
        Logger = logger;
    }

    public IMUseCase<TQuery, TReturn> UseCase { get; }

    public IDecoratorContext Context { get; }

    public ILog Logger { get; }

    public TReturn Execute(TQuery query)
    {
        var method = this.Context.ImplementationType.GetMethod("Execute");
        if (method != null && method.GetCustomAttributes(typeof(LogAttribute), true).IsAny())
        {
            Logger.Log($"Execute : {query}");
        }


        return UseCase.Execute(query);

    }
}