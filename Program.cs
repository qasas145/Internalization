using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddLocalization(options=>options.ResourcesPath = "Resources");
builder.Services.Configure<RequestLocalizationOptions>(options=>{
    var supportedCulturs = new [] {
        new CultureInfo("en-US"),
        new CultureInfo("ar-EG"),
    };
    options.SupportedCultures = supportedCulturs;
    options.SupportedUICultures = supportedCulturs;
    options.DefaultRequestCulture = new RequestCulture(culture : "en-US", uiCulture : "en-US");
});
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);
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
var locOptions = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(locOptions.Value);
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
