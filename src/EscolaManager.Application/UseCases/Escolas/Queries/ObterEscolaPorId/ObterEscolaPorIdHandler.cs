using EscolaManager.Domain.Interfaces;
using MediatR;

namespace EscolaManager.Application.UseCases.Escolas.Queries.ObterEscolaPorId
{
    public class ObterEscolaPorIdHandler : IRequestHandler<ObterEscolaPorIdQuery, EscolaViewModel?>
    {
        private readonly IEscolaRepository _repository;

        public ObterEscolaPorIdHandler(IEscolaRepository repository)
        {
            _repository = repository;
        }

        public async Task<EscolaViewModel?> Handle(ObterEscolaPorIdQuery request, CancellationToken cancellationToken)
        {
            var escola = await _repository.ObterPorIdAsync(request.Id);

            if (escola == null) return null;

            var gerente = await _repository.ObterResponsavelPelaEscolaAsync(request.Id);

            var viewModel = EscolaViewModel.FromEntity(escola);

            if (gerente != null)
            {
                viewModel.NomeGerente = gerente.NomePessoa;
                viewModel.EmailGerente = gerente.Email;
            }

            return viewModel;
        }
    }
}