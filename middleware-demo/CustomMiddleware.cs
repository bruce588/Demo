namespace MiddlewareDemo
{
 using System;
 using System.Threading.Tasks;
 using Microsoft.AspNetCore.Http;

    /*
     //到Startup 加入下列middleware
     app.UseMiddleware<CustomMiddleware>();
         */
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;

        // "Scoped" SERVICE SHOULDN'T DO CONSTRUCTOR DI!!
        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;

        }

        public async Task InvokeAsync(HttpContext context)
        {
            string myMiddleWare = "My Middlename";
            await context.Response.WriteAsync($"{nameof(myMiddleWare)} in. \r\n");

            await _next(context);

            await context.Response.WriteAsync($"{nameof(myMiddleWare)} out. \r\n");
             
        }

    }
 
}