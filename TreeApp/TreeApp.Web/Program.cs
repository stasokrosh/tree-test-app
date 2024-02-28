using TreeApp.DB.Config;
using TreeApp.Web.Config;
using TreeApp.Web.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddDBConfig();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddWebApp(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<SecureExceptionMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
