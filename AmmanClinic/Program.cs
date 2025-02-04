using AmmanClinic.data;
using AmmanClinic.Services;
using Microsoft.AspNetCore.Identity;
using AmmanClinic.data;
using AmmanClinic.Services;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. (dependance injection container) or (injector)
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddDbContext<ClinicContext>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ClinicContext>();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 3;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireDigit = false;
});

builder.Services.ConfigureApplicationCookie(config =>
{
    config.LoginPath = "/Account/SignIn";
    config.ExpireTimeSpan = TimeSpan.FromDays(10);
});

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



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=SignIn}/{id?}");





app.Run();
