using KoiFishServiceCenter.Repositories.Entities;
using KoiFishServiceCenter.Repositories.Interfaces;
using KoiFishServiceCenter.Repositories.Repositories;
using KoiFishServiceCenter.Services;
using KoiFishServiceCenter.Services.Interfaces;
using KoiFishServiceCenter.Services.Services;
using Microsoft.EntityFrameworkCore;

namespace KoiServiceCenter.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //DI
            builder.Services.AddDbContext<KoiVetServicesDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DbContext"));
            });

            //DI Repositories
            builder.Services.AddScoped<IReportRepository, ReportRepository >();
            builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
            builder.Services.AddScoped<IUserAccountRepository, UserAccountRepository>();

            //DI Services
            builder.Services.AddScoped<IReportService, ReportService>();
            builder.Services.AddScoped<IUserAccountService, UserAccountService>();
            builder.Services.AddScoped<IServiceService, ServiceService>();


            // Add services to the container.
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
