using MediatR;
using System;

namespace EscolaManager.Application.UseCases.Escolas.Commands.CriarEscola
{
    public class CriarEscolaCommand : IRequest<Guid>
    {
        public string NomeEscola { get; set; } = string.Empty;
        public string Cnpj { get; set; } = string.Empty;

        public string? Logradouro { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }

        public string NomeGerente { get; set; } = string.Empty;
        public string EmailGerente { get; set; } = string.Empty;
        public string SenhaInicialGerente { get; set; } = string.Empty;
    }
}