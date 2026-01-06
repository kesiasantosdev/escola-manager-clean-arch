using MediatR;
using System.Text.Json.Serialization;

namespace EscolaManager.Application.UseCases.Cargos.Command.DeletarCargos
{
    public class DeletarCargoCommand : IRequest<bool>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
    }
}
