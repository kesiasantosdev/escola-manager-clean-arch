using EscolaManager.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace EscolaManager.Application.UseCases.Escolas.Commands.AlterarEscola
{
    public class AlterarEscolaCommandHandler : IRequestHandler<AlterarEscolaCommand, Unit>
    {
        private readonly IEscolaRepository _repository;

        public AlterarEscolaCommandHandler(IEscolaRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(AlterarEscolaCommand request, CancellationToken cancellationToken)
        {
            var escola = await _repository.ObterPorIdAsync(request.Id);

            if (escola == null)
            {
                throw new Exception("Escola não encontrada.");
            }

            escola.AtualizarDados(
                request.NomeEscola,
                request.EmailEscola,
                request.TelefoneEscola,
                request.Cep,
                request.Logradouro,
                request.Numero,
                request.Bairro,
                request.Cidade,
                request.Estado
            );

            await _repository.AtualizarAsync(escola);

            return Unit.Value;
        }
    }
}