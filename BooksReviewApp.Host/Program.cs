using BooksReviewApp.Database.Extensions;
using BooksReviewApp.Services.AspNet.Identity;
using BooksReviewApp.Services.Implementation.Application;
using BooksReviewApp.Services.Localization.Application;
using BooksReviewApp.WebApi.Extensions;
using BooksReviewApp.WebApi.Handlers;
using BooksReviewApp.WebApi.Middlewares;
using Identity.Domain.Entities;
using Identity.Database.Extensions;
using Serilog;
using BooksReviewApp.Services.Identity.AspNet.Extensions;
using Identity.Services.Implementation.Extensions;
using Identity.WebApi.Integration.Extensions;

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
builder.Services.AddIdentityDbContext(builder.Configuration.GetConnectionString("DefaultConnection"));

builder.Services.AddIdentityServices();
builder.Services.AddCustomIdentity<ApplicationUser, Role, AspIdentityDbContext>();
builder.Services.AddIdentityIntegrationServices();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdministratorRole", policy =>
        policy.RequireRole("Administrator"));
});

builder.Services.AddCustomSwagger();
builder.Services.AddHttpClient();
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

app.UseAuthentication();
app.UseAuthorization();

var exceptionHandlers = app.Services.GetRequiredService<Dictionary<Type, IExceptionHandler>>();
app.UseMiddleware<ExceptionHandlingMiddleware>(exceptionHandlers);

app.MapControllers();

app.Run();
