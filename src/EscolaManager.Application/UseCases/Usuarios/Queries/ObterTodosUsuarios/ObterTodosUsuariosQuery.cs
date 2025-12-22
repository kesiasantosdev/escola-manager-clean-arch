using MediatR;

namespace EscolaManager.Application.UseCases.Usuarios.Queries.ObterTodosUsuarios
{
    public record ObterTodosUsuariosQuery() : IRequest<IEnumerable<UsuarioViewModel>>;
}