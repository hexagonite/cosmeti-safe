using CosmetiSafe.Data;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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

void ConfigureServices(WebApplicationBuilder webApplicationBuilder)
{
    var services = webApplicationBuilder.Services;
    
    services.AddSwaggerGen();
    services.AddControllersWithViews();
    builder.Services.AddDbContext<CosmetiSafeContext>();
    builder.Services.Configure<JsonOptions>(options =>
    {
        options.SerializerOptions.Converters.Add(new Cysharp.Serialization.Json.UlidJsonConverter());
    });
}
