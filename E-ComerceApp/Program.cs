using E_ComerceApp.Entities;
using E_ComerceApp.Mappers.Classes;
using E_ComerceApp.Mappers.Interfaces;
using E_ComerceApp.Services.Classes;
using E_ComerceApp.Services.Interfaces;
using E_CommerceApp.Models;
using E_CommerceApp.Repositories.Classes;
using E_CommerceApp.Repositories.Interfaces;
using E_CommerceApp.Services.Classes;
using E_CommerceApp.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Security.Principal;

namespace E_ComerceApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<E_CommerceEntities>(optionBuilder =>
            {
                optionBuilder.UseSqlServer("Server=.;Database=E-CommerceDB;Trusted_Connection=True;TrustServerCertificate=True;");
            });
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(
               options => options.Password.RequireDigit = true
            ).
               AddEntityFrameworkStores<E_CommerceEntities>();

            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IBrandRepository, BrandRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IWishlistRepository, WishlistRepository>();
            builder.Services.AddScoped<ICartRepository, CartRepository>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IAdminService, AdminService>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<ICartService, CartService>();
            builder.Services.AddScoped<IProductMapper, ProductMapper>();






            var app = builder.Build();

            CreateAdminUserAndRole(app).GetAwaiter().GetResult();



            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");



            app.Run();
        }
        private static async Task CreateAdminUserAndRole(WebApplication app)
        {
            using var serviceScope = app.Services.CreateScope();
            var services = serviceScope.ServiceProvider;

            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            var identityOptions = services.GetRequiredService<IOptions<IdentityOptions>>();

            const string adminRoleName = "Admin";
            const string adminUserName = "admin";
            const string adminPassword = "admin";
            const string adminAddress = "NasrCity";
            var originalPasswordSettings = identityOptions.Value.Password;
            identityOptions.Value.Password.RequireDigit = false;
            identityOptions.Value.Password.RequireLowercase = false;
            identityOptions.Value.Password.RequireNonAlphanumeric = false;
            identityOptions.Value.Password.RequireUppercase = false;
            identityOptions.Value.Password.RequiredLength = 1;


            // Create the 'Admin' role
            if (!await roleManager.RoleExistsAsync(adminRoleName))
            {
                await roleManager.CreateAsync(new IdentityRole(adminRoleName));
            }

            // Create the 'admin' user
            var adminUser = await userManager.FindByNameAsync(adminUserName);
            if (adminUser == null)
            {
                adminUser = new ApplicationUser { UserName = adminUserName, Address = adminAddress};
                var creationResult = await userManager.CreateAsync(adminUser, adminPassword);

                if (creationResult.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, adminRoleName);
                }
    
            }
        }
    }
}