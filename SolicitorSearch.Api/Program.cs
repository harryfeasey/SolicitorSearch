var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpClient();

builder.Services.AddScoped<ISolicitorService, SolicitorService>();
builder.Services.AddScoped<ISolicitorParser, SolicitorParser>();
builder.Services.AddScoped<ISolicitorScraper, SolicitorScraper>();

var app = builder.Build();

app.MapControllers();

app.Run();
