using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Configuration.Contracts;

using Mappings;

using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Diagnostics;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace WebClient
{
    
    public class Startup
    {

        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
            

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }


        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            foreach (var mapping in Aggregator.Mappings)
            {
                switch (mapping.Scope)
                {
                    case Scope.Singleton:
                        services.AddSingleton(mapping.ContractType, mapping.ImplementationType);
                        break;
                    case Scope.Transient:
                        services.AddTransient(mapping.ContractType, mapping.ImplementationType);
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }

            services.AddMvc();
            
        }
     

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseIISPlatformHandler();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();

            var config = app.ApplicationServices.GetService<IConfigurator>();
            config.Set("Filters", "AgeTreshold", 2, false);
            config.Set("Database", "ConnectionString",
                @"Data Source=(localdb)\v11.0;Initial Catalog=BCKontaktManager;Integrated Security=True", false);
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
