using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Localization;
using Projektsystem.AppService.Services;
using Projektsystem.AppService.Context;
using Projektsystem.AppService.Repository;
using Projektsystem.BlazorApp.ServiceHelper;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using TabBlazor;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddTabBlazor();
builder.Services.AddTabler();
builder.Services.AddLocalization();

builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("InMemoryDatabase"));

builder.Services.AddScoped<IProjectRepository, ProjectService>();
builder.Services.AddScoped<IUserRepository, UserService>();
builder.Services.AddScoped<IAuditLogRepository, AuditLogService>();
builder.Services.AddScoped<IUILanguageRepository, UILanguageService>();
builder.Services.AddScoped<IUITextRepository, UITextService>();
builder.Services.AddScoped<ICompanyRepository, CompanyService>();
builder.Services.AddScoped<IBudgetRepository, BudgetService>();
builder.Services.AddScoped<IProjectUserRepository, ProjectUserService>();

builder.Services.AddScoped<LanguageNotifierService>();
builder.Services.AddScoped(typeof(IStringLocalizer<>), typeof(ProjektsystemStringLocalizer<>));

builder.Services.AddScoped<LoginService>();
builder.Services.AddScoped<SocialAuthenticationProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(sp=>sp.GetRequiredService<SocialAuthenticationProvider>());

builder.Services.AddAuthenticationCore();
//builder.Services.AddHttpContextAccessor();

//builder.Services.AddAuthentication(
//    CookieAuthenticationDefaults.AuthenticationScheme
//)
//.AddCookie()
//.AddMicrosoftAccount(mt => {
//    mt.ClientId = "9bb0817c-dec6-4043-b860-484f67a99b4b";
//    mt.ClientSecret = "6ui8Q~0aEbV8bNI~aqpLP28uxH_jwVN3Tg6Qla3Z";

//});

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();
//app.UseAuthentication();
//app.UseAuthorization();

app.UseStaticFiles();

app.UseRouting();
//app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
