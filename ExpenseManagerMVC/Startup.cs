using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using ExpenseManager;
using static ExpenseManager.ExpenseSystem;

using Microsoft.EntityFrameworkCore;
namespace ExpenseManagerMVC
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
            string connectionString = "Host=suleiman.db.elephantsql.com;Port=5432;Database=ihwwgphw;Username=ihwwgphw;Password=Em_9BpT0HFIgTCKbXBmix7otL2UOIFGH;";
            services.AddDbContext<ApplicationContext> (options => options.UseNpgsql(connectionString, b => b.MigrationsAssembly("ExpenseManagerMVC")));
            services.AddScoped<IStoreExpense, ExpenseStorageEF>();
            services.AddScoped<ExpenseSystem>();
         //   var expenseStorage = new ExpenseStorageEF();
            services.AddControllersWithViews();

          /*  var ex= penseStorage = new ExpenseStorageList();
            var _theExpenseSystem=new ExpenseSystem(expenseStorage);

            services.AddSingleton<ExpenseSystem>(_theExpenseSystem);*/
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
