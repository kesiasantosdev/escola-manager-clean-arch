using EscolaManager.Domain.Entities;
using EscolaManager.Domain.Interfaces;
using MediatR;

namespace EscolaManager.Application.UseCases.Escolas.Commands.CriarEscola
{
    public class CriarEscolaCommandHandler : IRequestHandler<CriarEscolaCommand, Guid>
    {
        private readonly IEscolaRepository _escolaRepository;
        private readonly IPessoaRepository _pessoaRepository;
        private readonly ICargoRepository _cargoRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public CriarEscolaCommandHandler(
            IEscolaRepository escolaRepository,
            IPessoaRepository pessoaRepository,
            ICargoRepository cargoRepository,
            IUsuarioRepository usuarioRepository)
        {
            _escolaRepository = escolaRepository;
            _pessoaRepository = pessoaRepository;
            _cargoRepository = cargoRepository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Guid> Handle(CriarEscolaCommand request, CancellationToken cancellationToken)
        {
            var escola = new Escola(
                request.NomeEscola,
                request.Cnpj,
                request.EmailEscola,
                request.TelefoneEscola,
                request.Cep,
                request.Logradouro,
                request.Numero,
                request.Bairro,
                request.Cidade,
                request.Estado
            );

            await _escolaRepository.AdicionarAsync(escola);

            Pessoa gerente;

            var pessoaExistente = await _pessoaRepository.ObterPorEmailAsync(request.EmailGerente);

            if (pessoaExistente != null)
            {
                gerente = pessoaExistente;
            }
            else
            {
                var senhaSegura = $"HASH_{request.SenhaInicialGerente}";
                gerente = new Pessoa(request.NomeGerente, request.EmailGerente, senhaSegura);
                await _pessoaRepository.AdicionarAsync(gerente);
            }

            var cargoGestao = new Cargo("Gestão", escola.Id);
            await _cargoRepository.AdicionarAsync(cargoGestao);

            var usuarioGerente = new Usuario(gerente.Id, escola.Id, cargoGestao.Id);
            await _usuarioRepository.AdicionarAsync(usuarioGerente);

            return escola.Id;
        }
    }
}