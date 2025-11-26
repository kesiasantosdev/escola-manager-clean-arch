using MediatR;
using System;

namespace EscolaManager.Application.UseCases.Escolas.Commands.CriarEscola
{
    public class CriarEscolaCommand : IRequest<Guid>
    {
        public string NomeEscola { get; set; } = string.Empty;
        public string Cnpj { get; set; } = string.Empty;
    }
}