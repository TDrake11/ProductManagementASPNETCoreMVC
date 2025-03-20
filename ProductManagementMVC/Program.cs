using Microsoft.EntityFrameworkCore;
using PRN222.Lab1.Services.Services.CategoryService;
using PRN222.Lab1.Services.Services.ProductService;
using PRN222.Lab1.Services.Services.AccountService;
using PRN222.Lab1.Repositories.Interfaces;
using PRN222.Lab1.Repositories.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using PRN222.Lab1.Repositories.Entities;

namespace ProductManagementMVC
{
    public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();

			builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
			builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
			builder.Services.AddDbContext<MyStoreDbContext>();
			// Đăng ký Service
			builder.Services.AddScoped<IProductService, ProductService>();
			builder.Services.AddScoped<ICategoryService, CategoryService>();
			builder.Services.AddScoped<IAccountService, AccountService>();

			builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
			.AddCookie(options =>
			{
				options.ExpireTimeSpan = TimeSpan.FromDays(7); // ✅ Thiết lập thời gian hết hạn cookie
				options.Cookie.HttpOnly = true; // ✅ Bảo mật: Chỉ truy cập cookie qua HTTP, không cho JavaScript truy cập
				options.Cookie.IsEssential = true; // ✅ Đảm bảo cookie luôn được tạo, ngay cả khi không có sự đồng ý của người dùng
				options.SlidingExpiration = true;
			});

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

			app.UseAuthentication();
			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
