using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.Cors;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using static System.Net.WebRequestMethods;


namespace Base
{
    public class BaseStartup
    {
        #region summary
        /// <summary>       
        /// Created on : 16-Dec-2019
        /// Created By : 100101
        /// Description: BaseStartup
        /// Modify Date:
        /// Modify By  : 
        /// Description:
        /// </summary>

        #endregion

        #region BaseStartup
        public void baseConfigureServices(IServiceCollection services, string apiName, string apiVersion)
        {
            string[] corsOrigin = { "http://localhost:60611", "http://localhost:59933/", "http://localhost:60605/", "http://localhost:52711", "http://localhost:57733/", "http://localhost:60608/", "http://localhost:51939", "https://mac.mactech.net.in", "http://macserv.mactech.net.in:1258", "https://amfluat.mactech.net.in", "http://amfluatserv.mactech.net.in:1258", "https://localhost:44396", "https://asirvad.macom.in", "http://asirvadbackend.macom.in:1258", "https://amflapps.macom.in", "http://amflbackend.macom.in:1258", "http://localhost:4200", "http://localhost:55872", "http://localhost:63805", "http://localhost:65245", "http://localhost", "http://localhost:60367", "https://macserv.mactech.net.in", "http://localhost:57357", "https://amfluat.macom.in/", "https://localhost:63208/" , "https://lms.asirvad.com/" };
            services.AddSwaggerGen(options =>
            {

                // swagger added for documentation
                options.SwaggerDoc(apiVersion, new OpenApiInfo { Title = apiName, Version = apiVersion });


                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement{
                     {
                        new OpenApiSecurityScheme{
                           Reference = new OpenApiReference{
                           Id = "Bearer", //The name of the previously defined security scheme.
                             Type = ReferenceType.SecurityScheme
                     }
                     },new List<string>()
                        }
                    });

                //options.AddSecurityDefinition("Bearer1", new ApiKeyScheme
                //{
                //    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                //    Name = "Authorization1",
                //    In = "header",
                //    Type = "apiKey"
                //});

                //options.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                //{
                //    { "Bearer1", new string[] { } }
                //});
            });

            services.AddCors(options =>
            {
                options.AddPolicy("fiver",
                    policy => policy.WithOrigins(corsOrigin)
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()
                    .SetIsOriginAllowed(origin => true));
            });
            //services.AddMvc(options =>
            //{
            //    options.Filters.Add(new CorsAuthorizationFilterFactory("fiver"));

            //});

            services.AddControllers();
            services.AddMemoryCache();

            services.Configure<FormOptions>(x =>
            {
                x.ValueLengthLimit = 10000000;
                x.MultipartBodyLengthLimit = 10000000;
                x.MultipartHeadersLengthLimit = 10000000;
            });
            services.AddTransient<IToken, Token>();
            services.AddTransient<TokenValidator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void baseConfigure(IApplicationBuilder app, IWebHostEnvironment env, string apiName)
        {

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("../swagger/v1/swagger.json", apiName);
            });

            //app.UseMvc(routes =>
            //{
            //    // SwaggerGen won't find controllers that are routed via this technique.
            //    routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            //});
            app.UseRouting();
            app.UseCors("fiver");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("Default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
        #endregion
    }
}
