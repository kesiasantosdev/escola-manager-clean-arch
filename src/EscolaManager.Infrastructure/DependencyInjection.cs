using EscolaManager.Domain.Interfaces;
using EscolaManager.Infrastructure.Data;
using EscolaManager.Infrastructure.Repositories;
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
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ICargoRepository, CargoRepository>();
            services.AddScoped<IPermissaoRepository, PermissaoRepository>();

            services.AddScoped<ITipoPerguntaRepository, TipoPerguntaRepository>();
            services.AddScoped<ITipoRespostaRepository, TipoRespostaRepository>();
            services.AddScoped<IPerguntaRepository, PerguntaRepository>();
            services.AddScoped<IProvaRepository, ProvaRepository>();

            services.AddScoped<IBimestreRepository, BimestreRepository>();
            services.AddScoped<IRealizacaoProvaRepository, RealizacaoProvaRepository>();

            return services;
        }
    }
}