using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Services;
using Middlewares;

namespace middlewareApiPoc
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(c => c.AddDefaultPolicy(builder =>{
                   builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddControllers();

            var InfoSwagger = new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "Api Core Restfull CRUD",
                    Description = "A simple example ASP.NET Core Web API Rest With Dapper And EF, Created By Rafael Hueb",
                    Contact = new OpenApiContact() {
                        Name = "Rafael Hueb",
                        Email = "rafaelhueb92@gmail.com",
                        Url = new Uri("https://github.com/rafaelhueb92") 
                    }
                };

            new SwaggerServices(services).ConfigureSwagger("V1",InfoSwagger);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            new SwaggerMiddleware(app).initSwagger("Weather Control");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
