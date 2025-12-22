using MediatR;

namespace EscolaManager.Application.UseCases.Usuarios.Commands.CriarUsuario
{
    public class CriarUsuarioCommand : IRequest<Guid>
    {
        public string NomePessoa { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string SenhaInicialFuncionario { get; set; } = string.Empty;
        public Guid EscolaId { get; set; }
        public Guid CargoId { get; set; }
    }
}
