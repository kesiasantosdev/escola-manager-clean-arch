using EscolaManager.Application.Services;
using EscolaManager.Domain.Entities;
using EscolaManager.Domain.Interfaces;
using MediatR;

namespace EscolaManager.Application.UseCases.Pessoas.Commands.CriarPessoa
{
    public class CriarPessoaCommandHandler : IRequestHandler<CriarPessoaCommand, Guid>
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IPasswordService _passwordService;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ICargoRepository _cargoRepository;

        public CriarPessoaCommandHandler(IPessoaRepository pessoaRepository, IPasswordService passwordService, IUsuarioRepository usuarioRepository, ICargoRepository cargoRepository)
        {
            _pessoaRepository = pessoaRepository;
            _passwordService = passwordService;
            _usuarioRepository = usuarioRepository;
            _cargoRepository = cargoRepository;
        }

        public async Task<Guid> Handle(CriarPessoaCommand request, CancellationToken cancellationToken)
        {
            var pessoa = new Pessoa(request.NomePessoa, request.Email, request.SenhaHash);

            await _pessoaRepository.AdicionarAsync(pessoa);

            var pessoaExistente = await _pessoaRepository.ObterPorEmailAsync(request.Email);

            if (pessoaExistente != null)
            {
                pessoa = pessoaExistente;
            }
            else
            {
                var senhaCriptografada = _passwordService.Hash(request.SenhaHash);
                pessoa = new Pessoa(request.NomePessoa, request.Email, senhaCriptografada);
                await _pessoaRepository.AdicionarAsync(pessoa);
            }


            var usuarioFuncionario = new Usuario(pessoa.Id, cargoFuncionario.Id);
            await _usuarioRepository.AdicionarAsync(usuarioFuncionario);

            return pessoa.Id;
        }
    }
}
