using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace AspNetCoreError
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var hostBuilder = new WebHostBuilder()
            .UseKestrel()
            .UseIISIntegration()
            .UseStartup<Startup>();

        // ConfigureServices is only used to delay execution until UseIISIntegration()
        // has actually set the "urls" setting.
        hostBuilder.ConfigureServices(services =>
        {
            var urls = hostBuilder.GetSetting("urls");
            urls = urls.Replace("localhost", "127.0.0.1");
            hostBuilder.UseSetting("urls", urls);
        });

        var host = hostBuilder.Build();

        host.Run();
        }
    }
}
