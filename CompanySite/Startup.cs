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
            //����������� ������ ����� appsettings.json
            Configuration.Bind("Project", new Config());

            //����������� ���������� ��� �������. ���������� ���������� � ��� �����������
            services.AddTransient<IServiceItemsRepository, EFServiceItemsRepository>();
            services.AddTransient<ITextFieldsRepository, EFTextFieldsRepository>();
            services.AddTransient<IFeedBackRepository, EFFeedBackRepository>();
            services.AddTransient<DataManager>();

            //���������� ��
            services.AddDbContext<AppDbContext>(x => x.UseSqlServer(Config.ConnectionString));

            //��������� Identity �������
            services.AddIdentity<IdentityUser, IdentityRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true; //������������ email
                opts.Password.RequiredLength = 6; //����������� ������� ��� ������
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false; //������������� ����
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            //����������� authentication cookie
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "myCompanyAuth";
                options.Cookie.HttpOnly = true;
                options.LoginPath = "/account/login"; //������� � ������ �������������� 
                options.AccessDeniedPath = "/account/accessdenied";
                options.SlidingExpiration = true;
            });

            //��������� �������� ����������� ��� �������������� � ������� area
            services.AddAuthorization(a =>
            {
                a.AddPolicy("AdminArea", policy =>
                    {
                        policy.RequireRole("admin");
                    });
            });

            //��������� controllers � views
            services.AddControllersWithViews(x =>
                    {
                        x.Conventions.Add(new AdminAreaAuthorization("Admin","AdminArea"));
                    })
                //������������� asp core 3.0
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //��������� �����
            app.UseStaticFiles();

            // ����������� ������� �������������
            app.UseRouting(); 

            //����������� �������������� � �����������
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            //�������� 
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("Admin", "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute("default","{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
