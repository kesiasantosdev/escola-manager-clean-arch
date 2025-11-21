namespace EscolaManager.Domain.Entities
{
    public class TipoPergunta
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public Guid EscolaId { get; private set; }
        public virtual Escola? Escola { get; private set; }

        public TipoPergunta(string nome, Guid escolaId)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome do tipo de pergunta é obrigatótio", nameof(nome));

            if (escolaId == Guid.Empty)
                throw new ArgumentException("O tipo de pergunta deve pertencer a uma escola", nameof(escolaId));

            Id = Guid.NewGuid();
            Nome = nome;
            EscolaId = escolaId;
        }

        protected TipoPergunta()
        {
            Nome = string.Empty;
        }
    }
}
