using MediatR;
using System.Text.Json.Serialization;

namespace EscolaManager.Application.UseCases.Permissoes.Command.AtualizarPermissoes
{
    public class AtualizarPermissaoCommand : IRequest<bool>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string AlterarPermissao { get; set; } = string.Empty;
    }
}
