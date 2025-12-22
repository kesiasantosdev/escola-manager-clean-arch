using MediatR;

namespace EscolaManager.Application.UseCases.Usuarios.Queries.ObterUsuarioPorId
{
    public record ObterUsuarioPorIdQuery(Guid Id) : IRequest<UsuarioViewModel?>;
}