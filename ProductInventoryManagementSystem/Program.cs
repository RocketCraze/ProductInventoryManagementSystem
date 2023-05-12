namespace ProductInventoryManagementSystem
{
    using Microsoft.EntityFrameworkCore;

    using ProductInventoryManagementSystem.Data;
    using ProductInventoryManagementSystem.Interfaces;
    using ProductInventoryManagementSystem.Services;

    public static class Program
    {
        private static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var configBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            var configuration = configBuilder.Build();

            // Add services to the container.
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IProductInventoryService, ProductInventoryService>();

            builder.Services
            .AddRazorPages()
            .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllers();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapDefaultControllerRoute();
            app.MapRazorPages();

            app.Run();
        }
        
    }
    
}

