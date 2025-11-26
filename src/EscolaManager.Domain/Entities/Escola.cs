using System;

namespace EscolaManager.Domain.Entities
{
    public class Escola
    {
        public Guid Id { get; private set; }
        public string NomeEscola { get; private set; }
        public string Cnpj { get; private set; }
        public string? Email { get; private set; }
        public string? Telefone { get; private set; }
        public string? Cep { get; private set; }
        public string? Rua { get; private set; }
        public string? Numero { get; private set; }
        public string? Bairro { get; private set; }
        public string? Cidade { get; private set; }
        public string? Estado { get; private set; }

        public StatusEscola Status { get; private set; }

        public Escola(
            string nomeEscola,
            string cnpj,
            string? email,
            string? telefone,
            string? cep,
            string? rua,
            string? numero,
            string? bairro,
            string? cidade,
            string? estado)
        {
            if (string.IsNullOrWhiteSpace(nomeEscola)) throw new ArgumentException("Nome da escola é obrigatório.", nameof(nomeEscola));
            if (string.IsNullOrWhiteSpace(cnpj)) throw new ArgumentException("CNPJ é obrigatório.", nameof(cnpj));

            Id = Guid.NewGuid();
            NomeEscola = nomeEscola;
            Cnpj = cnpj.Trim().Replace(".", "").Replace("-", "").Replace("/", "");

            Email = email;
            Telefone = telefone;
            Cep = cep;
            Rua = rua;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Status = StatusEscola.Ativa;
        }

        public void AtualizarDados(string nome, string? email, string? telefone, string? rua, string? cidade, string? estado)
        {
            if (!string.IsNullOrWhiteSpace(nome)) NomeEscola = nome;
            Email = email;
            Telefone = telefone;
            Rua = rua;
            Cidade = cidade;
            Estado = estado;
        }

        public void Bloquear() => Status = StatusEscola.Bloqueada;
        public void Ativar() => Status = StatusEscola.Ativa;

        protected Escola()
        {
            NomeEscola = string.Empty;
            Cnpj = string.Empty;
        }
    }
}