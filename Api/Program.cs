using System.Reflection;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Skinet.Api;
using Skinet.Core.Interfaces;
using Skinet.Infrastructure.Data;
using Skinet.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddScoped<IProductsRepository, ProductsRepository>()
    .AddScoped<IProductBrandsRepository, ProductBrandsRepository>()
    .AddScoped<IProductTypesRepository, ProductTypesRepository>();

// Automapper
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// EntityFrameworkCore
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<StoreDbContext>(opt =>
{
    opt.UseSqlServer(connectionString);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    await app.ApplyMigrations();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
