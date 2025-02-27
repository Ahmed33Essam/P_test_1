using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using P_test_1.Models;
using P_test_1.Repository;

namespace P_test_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //builder.Services.AddControllersWithViews(option =>
            //{
            //    option.Filters.Add(new HandelErrorAttribute());
            //});
            builder.Services.AddControllersWithViews();

            builder.Services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });

            builder.Services.AddScoped<IGenRepository<Department>, DeparmentRepository>();
            builder.Services.AddScoped<IGenRepository<Employee>, EmployeeRepository>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            builder.Services.AddDbContext<ITIContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection"));
            });

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 4;
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<ITIContext>();

            var app = builder.Build();
            
            #region custom middelware
            //app.Use(async(httpContext, Next) =>
            //{
            //    await httpContext.Response.WriteAsync("1) Middelware 1\n");
            //    await Next.Invoke();
            //});
            //app.Use(async (httpContext, Next) =>
            //{
            //    await httpContext.Response.WriteAsync("2) Middelware 1\n");
            //    await Next.Invoke();

            //});
            //app.Run(async (httpContext) =>
            //{
            //    await httpContext.Response.WriteAsync("#) Terminate");
            //});
            #endregion

            #region Built in Middelwares
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            //app.MapControllerRoute("Route1", "M1/{name}/{age:int}/{color?}",
            //    new { controller = "Route", action = "Method1" });

            //app.MapControllerRoute("Route2", "{controller = Route}/{action=Method2}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            #endregion

            app.Run();
        }
    }
}
