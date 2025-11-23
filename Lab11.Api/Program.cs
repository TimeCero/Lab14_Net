using Lab11.Infrastructure.Models;
using Lab11.Infrastructure.UnitOfWork;
using Lab11.Domain.Interfaces;
using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Connection string en appsettings.json -> DefaultConnection
var conn = builder.Configuration.GetConnectionString("DefaultConnection");

// DbContext (lee connection string en appsettings.json)
builder.Services.AddDbContext<DbLab08Context>(options =>
    options.UseMySql(conn, ServerVersion.AutoDetect(conn))
);

// Registrar UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Registrar MediatR (Application assembly)
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Lab11.Application.ApplicationAssemblyMarker).Assembly));

// Registrar AutoMapper (Application assembly)
builder.Services.AddAutoMapper(typeof(Lab11.Application.ApplicationAssemblyMarker).Assembly);

// Swagger / OpenAPI (si tienes extensión)
builder.Services.AddOpenApi();

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();