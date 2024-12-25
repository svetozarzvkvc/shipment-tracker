using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Filters;
using ShipmentTracker.API.Core;
using ShipmentTracker.Application;
using ShipmentTracker.Application.UseCases.Commands.Shipments;
using ShipmentTracker.Application.UseCases.Queries;
using ShipmentTracker.Domain;
using ShipmentTracker.Infrastructure;
using ShipmentTracker.Infrastructure.DataAccess;
using ShipmentTracker.Infrastructure.UseCases.Commands.Shipments;
using ShipmentTracker.Infrastructure.UseCases.Queries.Shipments;
using ShipmentTracker.Infrastructure.Validators;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("Logs/api-log-.txt", rollingInterval: RollingInterval.Day)
    .Filter.ByIncludingOnly(Matching.FromSource("ShipmentTracker"))
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "ShipmentTracker API",
        Version = "v1",
        Description = "API for tracking shipments in logistics"
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

builder.Services.AddSingleton<IDataStorage<Shipment>, InMemoryShipmentStorage>();
builder.Services.AddSingleton<InMemoryShipmentStorage>();
builder.Services.AddTransient<ICreateShipmentCommand, CreateShipmentCommand>();
builder.Services.AddTransient<UseCaseHandler>();
builder.Services.AddTransient<ISearchShipmentQuery, SearchShipmentQuery>();
builder.Services.AddTransient<IGetShipmentQuery, GetShipmentQuery>();
builder.Services.AddTransient<IUpdateShipmentCommand, UpdateShipmentCommand>();
builder.Services.AddTransient<IDeleteShipmentCommand, DeleteShipmentCommand>();
builder.Services.AddTransient<CreateShipmentDtoValidator>();
builder.Services.AddTransient<UpdateShipmentDtoValidator>();
var app = builder.Build();

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.UseCors(x =>
{
    x.AllowAnyOrigin();
    x.AllowAnyMethod();
    x.AllowAnyHeader();
});


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "ShipmentTracker API v1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
