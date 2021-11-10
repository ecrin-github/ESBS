using System.Net;
using ContextService.Extensions;
using ContextService.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace ContextService
{
    public class Startup
    {
        private IConfiguration Config { get; }
        
        public Startup(IConfiguration configuration)
        {
            Config = configuration;
        }
        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Setting for the release build for server
            /*services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.KnownProxies.Add(IPAddress.Parse("51.210.99.16"));
            });*/
            
            services.AddApplicationServices(Config);
            
            services.AddControllers();
            
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "The ESBS REST API - Context Documentation", Version = "v1" });
                c.EnableAnnotations();
            });
            
            services.AddCors(options =>
            {
                options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Setting for the release build for server
            /*app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });*/
            
            app.UseMiddleware<ExceptionMiddleware>();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.DocumentTitle = "The ESBS REST API Documentation";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "The ESBS REST API - Context Documentation (v.1)");
                c.InjectStylesheet("/documentation/swagger-custom/swagger-custom-styles.css");
                c.InjectJavascript("/documentation/swagger-custom/swagger-custom-script.js");
                c.RoutePrefix = "api/rest/documentation";
            });
            
            app.UseHttpsRedirection();
            app.UseRouting();
            
            app.UseCors("Open");
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}