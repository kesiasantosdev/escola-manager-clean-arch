using EscolaManager.Application.Gateways;
using EscolaManager.Application.Interfaces;
using EscolaManager.Application.Services;
using EscolaManager.Domain.Interfaces;
using EscolaManager.Infrastructure.Data;
using EscolaManager.Infrastructure.Repositories;
using EscolaManager.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EscolaManager.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<EscolaDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IEscolaRepository, EscolaRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ICargoRepository, CargoRepository>();
            services.AddScoped<IPermissaoRepository, PermissaoRepository>();

            services.AddScoped<ITipoPerguntaRepository, TipoPerguntaRepository>();
            services.AddScoped<ITipoRespostaRepository, TipoRespostaRepository>();
            services.AddScoped<IPerguntaRepository, PerguntaRepository>();
            services.AddScoped<IProvaRepository, ProvaRepository>();

            services.AddScoped<IBimestreRepository, BimestreRepository>();
            services.AddScoped<IRealizacaoProvaRepository, RealizacaoProvaRepository>();

            services.AddHttpClient<ICnpjService, BrasilApiService>();
            services.AddScoped<IPasswordService, PasswordService>();
            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }
}