using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using MartiX.ListStartupServices;
using System.Collections.Generic;
using WebApplication;

namespace MartiX.ListStartupServices.Tests
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.Configure<ServiceConfig>(config =>
                {
                    config.Services = new List<ServiceDescriptor>(services);
                    config.Path = "/mytestservices";
                });
            });
        }
    }
}
