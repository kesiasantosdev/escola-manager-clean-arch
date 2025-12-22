using EscolaManager.Application.Services;
using EscolaManager.Domain.Interfaces;
using MediatR;

namespace EscolaManager.Application.UseCases.Usuarios.Commands.AtualizarPessoa
{
    public class AtualizarUsuarioCommandHandler : IRequestHandler<AtualizarUsuarioCommand, bool>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ICargoRepository _cargoRepository;
        private readonly IPasswordService _passwordService;

        public AtualizarUsuarioCommandHandler(IUsuarioRepository usuarioRepository, ICargoRepository cargoRepository, IPasswordService passwordService)
        {
            _usuarioRepository = usuarioRepository;
            _cargoRepository = cargoRepository;
            _passwordService = passwordService;
        }

        public async Task<bool> Handle(AtualizarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.ObterPorIdAsync(request.Id);

            if (usuario == null)
            {
                return false;
            }
            var senhaCriptografada = _passwordService.Hash(request.AtualizarSenhaFuncionario);
            usuario.CorrigirNome(request.NovoNome);

            usuario.AlterarSenha(senhaCriptografada);

            var cargoExiste = await _cargoRepository.ObterPorIdAsync(request.CargoId);
            if (cargoExiste == null) return false;

            usuario.AlterarCargo(request.CargoId);

            await _usuarioRepository.AtualizarAsync(usuario);

            return true;
        }
    }
}
