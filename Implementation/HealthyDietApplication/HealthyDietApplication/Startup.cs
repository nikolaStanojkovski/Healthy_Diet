using HealthyDiet.Domain.Domain;
using HealthyDiet.Domain.Identity;
using HealthyDiet.Repository;
using HealthyDiet.Repository.Implementation;
using HealthyDiet.Repository.Interface;
using HealthyDiet.Service.Implementation;
using HealthyDiet.Service.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyDietApplication
{
    public class Startup
    {
        private string _contentRootPath = "";

        public Startup(IConfiguration configuration, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            Configuration = configuration;
            _contentRootPath = env.ContentRootPath;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string conn = Configuration.GetConnectionString("DefaultConnection");
            if (conn.Contains("%CONTENTROOTPATH%"))
            {
                conn = conn.Replace("%CONTENTROOTPATH%", _contentRootPath);
            }
            // Add framework services.
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(conn));  //use conn
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<HealthyDietUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();

            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            // Repository scoping

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            services.AddScoped(typeof(IDietRepository), typeof(DietRepository));
            services.AddScoped(typeof(IRecipeRepository), typeof(RecipeRepository));

            // Service scoping

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IDietPlanService, DietPlanService>();
            services.AddTransient<IVictualService, VictualService>();
            services.AddTransient<IRecipeService, RecipeService>();
            services.AddTransient<ICalculatorService, CalculatorService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
