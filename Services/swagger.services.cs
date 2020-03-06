using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Services {

    public class SwaggerServices {

        public IServiceCollection services { get; }

        public SwaggerServices(IServiceCollection _services){
                 services = _services;
        }

        public void ConfigureSwagger(string version,OpenApiInfo InfoSwagger){
            try {                        
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(version,InfoSwagger);
            });
            
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }

}