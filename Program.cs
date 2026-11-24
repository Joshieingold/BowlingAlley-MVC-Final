using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectDbStarter.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Inject the DbContext child class.
// The controller will use it by receiving it as a parameter in its constructor.
builder.Services.AddDbContext<BowlingDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("BowlingDb"))
);
builder
    .Services.AddAuthentication("app-cookie")
    .AddCookie(
        "app-cookie",
        options =>
        {
            options.LoginPath = "/Auth/Login"; // triggered by [Authorize] when user is NOT logged in
            options.AccessDeniedPath = "/Auth/Denied"; // triggered when we return Forbid()
        }
    );
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

// var hasher = new PasswordHasher<BowlingUser>();
// var hash = hasher.HashPassword(new BowlingUser(), "smonk123");
// Console.WriteLine(hash);

app.Run();
