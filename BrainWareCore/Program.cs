#pragma warning disable 1591
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace BrainWareCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
#pragma warning restore 1591
