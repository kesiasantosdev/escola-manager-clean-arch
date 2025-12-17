namespace EscolaManager.Domain.Entities
{
    public class RealizacaoProva
    {
        public Guid Id { get; private set; }
        public Guid BimestreId { get; private set; }
        public virtual Bimestre? Bimestre { get; private set; }
        public Guid ProvaId { get; private set; }
        public virtual Prova? Prova { get; private set; }
        public Guid AvaliadorId { get; private set; }
        public virtual Usuario? Avaliador { get; private set; }
        public Guid AvaliadoId { get; private set; }
        public virtual Usuario? Avaliado { get; private set; }
        public TipoRelacao TipoRelacao { get; private set; }
        public StatusRealizacao Status { get; private set; }

        public RealizacaoProva(Guid bimestreId, Guid provaId, Guid avaliadorId, Guid avaliadoId, TipoRelacao tipoRelacao)
        {
            if (bimestreId == Guid.Empty) throw new ArgumentException("Bimestre inválido.");
            if (provaId == Guid.Empty) throw new ArgumentException("Prova inválida.");
            if (avaliadorId == Guid.Empty) throw new ArgumentException("Avaliador inválido.");
            if (avaliadoId == Guid.Empty) throw new ArgumentException("Avaliado inválido.");

            Id = Guid.NewGuid();
            BimestreId = bimestreId;
            ProvaId = provaId;
            AvaliadorId = avaliadorId;
            AvaliadoId = avaliadoId;
            TipoRelacao = tipoRelacao;

            Status = StatusRealizacao.Pendente;
        }

        public void Iniciar()
        {
            Status = StatusRealizacao.EmAndamento;
        }

        public void Finalizar()
        {
            Status = StatusRealizacao.Finalizado;
        }

        protected RealizacaoProva() { }
    }
}
