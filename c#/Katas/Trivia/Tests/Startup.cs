using Microsoft.Extensions.Hosting;
using Autofac.Extensions.DependencyInjection;
using Autofac;

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

