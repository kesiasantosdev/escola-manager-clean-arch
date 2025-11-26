using EscolaManager.Domain.Entities;
using EscolaManager.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EscolaManager.Application.UseCases.Escolas.Commands.CriarEscola
{
    public class CriarEscolaCommandHandler : IRequestHandler<CriarEscolaCommand, Guid>
    {
        private readonly IEscolaRepository _escolaRepository;

        public CriarEscolaCommandHandler(IEscolaRepository escolaRepository)
        {
            _escolaRepository = escolaRepository;
        }

        public async Task<Guid> Handle(CriarEscolaCommand request, CancellationToken cancellationToken)
        {
            var escola = new Escola(request.NomeEscola, request.Cnpj);

            await _escolaRepository.AdicionarAsync(escola);

            return escola.Id;
        }
    }
}