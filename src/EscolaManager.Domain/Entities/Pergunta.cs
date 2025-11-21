using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolaManager.Domain.Entities
{
    public class Pergunta
    {
        public Guid Id { get; private set; }
        public string TextoPergunta { get; private set; }
        public Guid EscolaId { get; private set; }
        public virtual Escola? Escola { get; private set; }
        public Guid TipoPerguntaId { get; private set; }
        public virtual TipoPergunta? TipoPergunta { get; private set; }
        public Guid TipoRespostaId { get; private set; }
        public virtual TipoResposta? TipoResposta { get; private set; }

        public Pergunta(string textoPergunta, Guid escolaId, Guid tipoPerguntaId, Guid tipoRespostaId)
        {
            if (string.IsNullOrWhiteSpace(textoPergunta))
                throw new ArgumentException("O texto da pergunta é obrigatório.", nameof(textoPergunta));

            if (escolaId == Guid.Empty) throw new ArgumentException("Escola inválida.", nameof(escolaId));
            if (tipoPerguntaId == Guid.Empty) throw new ArgumentException("Tipo de pergunta inválido.", nameof(tipoPerguntaId));
            if (tipoRespostaId == Guid.Empty) throw new ArgumentException("Tipo de resposta inválido.", nameof(tipoRespostaId));

            Id = Guid.NewGuid();
            TextoPergunta = textoPergunta;
            EscolaId = escolaId;
            TipoPerguntaId = tipoPerguntaId;
            TipoRespostaId = tipoRespostaId;
        }

        protected Pergunta() 
        { 
            TextoPergunta = string.Empty;
        }
    }
}
