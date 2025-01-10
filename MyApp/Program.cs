using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using MyApp.Areas.Identity.Pages.Account;
using MyApp.ServiceInterface;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var config = builder.Configuration;
services.AddMvc();
services.AddControllersWithViews().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);
services.AddLocalization(option =>
{
    option.ResourcesPath = "Resources";
}
);
services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCulture = new[]
    {
        new CultureInfo("en-US"),
        new CultureInfo("pl-PL")
    };
}

);
services.AddRouting();
services.Configure<CookiePolicyOptions>(options =>
{
    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.Strict;
});

services.AddDatabaseDeveloperPageExceptionFilter();

services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    //options.User.AllowedUserNameCharacters = null;
    //options.SignIn.RequireConfirmedAccount = true;
})
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

services.Configure<ForwardedHeadersOptions>(options =>
{
    //https://github.com/aspnet/IISIntegration/issues/140#issuecomment-215135928
    options.ForwardedHeaders = ForwardedHeaders.XForwardedProto;
});

services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = false;
    options.Password.RequiredUniqueChars = 6;

    // Lockout settings
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
    options.Lockout.MaxFailedAccessAttempts = 10;
    options.Lockout.AllowedForNewUsers = true;

    // User settings
    options.User.RequireUniqueEmail = true;
});

services.ConfigureApplicationCookie(options =>
{
    // Cookie settings
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromDays(150);
    // If the LoginPath isn't set, ASP.NET Core defaults
    // the path to /Account/Login.
    options.LoginPath = "/Account/Login";
    // If the AccessDeniedPath isn't set, ASP.NET Core defaults
    // the path to /Account/AccessDenied.
    options.AccessDeniedPath = "/Account/AccessDenied";
    options.SlidingExpiration = true;
});

// Add application services.
services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();
// Uncomment to send emails with SMTP, configure SMTP with "SmtpConfig" in appsettings.json
//services.AddSingleton<IEmailSender<ApplicationUser>, EmailSender>();
services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, AdditionalUserClaimsPrincipalFactory>();

// Register all services
services.AddServiceStack(typeof(MyServices).Assembly);

var app = builder.Build();
app.UseRequestLocalization();
//builder.Services.AddLocalization(option => option.ResourcesPath = "Resources");
var supportedCultures = new[]
{
    new CultureInfo("en"),
    new CultureInfo("pl"),
    new CultureInfo("de")
};
/*
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en-US");
    options.SupportedCultures = suportedCultures;
    options.SupportedUICultures = suportedCultures;
    options.RequestCultureProviders = new List<IRequestCultureProvider>
    {
        new QueryStringRequestCultureProvider()
    };
}
);*/
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseHttpsRedirection();
}

app.UseStaticFiles();
app.UseCookiePolicy();
app.UseAuthentication();
/*
app.MapControllerRoute(
    name: "LinearEquations",

    pattern: "LinearEquations/{controller=Home}/{action=Index}/{id?}");
*/
//LinearEquations001.aspx
app.MapControllerRoute("SquareEquations", "SquareEquations", new { controller = "SquareEquations01", action = "Index" });
app.MapControllerRoute(
    name: "default",

    pattern: "{controller=Home}/{action=Index}/{id?}");
//app.MapControllerRoute("SquareEquations", "SquareEquations", new { controller = "SquareEquations01", action = "Index" });
app.MapRazorPages();

app.UseServiceStack(new AppHost(), options =>
{
    options.MapEndpoints();
});

app.Run();