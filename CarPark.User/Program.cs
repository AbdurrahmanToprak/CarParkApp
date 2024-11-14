using AspNetCore.Identity.MongoDbCore.Models;
using CarPark.Business.Abstract;
using CarPark.Business.Concrete;
using CarPark.Core.Repository.Abstract;
using CarPark.Core.Settings;
using CarPark.DataAccess.Abstract;
using CarPark.DataAccess.Concrete;
using CarPark.DataAccess.Repository;
using CarPark.Entities.Concrete;
using CarPark.User.Resources;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Serilog;
using System;
using System.Configuration;
using System.Globalization;
using System.Reflection;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;



var builder = WebApplication.CreateBuilder(args);

// Configure Serilog
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("log.txt")
    .WriteTo.Seq("http://localhost:5341/")
    .MinimumLevel.Information()
    .Enrich.WithProperty("ApplicationName", "CarPark.User")
    .Enrich.WithMachineName()
    .CreateLogger();

// Use Serilog for the application
builder.Host.UseSerilog();



// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddLocalization(opt => { opt.ResourcesPath = "Resources"; });
builder.Services.Configure<RequestLocalizationOptions>(opt => {
    var supportedCultures = new List<CultureInfo>
    {
        new CultureInfo("en-US"),
        new CultureInfo("tr-TR"),
        new CultureInfo("gr-GR")
    };

    opt.DefaultRequestCulture = new RequestCulture("tr-TR");
    opt.SupportedCultures = supportedCultures;
    opt.SupportedUICultures = supportedCultures;

    opt.RequestCultureProviders = new List<IRequestCultureProvider>
    {
        new QueryStringRequestCultureProvider(),
        new CookieRequestCultureProvider(),
        new AcceptLanguageHeaderRequestCultureProvider(),
    };

    //opt.RequestCultureProviders = new[] {new RouteDataRequestCultureProvider()
    //{
    //    Options = opt

    //} };
});

builder.Services.AddMvc()
    .AddViewLocalization()
    .AddDataAnnotationsLocalization(
    options =>options.DataAnnotationLocalizerProvider = (type, factory) =>
    {
        var assemblyName = new AssemblyName(typeof(SharedModelResource).Assembly.FullName);
        return factory.Create(nameof(SharedModelResource), assemblyName.Name);
    }
    );


builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
    option.DefaultSignInScheme = IdentityConstants.ExternalScheme;
})
.AddCookie(IdentityConstants.ApplicationScheme, options =>
 {
     options.LoginPath = "/Account/Login";
     options.AccessDeniedPath = "/Account/AccessDenied";
 });


builder.Services.AddIdentityCore<Employee>(options =>
{
    // 
})
.AddRoles<MongoIdentityRole>()
.AddMongoDbStores<Employee, MongoIdentityRole, Guid>(
    builder.Configuration.GetValue<string>("MongoDBConnection:ConnectionString"),
    builder.Configuration.GetValue<string>("MongoDBConnection:Database")
)
.AddSignInManager()
.AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

    options.LoginPath = "/Account/Login";
    options.SlidingExpiration = true;
});

builder.Services.Configure<MongoSettings>(builder.Configuration.GetSection("MongoDBConnection"));
builder.Services.AddScoped(typeof(IRepository<>), typeof(MongoRepositoryBase<>));
builder.Services.AddScoped<IEmployeeDataAccess , EmployeeDataAccess>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();


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

app.UseAuthentication();
app.UseAuthorization();

var options = app.Services.GetService<IOptions<RequestLocalizationOptions>>()?.Value;
if (options != null)
{
    app.UseRequestLocalization(options);
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
