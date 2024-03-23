using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(
 options=>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))   
    );
//interface ile repository birbirine haberleþmesi için tanýmlama yapýyoruz.
//builder.Services.AddScoped<IVillaRepository, VillaRepository>();
//builder.Services.AddScoped<IVillaNumber, VillaNumberRepository>();
//builder.Services.AddScoped<IMusteriRepository, MusteriRepository>();
//yukardý kullanýmý servisler tek çatýda altýna toplayarak unitwork yapýsýný oluþturduk ve bunu
//servis olarak sistem tanýttýk
builder.Services.AddScoped<IUnitofWork, UnitofWork>();
//
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
