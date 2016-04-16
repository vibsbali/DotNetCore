using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OdeToFood.Services;

namespace OdeToFood
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup()
        {
            //create a new builder and add new json file 
            var builder = new ConfigurationBuilder()
                                .AddJsonFile("appsettings.json");
            //Calling Build on builder will return an IConfiguration object 
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(provider => Configuration);
            services.AddSingleton<IGreeter, Greeter>();
            services.AddScoped<IRestaurantData, InMemoryRestaurantData>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment environment, IGreeter greeter)
        {
            app.UseIISPlatformHandler();

            //Show development error page if in Development mode. Configurable by looking at properties
            if (environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                
            }

            app.UseRuntimeInfoPage("/info");

            //app.UseDefaultFiles();
            //app.UseStaticFiles();

            app.UseFileServer();

            app.UseMvc(configureRoutes =>
            {
                // /Home/Index

                configureRoutes.MapRoute("Default", 
                    "{controller=Home}/{action=Index}/{id?}");
            });

            app.Run(async (context) =>
            {
                //throw new System.Exception("Error");

                var greeting = greeter.GetGreeting();
                await context.Response.WriteAsync(greeting);
            });
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
