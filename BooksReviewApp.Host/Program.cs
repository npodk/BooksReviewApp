using BooksReviewApp.Database.Extensions;
using BooksReviewApp.Services.Implementation.Application;
using BooksReviewApp.Services.Localization.Application;
using BooksReviewApp.WebApi.Extensions;
using BooksReviewApp.WebApi.Handlers;
using BooksReviewApp.WebApi.Middlewares;
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

builder.Services.AddBusinessServices();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Configuration.AddLocalizationConfiguration(builder.Configuration);
builder.Services.AddCustomLocalization(builder.Configuration);

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
