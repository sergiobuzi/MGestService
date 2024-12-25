using MGestService.Data;
using MGestService.Models.Options;
using Microsoft.EntityFrameworkCore;

namespace MGestService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configura l'opzione ConnectionStringsOptions
            builder.Services.Configure<DatabaseOptions>(
                builder.Configuration.GetSection("DatabaseOptions"));

            // Legge le opzioni per ottenere la stringa di connessione
            var connectionString = builder.Configuration
                .GetSection("DatabaseOptions")
                .Get<DatabaseOptions>()?.ConnectionString;

            builder.Services.AddDbContext<ServiceContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddTransient<ServiceManager>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Service}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
