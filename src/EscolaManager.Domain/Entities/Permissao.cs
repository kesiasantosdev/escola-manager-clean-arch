namespace EscolaManager.Domain.Entities
{
    public class Permissao
    {
        public Guid Id { get; set; }
        public string NomePermissao { get; set; }

        public Permissao(string nomePermissao)
        {
            if (string.IsNullOrWhiteSpace(nomePermissao))
                throw new ArgumentException("O nome da permissão é obrigatório.", nameof(nomePermissao));

            Id = Guid.NewGuid();
            NomePermissao = nomePermissao;
        }

        public void AlterarNome(string novaPermissao)
        {
            if (string.IsNullOrWhiteSpace(novaPermissao))
                throw new ArgumentException("O nome não pode ser vazio.", nameof(novaPermissao));

            NomePermissao = novaPermissao;
        }

        protected Permissao()
        {
            NomePermissao = string.Empty;
        }
    }
}
