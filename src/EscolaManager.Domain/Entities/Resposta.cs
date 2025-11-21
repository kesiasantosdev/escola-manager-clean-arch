namespace EscolaManager.Domain.Entities
{
    public class Resposta
    {
        public Guid Id { get; private set; }
        public Guid RealizacaoProvaId { get; private set; }
        public virtual RealizacaoProva? RealizacaoProva { get; private set; }
        public Guid PerguntaId { get; private set; }
        public virtual Pergunta? Pergunta { get; private set; }
        public string? RespostaTexto { get; private set; }
        public int? RespostaNota { get; private set; }

        public Resposta(Guid realizacaoProvaId, Guid perguntaId, string? respostaTexto, int? respostaNota)
        {
            if (realizacaoProvaId == Guid.Empty) throw new ArgumentException("Realização inválida.");
            if (perguntaId == Guid.Empty) throw new ArgumentException("Pergunta inválida.");

            if (string.IsNullOrWhiteSpace(respostaTexto) && !respostaNota.HasValue)
                throw new ArgumentException("A resposta deve conter um texto ou uma nota.");

            Id = Guid.NewGuid();
            RealizacaoProvaId = realizacaoProvaId;
            PerguntaId = perguntaId;
            RespostaTexto = respostaTexto;
            RespostaNota = respostaNota;
        }

        protected Resposta() { }
    }
}
