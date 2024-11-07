using EventManageApp.Core.Services;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace EventManageApp.Core.Configurations
{
    public static class ServiceConfiguration
    {

        public static void ConfigureServices(IServiceCollection services)
        {
            // Session configuration
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            // Cookies configuration
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                            .AddCookie(options =>
                            {
                                options.LoginPath = "/Auth/Login";
                                options.AccessDeniedPath = "/AccessDenied";
                                options.LogoutPath = "/Account/Logout";
                                options.ExpireTimeSpan = TimeSpan.FromHours(8);
                                options.SlidingExpiration = false;
                                options.Cookie.HttpOnly = true;
                                options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                            });

            // Add auth policy
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
                options.AddPolicy("UserOnly", policy => policy.RequireRole("User"));
            });

            services.AddScoped<AuthService>();
            services.AddScoped<EventService>();
        }
    }
}