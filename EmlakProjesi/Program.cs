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
//interface ile repository birbirine haberle�mesi i�in tan�mlama yap�yoruz.
//builder.Services.AddScoped<IVillaRepository, VillaRepository>();
//builder.Services.AddScoped<IVillaNumber, VillaNumberRepository>();
//builder.Services.AddScoped<IMusteriRepository, MusteriRepository>();
//yukard� kullan�m� servisler tek �at�da alt�na toplayarak unitwork yap�s�n� olu�turduk ve bunu
//servis olarak sistem tan�tt�k
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
