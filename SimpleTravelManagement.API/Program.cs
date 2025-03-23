using SimpleTravelManagement.Application;
using SimpleTravelManagement.Infrastructure;
using SimpleTravelManagement.Shared;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddShared();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(configuration);



builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseShared();

app.UseAuthorization();

app.MapControllers();

app.Run();
