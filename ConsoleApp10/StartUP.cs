using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using System;
using System.Net;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using CloudBackend.Errors;

namespace CloudBackend
{
    public class StartUP
    {
        public StartUP(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddRouting(options => options.LowercaseUrls = true);  
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                Console.WriteLine(endpoints.DataSources);
                endpoints.MapControllers();
            });

            app.UseStatusCodePages(async (StatusCodeContext context) => {
                var request = context.HttpContext.Request;
                var response = context.HttpContext.Response;
                var text = "";
                if (response.StatusCode == (int)HttpStatusCode.NotFound)
                {
                    text = NotFound.Error();
                    //context.HttpContext.Request.Headers.Add("Content-Type", "application/json");
                    await context.HttpContext.Response.WriteAsync(text);
                }
            });
        }
    }
}
