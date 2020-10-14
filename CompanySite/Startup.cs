using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CompanySite
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //поддержка controllers и views
            services.AddControllersWithViews()
                //совместимость asp core 3.0
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting(); // подключение системы маршрутизаций

            //статичные файлы
            app.UseStaticFiles();

            //маршруты 
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default","{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
