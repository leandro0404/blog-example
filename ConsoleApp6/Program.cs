using System;
using System.Threading.Tasks;
using ConsoleApp6.Adapters;
using Microsoft.Extensions.DependencyInjection;
using Pottencial.Channels.Portals.Authorization.Shared.Models.Pagination;

namespace ConsoleApp6
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var pageSettings = new PageSettings() { };
            pageSettings.Direction = Direction.DESC;


            IServiceCollection services = new ServiceCollection();
            services.ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();

            // meu use case recebe esse repositorio e faz o adapter
            var service = serviceProvider.GetService<IBlogRepository>();

            // busca dados do repo
            var blogs = await service.Get(pageSettings);

            //converte
            var adapter = new BlogAdapter();

            //retorna
            var result = adapter.ToPageResultBlog(blogs);

            Console.WriteLine("Hello World!");
        }
    }
}