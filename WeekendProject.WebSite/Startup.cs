using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Weekend.BLL.Interfaces;
using Weekend.BLL.Services;
using Weekend.BLL.DI;

namespace Weekend.WebSite
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            DIModule dIModule = new DIModule();
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddTransient<IUser, UserService>(options => new UserService(dIModule.ConfigureContext()));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseRouting();

            app.UseMvc(route => { route.MapRoute("login", "{controller=Login}/{action=LogIn}/{id?}"); route.MapRoute("registration", "{controller=Login}/{action=SignUp}/{id}"); });  
        }
    }
}
