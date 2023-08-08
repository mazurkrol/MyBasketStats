using MyBasketStats.API;
using MyBasketStats.API.Models;
using Microsoft.AspNetCore.StaticFiles;
using Newtonsoft.Json;
using Serilog;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Reflection;
using Microsoft.OpenApi.Models;
using MyBasketStats.API.DbContexts;
using MyBasketStats.API.Services.TeamServices;
using MyBasketStats.API.Services.PlayerServices;
using MyBasketStats.API.Services.StatsheetServices;
using MyBasketStats.API.Services.SeasonServices;
using MyBasketStats.API.Services.GameServices;
using MyBasketStats.API.Services.Basic;
using MyBasketStats.API.Entities;
using MyBasketStats.API.Services.GameClockServices;
using MyBasketStats.API.Services.DictionaryServices;
using MyBasketStats.API.Services.BackgroundClockServices;
using MyBasketStats.API.Services.BackgroundServicesManager;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/mybasketstats.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();
var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();
// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true;
}).AddNewtonsoftJson()
.AddXmlDataContractSerializerFormatters();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<FileExtensionContentTypeProvider>();
builder.Services.AddSingleton<BackgroundClockService>();
builder.Services.AddScoped<IBackgroundServiceManager, BackgroundServiceManager>();
builder.Services.AddScoped<IGameClockService, GameClockService>();
builder.Services.AddScoped<IGameClockRepository, GameClockRepository>();
builder.Services.AddSingleton<IDictionaryService, DictionaryService>();
builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<ITeamRepository, TeamRepository>();
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddScoped<IStatsheetService, StatsheetService>();
builder.Services.AddScoped<IStatsheetRepository, StatsheetRepository>();
builder.Services.AddScoped<ISeasonService, SeasonService>();
builder.Services.AddScoped<ISeasonRepository, SeasonRepository>();
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<IBasicRepository<Player>, BasicRepository<Player>>();
builder.Services.AddScoped<IBasicRepository<Team>, BasicRepository<Team>>();
builder.Services.AddScoped<IBasicRepository<Statsheet>, BasicRepository<Statsheet>>();
builder.Services.AddScoped<IBasicRepository<Season>, BasicRepository<Season>>();
builder.Services.AddScoped<IBasicRepository<Game>, BasicRepository<Game>>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<MyBasketStatsContext>(options =>
    options.UseSqlServer(builder.Configuration["ConnectionStrings:MyBasketStatsDBConnectionString"]));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
