
using DatabaseActiveChecker.BLL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DatabaseActiveChecker
{
    public class Program
    {
        static async Task Main(string[] args)
        {

            var builder = new ConfigurationBuilder()
           .AddJsonFile($"appsettings.json", true, true);
            var config = builder.Build();
            var services = new ServiceCollection();
            services.AddSingleton<IConfiguration>(config);
            var serviceProvider = services.BuildServiceProvider();

            var hostEnvironmentService = serviceProvider.GetService<IWebHostEnvironment>();
            await new DatabaseActiveID(config).UpdateSystemOutages();
        }
    }
}