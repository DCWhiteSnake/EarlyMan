using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(EarlyMan.PL.Areas.Identity.IdentityHostingStartup))]

namespace EarlyMan.PL.Areas.Identity
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