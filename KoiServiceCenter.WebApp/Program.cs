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
            builder.Services.AddScoped<ICostRepository, CostRepository>();
            builder.Services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<IReportRepository, ReportRepository>();
            builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
            builder.Services.AddScoped<IUserAccountRepository, UserAccountRepository>();
            builder.Services.AddScoped<IVetScheduleRepository, VetScheduleRepository>();
            builder.Services.AddScoped<IServiceHistoryRepository, ServiceHistoryRepository>();
            //DI Services
            builder.Services.AddScoped<ICostService, CostService>();
            builder.Services.AddScoped<IFeedbackService, FeedbackService>();
            builder.Services.AddScoped<ICustomerService,CustomerService > ();
            builder.Services.AddScoped<IReportService, ReportService>();
            builder.Services.AddScoped<IUserAccountService, UserAccountService>();
            builder.Services.AddScoped<IServiceService, ServiceService>();
            builder.Services.AddScoped<IVetScheduleService, VetScheduleService>();
            builder.Services.AddScoped<IServiceHistoryService, ServiceHistoryService>();
            //
                 builder.Services.AddAuthentication(options =>
                 {
                // Sử dụng PolicyScheme làm scheme mặc định
                options.DefaultScheme = "DynamicScheme";
                options.DefaultChallengeScheme = "DynamicScheme";
                })
                // PolicyScheme để chọn scheme động dựa trên URL
                .AddPolicyScheme("DynamicScheme", "Dynamic Authentication Scheme", options =>
                {
               options.ForwardDefaultSelector = context =>
               {
                   // Nếu đường dẫn bắt đầu bằng /Admin, sử dụng AdminCookieAuth
                   if (context.Request.Path.StartsWithSegments("/Admin"))
                   {
                       return "AdminCookieAuth";
                   }
                   // Ngược lại, sử dụng CustomerCookieAuth cho các phần khác
                   return "CustomerCookieAuth";
               };
               })
              .AddCookie("CustomerCookieAuth", options =>
             {
                    options.Cookie.Name = "CustomerCookieAuth";
                    options.LoginPath = "/dang-nhap";
                    options.AccessDeniedPath = "/Account/AccessDenied";
             })
             .AddCookie("AdminCookieAuth", options =>
            {
            options.Cookie.Name = "AdminCookieAuth";
            options.LoginPath = "/Admin/Account/Login";
            options.AccessDeniedPath = "/Admin/Account/AccessDenied";
            });


            //
            // phân quyền
            builder.Services.AddAuthorization(options =>
			{
				options.AddPolicy("ManagerOnly",
					policy => policy.RequireClaim("Manager"));
				options.AddPolicy("StaffOnly",
					policy => policy.RequireClaim("Staff"));
				options.AddPolicy("VeterinarianOnly",
					policy => policy.RequireClaim("Veterinarian"));
				options.AddPolicy("ManagerOrStaffOnly", policy =>
					policy.RequireAssertion(context =>
						context.User.HasClaim("Manager", "true") ||
						context.User.HasClaim("Staff", "true")));
                options.AddPolicy("EveryoneOnly", policy =>
                    policy.RequireAssertion(context =>
                        context.User.HasClaim("Everyone", "true") ||
                        context.User.HasClaim("Veterinarian", "true")));
            });
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
