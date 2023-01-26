using Microsoft.EntityFrameworkCore;
using MatiasProject.Models.Domain;
using MatiasProject.Repositories.Abstract;
using MatiasProject.Repositories.Implementation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DatabaseContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("connstr")));

builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("connstr")));

//Dodanie us³ugi
builder.Services.AddScoped<IGatunekService, GatunekService>();
builder.Services.AddScoped<IAutorService, AutorService>();
builder.Services.AddScoped<IWydawnictwoService, WydawnictwoService>();
builder.Services.AddScoped<IBookService, BookService>();
//Dla autoryzacji
builder.Services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();    
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<DatabaseContext>()
    .AddDefaultTokenProviders();
builder.Services.ConfigureApplicationCookie(op => op.LoginPath = "/UserAuthentication/Login");
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
    pattern: "{controller=Book}/{action=GetAll}/{id?}");

app.Run();
