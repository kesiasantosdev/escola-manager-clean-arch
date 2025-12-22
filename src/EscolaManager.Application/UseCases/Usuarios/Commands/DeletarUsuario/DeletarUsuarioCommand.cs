using MediatR;
using System.Text.Json.Serialization;

namespace EscolaManager.Application.UseCases.Usuarios.Commands.DeletarUsuario
{
    public class DeletarUsuarioCommand : IRequest<bool>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
    }
}
