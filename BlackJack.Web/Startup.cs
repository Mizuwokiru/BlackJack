using BlackJack.BusinessLogic.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ninject;
using Ninject.Modules;

namespace BlackJack.Web
{
    public class Startup
    {
        public IConfiguration ApplicationConfig { get; set; }

        public Startup(IConfiguration config)
        {
            ApplicationConfig = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
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

            /*NinjectModule cardModule = new CardModule();
            NinjectModule serviceModule = new ServiceModule(@"Data Source=(LocalDb)\MSSQLLocalDB;Database=BlackJack");
            var kernel = new StandardKernel(cardModule, serviceModule);*/
        }
    }
}
