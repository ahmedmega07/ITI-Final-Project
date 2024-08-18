using ITI_Final_Poject.Models;
using ITI_Final_Poject.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ITI_Final_Poject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                                ?? throw new InvalidOperationException("No connection string was found");

            builder.Services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(connectionString));




            //register usermanager,rolemanager==>userrole
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(
                options => options.Password.RequireDigit = true
                ).
                AddEntityFrameworkStores<ApplicationContext>();

            //Custom Service --REgister
            builder.Services.AddScoped<I_StudentRepo, StudentRepo>();
            builder.Services.AddScoped<I_DepartmentRepo, DepartmentRepo>();


            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();//requet
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
