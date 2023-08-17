using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(EarlyMan.Areas.Identity.IdentityHostingStartup))]

namespace EarlyMan.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}