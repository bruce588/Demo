using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MiddlewareDemo
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
           
           
           app.Use(async (context, next) => {
               await context.Response.WriteAsync("1 Middleware in.\r\n");
               await next();
               await context.Response.WriteAsync("1 Middleware out.\r\n");
           });
             

            app.Use(async (context, next) => {
                await context.Response.WriteAsync("2 Middleware in.\r\n");
                await next();
                await context.Response.WriteAsync("2 Middleware out.\r\n");
            });

            //自己寫的middle
            //app.UseMiddleware<CustomMiddleware>();


         
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!\r\n");
              
                });
                  endpoints.MapGet("/map2", async context =>
                {
                    await context.Response.WriteAsync("bruce!\r\n");
                }); 
            });

            //這是最後一個方法
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Last is Run ! \r\n");
            //});
        }

        
    }
}
