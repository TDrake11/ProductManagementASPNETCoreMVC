using Microsoft.EntityFrameworkCore;
using PRN222.Lab1.Services.Services.CategoryService;
using PRN222.Lab1.Services.Services.ProductService;
using PRN222.Lab1.Repositories.Data;
using PRN222.Lab1.Repositories.Repositories.CategoryRepository;
using PRN222.Lab1.Repositories.Repositories.ProductRepository;
using PRN222.Lab1.Services.Services.AccountService;
using PRN222.Lab1.Repositories.Repositories.AccountRepository;

namespace ProductManagementMVC
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();
			builder.Services.AddDbContext<MyStoreDbContext>(options =>
				options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

			builder.Services.AddScoped<IProductRepository, ProductRepository>();
			builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
			builder.Services.AddScoped<IAccountRepository, AccountRepository>();

			// Đăng ký Service
			builder.Services.AddScoped<IProductService, ProductService>();
			builder.Services.AddScoped<ICategoryService, CategoryService>();
			builder.Services.AddScoped<IAccountService, AccountService>();

			builder.Services.AddSession(options =>
			{
				options.IdleTimeout = TimeSpan.FromMinutes(20); // Set sesion timeout
				options.Cookie.HttpOnly = true; // For security
				options.Cookie.IsEssential = true; //Ensure sesion cookie is always created
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

			app.UseSession();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
