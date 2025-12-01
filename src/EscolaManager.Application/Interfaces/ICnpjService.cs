namespace EscolaManager.Application.Gateways
{
    public record DadosCnpjResponse(
        string NomeOficial,
        string Logradouro,
        string Numero,
        string Bairro,
        string Cidade,
        string Estado,
        string Cep,
        string Telefone,
        string Email
    );

    public interface ICnpjService
    {
        Task<DadosCnpjResponse?> BuscarDadosCnpjAsync(string cnpj);
    }
}