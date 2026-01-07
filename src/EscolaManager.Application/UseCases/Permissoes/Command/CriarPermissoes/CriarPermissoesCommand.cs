using MediatR;

namespace EscolaManager.Application.UseCases.Permissoes.Command.CriarPermissoes
{
    public class CriarPermissoesCommand : IRequest<Guid>
    {
        public string NomePermissao { get; set; } = string.Empty;
    }
}
