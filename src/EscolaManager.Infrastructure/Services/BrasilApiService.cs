using EscolaManager.Application.Gateways;
using System.Net.Http.Json;

namespace EscolaManager.Infrastructure.Services
{
    public class BrasilApiService : ICnpjService
    {
        private readonly HttpClient _httpClient;

        public BrasilApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<DadosCnpjResponse?> BuscarDadosCnpjAsync(string cnpj)
        {
            var cnpjLimpo = cnpj.Replace(".", "").Replace("/", "").Replace("-", "");

            var response = await _httpClient.GetAsync($"https://brasilapi.com.br/api/cnpj/v1/{cnpjLimpo}");

            if (!response.IsSuccessStatusCode) return null;

            var dtoExterno = await response.Content.ReadFromJsonAsync<BrasilApiDto>();
            if (dtoExterno == null) return null;

            return new DadosCnpjResponse(
                NomeOficial: dtoExterno.nome_fantasia ?? dtoExterno.razao_social ?? string.Empty,
                Logradouro: dtoExterno.logradouro ?? string.Empty,
                Numero: dtoExterno.numero ?? string.Empty,
                Bairro: dtoExterno.bairro ?? string.Empty,
                Cidade: dtoExterno.municipio ?? string.Empty,
                Estado: dtoExterno.uf ?? string.Empty,
                Cep: dtoExterno.cep ?? string.Empty,
                Telefone: dtoExterno.ddd_telefone_1 ?? string.Empty,
                Email: dtoExterno.email ?? string.Empty
            );
        }

        private class BrasilApiDto
        {
            public string? razao_social { get; set; }
            public string? nome_fantasia { get; set; }
            public string? logradouro { get; set; }
            public string? numero { get; set; }
            public string? bairro { get; set; }
            public string? municipio { get; set; }
            public string? uf { get; set; }
            public string? cep { get; set; }
            public string? ddd_telefone_1 { get; set; }
            public string? email { get; set; }
        }
    }
}