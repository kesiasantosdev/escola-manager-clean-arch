using EscolaManager.Application.Services;
using EscolaManager.Domain.Entities;
using EscolaManager.Domain.Interfaces;
using MediatR;

namespace EscolaManager.Application.UseCases.Escolas.Commands.CriarEscola
{
    public class CriarEscolaCommandHandler : IRequestHandler<CriarEscolaCommand, Guid>
    {
        private readonly IEscolaRepository _escolaRepository;
        private readonly ICargoRepository _cargoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IPasswordService _passwordService;

        public CriarEscolaCommandHandler(
            IEscolaRepository escolaRepository,
            ICargoRepository cargoRepository,
            IUsuarioRepository usuarioRepository,
            IPasswordService passwordService)
        {
            _escolaRepository = escolaRepository;
            _cargoRepository = cargoRepository;
            _usuarioRepository = usuarioRepository;
            _passwordService = passwordService;
        }

        public async Task<Guid> Handle(CriarEscolaCommand request, CancellationToken cancellationToken)
        {
            var escola = new Escola(request.NomeEscola, request.Cnpj, request.EmailEscola, request.TelefoneEscola, request.Cep, request.Logradouro, request.Numero, request.Bairro, request.Cidade, request.Estado);
            await _escolaRepository.AdicionarAsync(escola);

            var cargoGestao = new Cargo("Gestão", escola.Id);
            await _cargoRepository.AdicionarAsync(cargoGestao);

            var usuarioExistente = await _usuarioRepository.ObterPorEmailAsync(request.EmailGerente);

            if (usuarioExistente == null)
            {
                var senhaCriptografada = _passwordService.Hash(request.SenhaInicialGerente);

                var novoGerente = new Usuario(
                    request.NomeGerente,
                    request.EmailGerente,
                    senhaCriptografada,
                    escola.Id,
                    cargoGestao.Id
                );

                await _usuarioRepository.AdicionarAsync(novoGerente);
            }

            return escola.Id;
        }
    }
}