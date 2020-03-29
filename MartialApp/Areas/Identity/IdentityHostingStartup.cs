using System;
using MartialApp.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(MartialApp.Areas.Identity.IdentityHostingStartup))]
namespace MartialApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<MartialAppContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("MartialAppContextConnection")));

                services.AddIdentity<IdentityUser,IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<MartialAppContext>()
                .AddDefaultUI()
            .AddDefaultTokenProviders();
            });
        }
    }
}