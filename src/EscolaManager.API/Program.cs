using EscolaManager.Application;
using EscolaManager.Application.Behaviors;
using EscolaManager.Infrastructure;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirVue",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173") // O endereço do seu Front-end
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddMediatR(cfg =>
{
    // Usa o tipo de alguma classe na camada Application para obter o Assembly
    cfg.RegisterServicesFromAssembly(typeof(ApplicationAssemblyReference).Assembly);

    // Aqui ligamos o "Tubo de Validação"
    cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
});

builder.Services.AddValidatorsFromAssembly(typeof(ApplicationAssemblyReference).Assembly);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false, // Em dev pode ser false
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        // IMPORTANTE: A chave secreta tem que ser a mesma que você usou para GERAR o token no login
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MinhaChaveSuperSecretaDoSistemaEscolaManager123"))
    };
});

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

app.UseCors("PermitirVue");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
