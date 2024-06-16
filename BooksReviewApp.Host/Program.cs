using BooksReviewApp.Database.Extensions;
using BooksReviewApp.Services.EF;
using BooksReviewApp.Services.EF.Interfaces;
using BooksReviewApp.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers();
builder.Services.AddCustomDbContext(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddCustomSwagger();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IUserDbService, UserDbService>();
builder.Services.AddScoped<IGenreDbService, GenreDbService>();

var app = builder.Build();

app.UseCustomSwagger();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
