using EscolaManager.Domain.Interfaces;
using MediatR;

namespace EscolaManager.Application.UseCases.Usuarios.Queries.ObterTodosUsuarios
{
    public class ObterTodosUsuariosQueryHandler : IRequestHandler<ObterTodosUsuariosQuery, IEnumerable<UsuarioViewModel>>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public ObterTodosUsuariosQueryHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IEnumerable<UsuarioViewModel>> Handle(ObterTodosUsuariosQuery request, CancellationToken cancellationToken)
        {
            var usuarios = await _usuarioRepository.ObterTodosAsync();

            return usuarios.Select(u => new UsuarioViewModel(
                u.Id,
                u.NomePessoa,
                u.Email,
                u.Escola?.NomeEscola ?? "Sem Escola",
                u.Cargo?.NomeCargo ?? "Sem Cargo"
            ));
        }
    }
}
