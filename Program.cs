using EventManageApp.Core.Common;
using EventManageApp.Core.Configurations;
using EventManageApp.Data.Context;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
    options.UseSqlServer(connectionString);
});


ServiceConfiguration.ConfigureServices(builder.Services);

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
app.UseSession();
app.UseMiddleware<ExceptionHandler>();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


app.MapGet("/Account/Logout", async context =>
{
    await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    context.Response.Redirect("/Index");
});

app.MapRazorPages();
app.Run();
