using MediatR;

namespace EscolaManager.Application.UseCases.Permissoes.Command.AtribuirPermissoes
{
    public class AtribuirPermissaoCommand : IRequest<Guid>
    {
        public Guid CargoId { get; set; }
        public Guid PermissaoId { get; set; }
    }
}
