using MediatR;
using System.Text.Json.Serialization;

namespace EscolaManager.Application.UseCases.Cargos.Command.AtualizarCargos
{
    public class AtualizarCargoCommand : IRequest<bool>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string novoNome { get; set; } = string.Empty;

    }
}
