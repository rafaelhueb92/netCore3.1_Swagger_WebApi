using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace Middlewares {

    public class SwaggerMiddleware {
        public IApplicationBuilder app;
        public SwaggerMiddleware(IApplicationBuilder _app){
            app = _app;
        }

        public void initSwagger(string ApiTitle) {
            try {

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", ApiTitle);
            });
            }catch(Exception ex){
                throw ex;
            }
        }

    }

}