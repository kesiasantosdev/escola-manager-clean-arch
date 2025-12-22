using EscolaManager.Application.Interfaces;
using EscolaManager.Application.Services;
using EscolaManager.Domain.Interfaces;
using MediatR;

namespace EscolaManager.Application.UseCases.Usuarios.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginViewModel>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IPasswordService _passwordService;
        private readonly ITokenService _tokenService;

        public LoginCommandHandler(
            IUsuarioRepository usuarioRepository,
            IPasswordService passwordService,
            ITokenService tokenService)
        {
            _usuarioRepository = usuarioRepository;
            _passwordService = passwordService;
            _tokenService = tokenService;
        }

        public async Task<LoginViewModel> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.ObterPorEmailAsync(request.Email);

            if (usuario == null)
                throw new Exception("Usuário ou senha inválidos.");

            var senhaValida = _passwordService.Verify(request.Senha, usuario.SenhaHash);
            if (!senhaValida)
                throw new Exception("Usuário ou senha inválidos.");

            var token = _tokenService.GerarToken(usuario, usuario.Cargo?.NomeCargo ?? "Sem Cargo", usuario.Email);

            return new LoginViewModel(usuario.Id, usuario.NomePessoa, usuario.Email, token, usuario.Cargo?.NomeCargo ?? "Sem Cargo");
        }
    }
}