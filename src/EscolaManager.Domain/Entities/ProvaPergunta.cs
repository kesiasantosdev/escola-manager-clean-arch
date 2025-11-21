using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolaManager.Domain.Entities
{
    public class ProvaPergunta
    {
        public Guid ProvaId { get; private set; }
        public virtual Prova? Prova { get; private set; }
        public Guid PerguntaId { get; private set; }
        public virtual Pergunta? Pergunta { get; private set; }
        public int Ordem {  get; private set; }

        public ProvaPergunta(Guid provaId, Guid perguntaId, int ordem)
        {
            if (provaId == Guid.Empty) throw new ArgumentException("Prova inválida.", nameof(provaId));
            if (perguntaId == Guid.Empty) throw new ArgumentException("Pergunta inválida.", nameof(perguntaId));
            if (ordem <= 0) throw new ArgumentException("A ordem deve ser maior que zero.", nameof(ordem));

            ProvaId = provaId;
            PerguntaId = perguntaId;
            Ordem = ordem;
        }

        protected ProvaPergunta() { }

    }
}
