using BooksReviewApp.Database.Extensions;
using BooksReviewApp.Services.EF.Interfaces;
using BooksReviewApp.Services.EF.Services;
using BooksReviewApp.WebApi.Extensions;
using BooksReviewApp.WebApi.Handlers;
using BooksReviewApp.WebApi.Middlewares;
using BooksReviewApp.WebApi.Models;
using BooksReviewApp.WebApi.Options;
using BooksReviewApp.WebApi.Services;
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

var localizationSection = builder.Configuration.GetSection("Localization");

builder.Services.AddOptions<Localization>()
    .Bind(localizationSection)
    .ValidateDataAnnotations()
    .ValidateOnStart();

var validationMessagesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, localizationSection.GetValue<string>("ValidationMessagesPath"));
builder.Configuration.AddJsonFile(validationMessagesPath, optional: false, reloadOnChange: true);
builder.Services.Configure<ValidationMessages>(builder.Configuration.GetSection("ValidationMessages"));

builder.Services.AddSingleton<ILocalizationService, LocalizationService>();
builder.Services.AddExceptionHandlers();
builder.Services.AddValidators();

var app = builder.Build();

app.UseSerilogRequestLogging();

app.UseCustomSwagger();

app.UseHttpsRedirection();

var exceptionHandlers = app.Services.GetRequiredService<Dictionary<Type, IExceptionHandler>>();
app.UseMiddleware<ExceptionHandlingMiddleware>(exceptionHandlers);

app.UseAuthorization();

app.MapControllers();

app.Run();
