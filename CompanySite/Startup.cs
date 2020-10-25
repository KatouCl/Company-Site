using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanySite.Domain;
using CompanySite.Domain.Repositories.Abstract;
using CompanySite.Domain.Repositories.EntityFramework;
using CompanySite.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace CompanySite
{
    public class Startup
    {

        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            //подключение конфиг файла appsettings.json
            Configuration.Bind("Project", new Config());

            //подключение фукционала как сервисы. Связывания интерфейса с его реализацией
            services.AddTransient<IServiceItemsRepository, EFServiceItemsRepository>();
            services.AddTransient<ITextFieldsRepository, EFTextFieldsRepository>();
            services.AddTransient<IFeedBackRepository, EFFeedBackRepository>();
            services.AddTransient<DataManager>();

            //поключение БД
            services.AddDbContext<AppDbContext>(x => x.UseSqlServer(Config.ConnectionString));

            //настройка Identity системы
            services.AddIdentity<IdentityUser, IdentityRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true; //подтвердения email
                opts.Password.RequiredLength = 6; //минимальная длинная для пароля
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false; //использование цифр
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            //настраиваем authentication cookie
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "myCompanyAuth";
                options.Cookie.HttpOnly = true;
                options.LoginPath = "/account/login"; //допступ к панели администратора 
                options.AccessDeniedPath = "/account/accessdenied";
                options.SlidingExpiration = true;
            });

            //настройка политики авторизации для Администратора в области area
            services.AddAuthorization(a =>
            {
                a.AddPolicy("AdminArea", policy =>
                    {
                        policy.RequireRole("admin");
                    });
            });

            //поддержка controllers и views
            services.AddControllersWithViews(x =>
                    {
                        x.Conventions.Add(new AdminAreaAuthorization("Admin","AdminArea"));
                    })
                //совместимость asp core 3.0
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //статичные файлы
            app.UseStaticFiles();

            // подключение системы маршрутизаций
            app.UseRouting(); 

            //подключения аутондификацию и авторизацию
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            //маршруты 
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("Admin", "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute("default","{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
