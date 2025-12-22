namespace EscolaManager.Application.UseCases.Usuarios.Queries
{
    public record UsuarioViewModel(
        Guid Id,
        string Nome,
        string Email,
        string NomeEscola,
        string NomeCargo
    );
}