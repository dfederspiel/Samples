using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web.Http;

namespace KatanaSamples
{
    using AppFunc = Func<IDictionary<string, object>, Task>;

    /// <summary>
    /// OWIN Middleware examples, low level components, Microsoft OWIN diagnostics for rendering default pages
    /// running in a tiny OWIN web server.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string uri = "http://localhost:8080";
            using (WebApp.Start<Startup>(uri))
            {
                Console.WriteLine("Started!");
                Console.ReadKey();
                Console.WriteLine("Stopping");
            }
        }
    }

    /// <summary>
    /// Startup class for app configuration, must be "Startup" and contain a Configuration method
    /// that takes an IAppBuilder for 
    /// </summary>
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //app.Run(ctx =>
            //{
            //    return ctx.Response.WriteAsync("Hello World!");
            //});

            //app.UseWelcomePage();

            //app.Use<HelloWorldComponent>();


            //app.Use(async (environment, next) =>
            //{
            //    foreach (var pair in environment.Environment)
            //    {
            //        Console.WriteLine("{0}:{1}", pair.Key, pair.Value);
            //    }
            //    await next();
            //});

            app.Use(async (environment, next) =>
            {
                Console.WriteLine("Requesting : " + environment.Request.Path);

                await next();

                Console.WriteLine("Response : " + environment.Response.StatusCode);
            });

            ConfigureWebApi(app);

            app.UseHelloWorld();
        }

        private void ConfigureWebApi(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute("DefaultApi",
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional });
            app.UseWebApi(config);
        }
    }

    public static class AppBuilderExtensions
    {
        public static void UseHelloWorld(this IAppBuilder app)
        {
            app.Use<HelloWorldComponent>();
        }
    }

    public class HelloWorldComponent
    {
        AppFunc _next;
        public HelloWorldComponent(AppFunc next)
        {
            _next = next;
        }

        public Task Invoke(IDictionary<string, object> environment)
        {
            // await _next(environment);
            var response = environment["owin.ResponseBody"] as Stream;
            using (var writer = new StreamWriter(response))
            {
                return writer.WriteAsync("Hello!!");
            }
        }
    }
}
