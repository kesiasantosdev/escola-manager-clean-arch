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

        protected Permissao()
        {
            NomePermissao = string.Empty;
        }
    }
}
