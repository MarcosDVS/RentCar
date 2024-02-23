using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using RentCar.Authentication;
using RentCar.Data;
using RentCar.Data.Context;
using RentCar.Data.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
// Configuración de la cadena de conexión
builder.Services.AddDbContext<RentCarDbContext>(options =>
    options.UseSqlite("Data Source=MyDB.sqlite"));
builder.Services.AddScoped<IRentCarDbContext, RentCarDbContext>();

// Servicios
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IVehicleServices, VehicleServices>();
builder.Services.AddScoped<ICustomerServices, CustomerServices>();
builder.Services.AddScoped<IEmployeeServices, EmployeeServices>(); 
builder.Services.AddScoped<IRentalInvoiceServices, RentalInvoiceServices>();

#region Authentication
builder.Services.AddAuthenticationCore();
builder.Services.AddScoped<ProtectedSessionStorage>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
//builder.Services.AddSingleton<UserAccountService>();
builder.Services.AddScoped<IUserAccountService,UserAccountService>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}   


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<RentCarDbContext>();
    try
    {
        if (db.Database.EnsureCreated())
        {
            // La base de datos se ha creado (o ya existe)
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al crear la base de datos: {ex.Message}");
        // Puedes agregar más manejo de errores según tus necesidades
    }
}

app.Run();
