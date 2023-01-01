using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(ProductPromotion.Areas.Identity.IdentityHostingStartup))]
namespace ProductPromotion.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}