using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MyCoreAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            // See: https://stackoverflow.com/questions/37365277/how-to-specify-the-port-an-asp-net-core-application-is-hosted-on
            var configuration = new ConfigurationBuilder().AddEnvironmentVariables().Build();

            var URL = configuration["ASPNETCORE_URLS"] ?? "http://*:8080";

            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls(URL);
        }
    }
}
