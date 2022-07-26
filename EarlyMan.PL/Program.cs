using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace EarlyMan.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup("EarlyMan.PL");
                })
                .UseDefaultServiceProvider(options =>
                options.ValidateScopes = false);
        }
    }
}