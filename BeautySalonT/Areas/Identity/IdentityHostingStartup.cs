using System;
using BeautySalonT.Areas.Identity.Data;
using BeautySalonT.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(BeautySalonT.Areas.Identity.IdentityHostingStartup))]
namespace BeautySalonT.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<BeautySalonTContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("BeautySalonTContext")));
            });
        }
    }
}