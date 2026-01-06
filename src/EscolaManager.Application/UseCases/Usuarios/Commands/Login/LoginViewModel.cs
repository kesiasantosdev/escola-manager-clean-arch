namespace EscolaManager.Application.UseCases.Usuarios.Commands.Login
{
    public record LoginViewModel(
        Guid UsuarioId,
        Guid EscolaId,
        string Nome,
        string Email,
        string Token,
        string CargoNome
    );
}