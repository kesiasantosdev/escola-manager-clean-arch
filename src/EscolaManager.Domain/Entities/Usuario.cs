namespace EscolaManager.Domain.Entities
{
    public class Usuario
    {
        public Guid Id { get; private set; }
        public Guid PessoaId { get; private set; }
        public virtual Pessoa? Pessoa { get; private set; }
        public Guid EscolaId { get; private set; }
        public virtual Escola? Escola { get; private set; }
        public Guid CargoId { get; private set; }
        public virtual Cargo? Cargo { get; private set; }
        public Guid? SuperiorId { get; private set; }
        public virtual Usuario? Superior { get; private set; }

        public Usuario(Guid pessoaId, Guid escolaId, Guid cargoId)
        {
            if (pessoaId == Guid.Empty) throw new ArgumentException("Usuario deve estar vinculado a uma Pessoa.", nameof(pessoaId));
            if (escolaId == Guid.Empty) throw new ArgumentException("Usuario deve estar vinculado a uma Escola.", nameof(escolaId));
            if (cargoId == Guid.Empty) throw new ArgumentException("Usuario deve ter um Cargo.", nameof(cargoId));

            Id = Guid.NewGuid();
            PessoaId = pessoaId;
            EscolaId = escolaId;
            CargoId = cargoId;
            SuperiorId = null;
        }

        public void DefinirSuperior(Guid? superiorId)
        {
            if (superiorId.HasValue && superiorId == Id)
                throw new InvalidOperationException("Um usuário não pode ser superior de si mesmo.");

            SuperiorId = superiorId;
        }

        public void AlterarCargo(Guid novoCargoId)
        {
            if (novoCargoId == Guid.Empty)
                throw new ArgumentException("O novo cargo deve ser válido.", nameof(novoCargoId));

            CargoId = novoCargoId;
        }

        protected Usuario()
        {

        }
    }

}
