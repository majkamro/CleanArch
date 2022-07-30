using CleanArch.Data.Context;
using CleanArch.IoC;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

var configuration = builder.Configuration;

// Add services to the container.

var connectionString = configuration.GetConnectionString("UniversityDBConnection");

services.AddDbContext<UniversityDBContext>(options =>
	 options.UseSqlServer(connectionString));

services.AddDatabaseDeveloperPageExceptionFilter();

services.AddControllersWithViews();

services.AddAuthentication(options =>
{
	options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
	options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options =>
{
	options.LoginPath = "/Login";
	options.LogoutPath = "/Logout";
	options.ExpireTimeSpan = TimeSpan.FromMinutes(43200);
});

RegisterServices(builder.Services);

var app = builder.Build();

ConfigureServices(app);

static void RegisterServices(IServiceCollection services)
{
	DependencyContainer.RegisterServices(services);
}

static void ConfigureServices(WebApplication app)
{
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