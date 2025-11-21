using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolaManager.Domain.Entities
{
    public class Bimestre
    {
        public Guid Id { get; private set; }
        public string Titulo { get; private set; }
        public DateTime DataInicio { get; private set; }
        public DateTime DataFim { get; private set; }
        public Guid EscolaId { get; private set; }
        public virtual Escola? Escola { get; private set; }
        public Guid UsuarioGestorId { get; private set; }
        public virtual Usuario? UsuarioGestor { get; private set; }
        public bool MostrarResultadosAoAvaliado { get; private set; }

        public Bimestre(string titulo, DateTime dataInicio, DateTime dataFim, Guid escolaId, Guid usuarioGestorId)
        {
            if (string.IsNullOrWhiteSpace(titulo))
                throw new ArgumentException("O título é obrigatório.", nameof(titulo));

            if (dataFim < dataInicio)
                throw new ArgumentException("A data final não pode ser anterior à data inicial.");

            if (escolaId == Guid.Empty) throw new ArgumentException("Escola inválida.", nameof(escolaId));
            if (usuarioGestorId == Guid.Empty) throw new ArgumentException("Gestor inválido.", nameof(usuarioGestorId));

            Id = Guid.NewGuid();
            Titulo = titulo;
            DataInicio = dataInicio;
            DataFim = dataFim;
            EscolaId = escolaId;
            UsuarioGestorId = usuarioGestorId;
            MostrarResultadosAoAvaliado = false;
        }

        public void LiberarResultados()
        {
            MostrarResultadosAoAvaliado = true;
        }

        protected Bimestre() 
        {
            Titulo = string.Empty; 
        }
    }
}
