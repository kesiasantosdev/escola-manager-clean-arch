using MediatR;
using System.Text.Json.Serialization;

namespace EscolaManager.Application.UseCases.Permissoes.Command.DeletarPermissoes
{
    public class DeletarPermissaoCommand : IRequest<bool>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
    }
}
