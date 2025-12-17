namespace EscolaManager.Application.UseCases.Usuarios.Commands.Login
{
    public record LoginViewModel(
        Guid UsuarioId,
        string Nome,
        string Email,
        string Token
    );
}