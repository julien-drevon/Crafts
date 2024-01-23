using AopExemple.Tests.Loggers;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;

namespace AopExemple.Tests;

public class Startup
{
    public void ConfigureHost(IHostBuilder hostBuilder) => hostBuilder.UseServiceProviderFactory(
        new AutofacServiceProviderFactory())
        .ConfigureContainer<ContainerBuilder>(
            (host, container) =>
            {
                container.RegisterType<MonSpyLogger>()
                .AsImplementedInterfaces()
                .AsSelf()
                .InstancePerLifetimeScope();

               AddDecoratorExemple(container);
               AddInterceptorExemple(container);
            });








    private static void AddDecoratorExemple(ContainerBuilder container)
    {
        container.RegisterType<MonDeuxiemeExemple>()
                 .As<IMUseCase<DeuxiemeExempleQuery, string>>()
                 .AsSelf();
        container.RegisterDecorator<UseCaseDecorator<DeuxiemeExempleQuery, string>, IMUseCase<DeuxiemeExempleQuery, string>>(context => !context.AppliedDecorators.Any());
    }







    private static void AddInterceptorExemple(ContainerBuilder container)
    {
        container.RegisterType<LoggingInterceptor>();

        container.RegisterType<MonTroisiemeExemple>()
                 .AsImplementedInterfaces()
                 .EnableInterfaceInterceptors()
                 .InterceptedBy(typeof(LoggingInterceptor));

        //container.RegisterType<LoggingInterceptor>()
        //         .Named<IInterceptor>("log-call");

        //container.RegisterType<MonDeuxiemeExemple>()
        //         .AsImplementedInterfaces()
        //         .EnableInterfaceInterceptors(); ;

        //container.RegisterType<MonTroisiemeExemple>()
        //         .AsImplementedInterfaces()
        //         .EnableInterfaceInterceptors();

    }
}