using MediatR;

namespace EscolaManager.Application.UseCases.Permissoes.Command.CriarPermissoes
{
    public class CriarPermissaoCommand : IRequest<Guid>
    {
        public string NomePermissao { get; set; } = string.Empty;
    }
}
