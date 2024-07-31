using BooksReviewApp.Core.Services.Interfaces;
using BooksReviewApp.Database.Extensions;
using BooksReviewApp.Services.EF.Interfaces;
using BooksReviewApp.Services.EF.Services;
using BooksReviewApp.WebApi.Extensions;
using BooksReviewApp.WebApi.Interfaces;
using BooksReviewApp.WebApi.Middlewares;
using BooksReviewApp.WebApi.Options;
using BooksReviewApp.WebApi.Services;
using Microsoft.Extensions.Configuration;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .WriteTo.Console()
    .WriteTo.File("Logs/app.log", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers();
builder.Services.AddCustomDbContext(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddCustomSwagger();
builder.Services.AddHttpContextAccessor();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IUserDbService, UserDbService>();
builder.Services.AddScoped<IGenreDbService, GenreDbService>();

builder.Services.AddOptions<Localization>().Bind(builder.Configuration.GetSection("Localization")).ValidateDataAnnotations();

builder.Services.AddMemoryCache();
builder.Services.AddSingleton<ILocalizationService, LocalizationService>();

builder.Services.AddExceptionHandlers();
builder.Services.AddValidators();

var app = builder.Build();

app.UseCustomSwagger();

app.UseHttpsRedirection();

var exceptionHandlers = app.Services.GetRequiredService<Dictionary<Type, IExceptionHandler>>();
app.UseMiddleware<ExceptionHandlingMiddleware>(exceptionHandlers);

app.UseAuthorization();

app.MapControllers();

app.Run();
