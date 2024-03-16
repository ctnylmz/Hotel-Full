using DataAccess.Concrete.EntityFramework.Context;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Servislerin eklenmesi
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();

// DbContext'in servislere eklenmesi
builder.Services.AddDbContext<HotelFullContext>();

// Identity servislerinin eklenmesi
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<HotelFullContext>()
    .AddDefaultTokenProviders();

var app = builder.Build();

// HTTP request pipeline'ının yapılandırılması
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Controller routing'inin tanımlanması
app.MapControllerRoute(
    name: "area",
    pattern: "{area}/{controller=Admin}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

app.Run();
