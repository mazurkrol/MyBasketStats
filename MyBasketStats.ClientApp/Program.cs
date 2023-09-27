using Microsoft.Extensions.Hosting;
using MyBasketStats.Client;
using MyBasketStats.ClientApp.Helpers;
using MyBasketStats.ClientApp.Services;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddLogging(configure => configure.AddDebug().AddConsole());

builder.Services.AddHttpClient<MyBasketStatsAPIClient>();

builder.Services.AddSingleton<JsonSerializerOptionsWrapper>();
builder.Services.AddScoped<IGameService,GameService>();
builder.Services.AddControllersWithViews();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();

