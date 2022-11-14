using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CloudBackend
{
    public class Program
    {
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
            {
                HostingAbstractionsWebHostBuilderExtensions.UseUrls(webBuilder, new string[]
                {
                    "http://*:6980"
                });
                webBuilder.UseStartup<StartUP>();
            });
        }
       

        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome To The Clouds Backend");
            CreateHostBuilder(args).Build().Run();
        }

      
    }
}