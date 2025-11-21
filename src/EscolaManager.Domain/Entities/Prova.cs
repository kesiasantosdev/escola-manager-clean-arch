namespace EscolaManager.Domain.Entities
{
    public class Prova
    {
        public Guid Id { get; private set; }
        public string Titulo { get; private set; }
        public Guid EscolaId { get; private set; }
        public virtual Escola? Escola { get; private set; }
        public Guid UsuarioCriadorId { get; private set; }
        public virtual Usuario? UsuarioCriador { get; private set; }

        private readonly List<ProvaPergunta> _questoes = new();
        public virtual IReadOnlyCollection<ProvaPergunta> Questoes => _questoes;

        public Prova(string titulo, Guid escolaId, Guid usuarioCriadorId)
        {
            if (string.IsNullOrWhiteSpace(titulo))
                throw new ArgumentException("O título da prova é obrigatório.", nameof(titulo));

            if (escolaId == Guid.Empty) throw new ArgumentException("Escola inválida.", nameof(escolaId));
            if (usuarioCriadorId == Guid.Empty) throw new ArgumentException("Criador inválido.", nameof(usuarioCriadorId));

            Id = Guid.NewGuid();
            Titulo = titulo;
            EscolaId = escolaId;
            UsuarioCriadorId = usuarioCriadorId;
        }

        protected Prova()
        {
            Titulo = string.Empty;
        }


    }
}
