using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using RentCar.Data;
using RentCar.Data.Context;
using RentCar.Data.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddDbContext<RentCarDbContext>();
builder.Services.AddScoped<IRentCarDbContext, RentCarDbContext>();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IVehicleServices, VehicleServices>();
builder.Services.AddScoped<ICustomerServices, CustomerServices>();
builder.Services.AddScoped<IEmployeeServices, EmployeeServices>(); 
builder.Services.AddScoped<IRentalInvoiceServices, RentalInvoiceServices>();

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

app.Run();
