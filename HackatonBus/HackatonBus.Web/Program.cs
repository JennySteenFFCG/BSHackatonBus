using HackatonBus.Suppliers;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace HackatonBus.Web
{
    public class Program
    {
        private static RequestsStore _requestsStore = new RequestsStore();

        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureServices(services =>
                {
                    services.AddSingleton(_requestsStore);
                    services.AddSingleton(new AddGroceryHandler(_requestsStore));
                });
    }
}