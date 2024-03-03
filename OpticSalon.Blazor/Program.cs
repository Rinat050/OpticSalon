using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using MudBlazor.Services;
using OpticSalon.Auth;
using OpticSalon.Blazor.Data;
using OpticSalon.Blazor.Middleware;
using OpticSalon.Data;
using OpticSalon.Domain;
using OpticSalon.MinIO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services
    .AddData(builder.Configuration)
    .AddAuth(builder.Configuration)
    .AddDomain()
    .AddFileStorage(builder.Configuration)
    .AddScoped<AuthenticationStateProvider, OpticSalon.Blazor.AuthProvider.AuthenticationStateProvider>()
    .AddMudServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseMiddleware<AuthenticationMiddleware>();
app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseMvcWithDefaultRoute();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
