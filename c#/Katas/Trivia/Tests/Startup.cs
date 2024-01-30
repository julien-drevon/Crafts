using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Tests;

public class Startup
{
    public void ConfigureHost(IHostBuilder hostBuilder) => hostBuilder.UseServiceProviderFactory(
        new AutofacServiceProviderFactory())
        .ConfigureContainer<ContainerBuilder>(
            (host, container) =>
            {
            });
}