using System.Reflection;
using CosmetiSafe.Data;
using CosmetiSafe.Web;
using CosmetiSafe.Web.Middlewares;
using CosmetiSafe.Web.Options;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json",
        optional: true, reloadOnChange: true)
    .Build();

ConfigureServices(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "CosmetiSafe API");
        c.RoutePrefix = "swagger";
    });
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
return;

void ConfigureServices(WebApplicationBuilder webApplicationBuilder)
{
    var services = webApplicationBuilder.Services;
    
    services.AddControllersWithViews();
    
    services.AddSwaggerGen();
    services.Configure<JsonOptions>(options =>
    {
        options.SerializerOptions.Converters.Add(new Cysharp.Serialization.Json.UlidJsonConverter());
    });
    
    services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    
    services.Configure<DatabaseOptions>(builder.Configuration.GetSection(DatabaseOptions.OptionsName));

    var sqlConnectionString = builder.Configuration["Database:SqlConnectionString"];
    
    services.AddDbContextPool<ICosmetiSafeContext, CosmetiSafeContext>(options =>
    {
        var dbContextOptionsBuilder = options.UseSqlServer(sqlConnectionString, optionsBuilder =>
        {
            optionsBuilder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            optionsBuilder.MigrationsAssembly("CosmetiSafe.Migrations");
        });
        
        if (webApplicationBuilder.Environment.IsDevelopment())
        {
            dbContextOptionsBuilder.EnableSensitiveDataLogging();
        }

    });
}