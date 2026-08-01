var builder = WebApplication.CreateBuilder(args);
var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpClient();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy  =>
                      {
                          policy.WithOrigins("http://localhost:4200");
                      });
});

builder.Services.AddScoped<ISolicitorService, SolicitorService>();
builder.Services.AddScoped<ISolicitorParser, SolicitorParser>();
builder.Services.AddScoped<ISolicitorScraper, SolicitorScraper>();

var app = builder.Build();
app.UseCors(MyAllowSpecificOrigins);

app.MapControllers();

app.Run();
