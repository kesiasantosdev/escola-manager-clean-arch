using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolaManager.Domain.Entities
{
    public class Cargo
    {
        public Guid Id { get; private set; }
        public string NomeCargo { get; private set; }
        public Guid EscolaId { get; private set; }
        public virtual Escola? Escola { get; private set; }

        public Cargo(string nomeCargo, Guid escolaId)
        {
            if (string.IsNullOrWhiteSpace(nomeCargo))
                throw new ArgumentException("O nome do cargo é obrigatório.", nameof(nomeCargo));

            if (escolaId == Guid.Empty)
                throw new ArgumentException("O cargo deve pertencer a uma escola válida.", nameof(escolaId));

            Id = Guid.NewGuid();
            NomeCargo = nomeCargo;
            EscolaId = escolaId;
        }

        public void AlterarNome(string novoNome)
        {
            if (string.IsNullOrWhiteSpace(novoNome))
                throw new ArgumentException("O nome do cargo não pode ser vazio.", nameof(novoNome));

            NomeCargo = novoNome;
        }

        protected Cargo()
        {
            NomeCargo = string.Empty;
        }
    }
}
