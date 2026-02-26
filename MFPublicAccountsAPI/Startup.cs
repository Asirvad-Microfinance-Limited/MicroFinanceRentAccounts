using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Base;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;



namespace MFPublicRentAPI
{
    public class Startup : BaseStartup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //baseConfigureServices(services, "MFPublicAccountsAPI", "v1");
            baseConfigureServices(services, "MFPublicRentAPI", "v1");


            //new change from ken//
            //// CORS
            //services.AddCors(options =>
            //{
            //    options.AddPolicy("AllowSpecificOrigins",
            //        builder => builder.WithOrigins("https://amfluat.macom.in/dnete", "https://lms.asirvad.com/DNetE/mfweb") // UAT & Live
            //                          .SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost") // LocalHost
            //                          .AllowAnyMethod()
            //                          .AllowAnyHeader()
            //                          .AllowCredentials());
            //});

            //end new change //





        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            //new parametr validation by sameer//
            //app.Use(async (context, next) =>
            //{

            //    if (!string.IsNullOrEmpty(context.Request.QueryString.Value) && context.Request.QueryString.Value.Length > 1)
            //    {
            //        context.Response.StatusCode = StatusCodes.Status400BadRequest;
            //        await context.Response.WriteAsync("Query parameters are not allowed.");
            //        return;
            //    }

            //    await next();
            //});
            //end parameter validation//

           

            // app.UseHttpsRedirection();
            //new change from ken//
            //app.UseCors("AllowSpecificOrigins"); // CORS
            //end new change//
            baseConfigure(app, env, "MFPublicRentAPI");
            //baseConfigure(app, env, "MFPublicAccountsAPI");


            // app.UseMiddleware<Middleware>();
        }
    }
}
