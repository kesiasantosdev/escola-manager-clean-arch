using MediatR;
using System;
using System.Text.Json.Serialization;

namespace EscolaManager.Application.UseCases.Escolas.Commands.AlterarEscola
{
    public class AlterarEscolaCommand : IRequest<Unit>
    {
        [JsonIgnore]
        public Guid Id { get; set; }

        public string NomeEscola { get; set; } = string.Empty;
        public string? EmailEscola { get; set; }
        public string? TelefoneEscola { get; set; }
        public string? Cep { get; set; }
        public string? Logradouro { get; set; }
        public string? Numero { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
    }
}