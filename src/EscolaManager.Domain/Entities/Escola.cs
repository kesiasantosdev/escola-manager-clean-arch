namespace EscolaManager.Domain.Entities
{
    public class Escola
    {
        public Guid Id { get; private set; }
        public string NomeEscola { get; private set; }
        public string Cnpj { get; private set; }

        public Escola(string nomeEscola, string cnpj)
        {
            if (string.IsNullOrWhiteSpace(nomeEscola))
                throw new ArgumentException("O nome da Escola é obrigatório.", nameof(nomeEscola));

            Id = Guid.NewGuid();
            NomeEscola = nomeEscola;
            Cnpj = cnpj;
        }

        public void AlterarNome(string novoNome)
        {
            if (string.IsNullOrWhiteSpace(novoNome))
                throw new ArgumentException("O nome não pode ser vazio", nameof(novoNome));

            NomeEscola = novoNome;
        }

        protected Escola()
        {
            NomeEscola = string.Empty;
            Cnpj = string.Empty;
        }
    }
}