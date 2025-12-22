using MediatR;
using System.Text.Json.Serialization;

namespace EscolaManager.Application.UseCases.Usuarios.Commands.AtualizarPessoa
{
    public class AtualizarUsuarioCommand : IRequest<bool>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string NovoNome { get; set; } = string.Empty;
        public string AtualizarSenhaFuncionario { get; set; } = string.Empty;
        public Guid CargoId { get; set; }

    }
}
