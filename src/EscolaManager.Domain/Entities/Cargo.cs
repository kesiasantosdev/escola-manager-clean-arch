namespace EscolaManager.Domain.Entities
{
    public class Cargo
    {
        public Guid Id { get; private set; }
        public string NomeCargo { get; private set; }

        public Guid EscolaId { get; private set; }
        public virtual Escola? Escola { get; private set; }

        private readonly List<Permissao> _permissoes = new();
        public virtual IReadOnlyCollection<Permissao> Permissoes => _permissoes;

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

        public void AdicionarPermissao(Permissao permissao)
        {
            if (_permissoes.Any(p => p.Id == permissao.Id))
                return;

            _permissoes.Add(permissao);
        }

        public void RemoverPermissao(Permissao permissao)
        {
            _permissoes.Remove(permissao);
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