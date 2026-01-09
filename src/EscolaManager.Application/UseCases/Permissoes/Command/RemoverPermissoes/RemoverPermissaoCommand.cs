using MediatR;
using System.Text.Json.Serialization;

namespace EscolaManager.Application.UseCases.Permissoes.Command.RemoverPermissoes
{
    public class RemoverPermissaoCommand : IRequest<Guid>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public Guid CargoId { get; set; }
        public Guid PermissaoId { get; set; }
    }
}
