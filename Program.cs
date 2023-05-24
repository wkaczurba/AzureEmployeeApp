using EmployeeApp.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.FeatureFilters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddTransient<IEmployeeService, EmployeeService>();
builder.Services.AddFeatureManagement();

// Connection String to 
var connectionString = "Endpoint=https://appcfg123.azconfig.io;Id=OARg;Secret=xtoufiLO01kK6xgb3GnQpeFTwrNIz34JratzgdOkZ2M="; 
builder.Host.ConfigureAppConfiguration(builder =>
{
    builder.AddAzureAppConfiguration(options =>
       options.Connect(connectionString).UseFeatureFlags());
});

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
