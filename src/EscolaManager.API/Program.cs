using EscolaManager.Application;
using EscolaManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
builder.Services.AddDbContext<EscolaDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddMediatR(cfg => 
{
    // Usa o tipo de alguma classe na camada Application para obter o Assembly
    cfg.RegisterServicesFromAssembly(typeof(ApplicationAssemblyReference).Assembly); 
});

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

app.UseAuthorization();

app.MapControllers();

app.Run();
