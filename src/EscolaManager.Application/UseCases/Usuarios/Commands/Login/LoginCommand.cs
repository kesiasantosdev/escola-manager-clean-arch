using MediatR;

namespace EscolaManager.Application.UseCases.Usuarios.Commands.Login
{
    public class LoginCommand : IRequest<LoginViewModel>
    {
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
    }
}