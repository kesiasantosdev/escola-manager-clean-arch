using EscolaManager.Application.Services;
using EscolaManager.Domain.Entities;
using EscolaManager.Domain.Interfaces;
using MediatR;

namespace EscolaManager.Application.UseCases.Usuarios.Commands.CriarUsuario
{
    public class CriarUsuarioCommandHandler : IRequestHandler<CriarUsuarioCommand, Guid>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IPasswordService _passwordService;

        public CriarUsuarioCommandHandler(IUsuarioRepository usuarioRepository, IPasswordService passwordService)
        {
            _usuarioRepository = usuarioRepository;
            _passwordService = passwordService;
        }

        public async Task<Guid> Handle(CriarUsuarioCommand request, CancellationToken cancellationToken)
        {

            var usuarioExistente = await _usuarioRepository.ObterPorEmailAsync(request.Email);
            if (usuarioExistente != null) return usuarioExistente.Id;

            var senhaCriptografada = _passwordService.Hash(request.SenhaInicialFuncionario);

            var usuario = new Usuario(
                request.NomePessoa,
                request.Email,
                senhaCriptografada,
                request.EscolaId,
                request.CargoId
            );

            await _usuarioRepository.AdicionarAsync(usuario);

            return usuario.Id;
        }
    }
}
