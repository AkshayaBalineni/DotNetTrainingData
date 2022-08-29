using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShopOnBussinessLayer.Contracts;
using ShopOnBussinessLayer.Implementation;
using ShopOnDataLayer.Contracts;
using ShopOnDataLayer.Implementation;
using ShopOnEFLayer.Impl;
using ShopOnEFLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnWebApp
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
            //confid EF
            services.AddDbContext<db_shoponContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Default"));
            });
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<db_shoponContext>();
             //services.AddTransient<ICompanyRepo, CompanyRepoDBImpl>(); 
           // services.AddTransient<InterfaceProductRepository, ProductRepoDB>();
            services.AddTransient<InterfaceProductRepository, ProductRepoEFImpl>();
            services.AddTransient<InterfaceProductManager, ProductManager>();
            //Adding order DI
            services.AddTransient<IOrderRepo, OrderRepoDBImpl>();
            services.AddTransient<IOrderManager, OrderManager>();
           

            services.AddHttpContextAccessor();
            //config Session
            services.AddSession(options =>
            {
                options.Cookie.IsEssential = true;
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
            
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
