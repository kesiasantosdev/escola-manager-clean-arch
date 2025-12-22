using EscolaManager.Domain.Interfaces;
using MediatR;

namespace EscolaManager.Application.UseCases.Usuarios.Commands.DeletarUsuario
{
    public class DeletarUsuarioCommandHandler : IRequestHandler<DeletarUsuarioCommand, bool>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public DeletarUsuarioCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<bool> Handle(DeletarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.ObterPorIdAsync(request.Id);

            if (usuario == null)
            {
                return false;
            }

            await _usuarioRepository.DeletarAsync(usuario);

            return true;
        }
    }
}
