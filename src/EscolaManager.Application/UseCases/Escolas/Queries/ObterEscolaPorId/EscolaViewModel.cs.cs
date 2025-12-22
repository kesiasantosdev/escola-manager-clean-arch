using EscolaManager.Domain.Entities;

namespace EscolaManager.Application.UseCases.Escolas.Queries.ObterEscolaPorId
{
    public record EscolaViewModel(
        Guid Id,
        string NomeEscola,
        string Cnpj,
        string? Email,
        string? Telefone,
        string? Cep,
        string? Rua,
        string? Numero,
        string? Bairro,
        string? Cidade,
        string? Estado,
        string Status
    )
    {

        public string? NomeGerente { get; set; }
        public string? EmailGerente { get; set; }


        public static EscolaViewModel FromEntity(Escola escola)
        {
            return new EscolaViewModel(
                escola.Id,
                escola.NomeEscola,
                escola.Cnpj,
                escola.Email,
                escola.Telefone,
                escola.Cep,
                escola.Rua,
                escola.Numero,
                escola.Bairro,
                escola.Cidade,
                escola.Estado,
                escola.Status.ToString()
            );
        }
    }
}