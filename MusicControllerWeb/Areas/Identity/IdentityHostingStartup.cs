using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(MusicControllerWeb.Areas.Identity.IdentityHostingStartup))]
namespace MusicControllerWeb.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            //builder.ConfigureServices((context, services) => {
            //});
        }
    }
}