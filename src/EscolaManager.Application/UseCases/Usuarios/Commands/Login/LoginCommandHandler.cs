using EscolaManager.Application.Interfaces;
using EscolaManager.Application.Services;
using EscolaManager.Domain.Interfaces;
using MediatR;

namespace EscolaManager.Application.UseCases.Usuarios.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginViewModel>
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IPasswordService _passwordService;
        private readonly ITokenService _tokenService;

        public LoginCommandHandler(
            IPessoaRepository pessoaRepository,
            IUsuarioRepository usuarioRepository,
            IPasswordService passwordService,
            ITokenService tokenService)
        {
            _pessoaRepository = pessoaRepository;
            _usuarioRepository = usuarioRepository;
            _passwordService = passwordService;
            _tokenService = tokenService;
        }

        public async Task<LoginViewModel> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var pessoa = await _pessoaRepository.ObterPorEmailAsync(request.Email);
            if (pessoa == null)
                throw new Exception("Usuário ou senha inválidos.");

            var senhaValida = _passwordService.Verify(request.Senha, pessoa.SenhaHash);
            if (!senhaValida)
                throw new Exception("Usuário ou senha inválidos.");

            var usuario = await _usuarioRepository.ObterPorPessoaIdAsync(pessoa.Id);
            if (usuario == null)
                throw new Exception("Esta pessoa não tem vínculo ativo com nenhuma escola.");

            var token = _tokenService.GerarToken(usuario, usuario.Cargo?.NomeCargo ?? "Sem Cargo", pessoa.Email);

            return new LoginViewModel(usuario.Id, pessoa.NomePessoa, pessoa.Email, token);
        }
    }
}