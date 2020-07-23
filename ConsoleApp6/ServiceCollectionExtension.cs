using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace ConsoleApp6
{
    public static class ServiceCollectionExtension
    {
        private const string AppSettingsUrl = "Configuration:URL_API";
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            // build configuration
            IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("app-settings.json", false)
            .Build();
            services.AddSingleton(configuration);

            services.AddHttpClient<IBlogRepository, BlogRepository>(client =>
            {
                client.BaseAddress = new Uri(configuration.GetValue<string>(AppSettingsUrl));
            });

            return services;
        }
    }
}
