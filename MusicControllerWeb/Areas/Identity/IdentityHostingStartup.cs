using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MusicController.Identity.IdentityContext;
using MusicController.Identity.Model;

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