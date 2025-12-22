using EscolaManager.Domain.Interfaces;
using MediatR;

namespace EscolaManager.Application.UseCases.Usuarios.Queries.ObterUsuarioPorId
{
    public class ObterUsuarioPorIdHandler : IRequestHandler<ObterUsuarioPorIdQuery, UsuarioViewModel?>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public ObterUsuarioPorIdHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<UsuarioViewModel?> Handle(ObterUsuarioPorIdQuery request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.ObterPorIdAsync(request.Id);

            if (usuario == null) return null;

            return new UsuarioViewModel(
                usuario.Id,
                usuario.NomePessoa,
                usuario.Email,
                usuario.Escola?.NomeEscola ?? "Sem Escola",
                usuario.Cargo?.NomeCargo ?? "Sem Cargo"
            );
        }
    }
}
