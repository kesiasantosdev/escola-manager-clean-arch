namespace EscolaManager.Domain.Entities
{
    public class TipoResposta
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public Guid EscolaId { get; private set; }
        public virtual Escola? Escola { get; private set; }

        public TipoResposta(string nome, Guid escolaId)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome do tipo de resposta é obrigatório", nameof(nome));

            if (escolaId == Guid.Empty)
                throw new ArgumentException("O tipo de resposta deve pertencer a uma escola", nameof(escolaId));

            Id = Guid.NewGuid();
            Nome = nome;
            EscolaId = escolaId;
        }

        protected TipoResposta()
        {
            Nome = string.Empty;
        }
    }
}
