using BooksReviewApp.Core.Services.Interfaces;
using BooksReviewApp.Database.Extensions;
using BooksReviewApp.Services.EF;
using BooksReviewApp.Services.EF.Interfaces;
using BooksReviewApp.WebApi.Extensions;
using BooksReviewApp.WebApi.Handlers;
using BooksReviewApp.WebApi.Interfaces;
using BooksReviewApp.WebApi.Middlewares;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .WriteTo.Console()
    .WriteTo.File("Logs/app.log", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

// Add services to the container.

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers();
builder.Services.AddCustomDbContext(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddCustomSwagger();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IUserDbService, UserDbService>();
builder.Services.AddScoped<IGenreDbService, GenreDbService>();
builder.Services.AddTransient<IExceptionHandler, NpgsqlExceptionHandler>();
builder.Services.AddTransient<IExceptionHandler, ValidationExceptionHandler>();

var app = builder.Build();

app.UseCustomSwagger();

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
