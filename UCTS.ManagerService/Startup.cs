using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SignalRWebPack.Hubs;
using UCTS.Manager.BL;
using UCTS.ManagerService.Hubs;
using UCTS.ManagerService.Services;

namespace UCTS.ManagerService
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
            services.AddCors();
            services.AddOptions();
            services.AddSignalR();
            services.AddSingleton<ICarsRepository, CarsRepository>();
            services.AddSingleton<ITravelFactory, TravelFactory>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(config =>
                 config.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials());

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseSignalR(options =>
            {
                //options.MapHub<ChatHub>("/hub");
                options.MapHub<RadioHub>("/hub");
            });

            app.UseMvc();
        }
    }
}
