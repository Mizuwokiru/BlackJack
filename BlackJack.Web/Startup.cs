using Autofac;
using BlackJack.BusinessLogic.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlackJack.Web
{
    public class Startup
    {
        public IConfiguration ApplicationConfig { get; set; }

        public Startup(IConfiguration config)
        {
            ApplicationConfig = config;
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new ServicesModule());
            builder.RegisterModule(new DbWorkerModule(@"Data Source=(LocalDb)\MSSQLLocalDB;Database=BlackJack"));
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            if (!env.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
