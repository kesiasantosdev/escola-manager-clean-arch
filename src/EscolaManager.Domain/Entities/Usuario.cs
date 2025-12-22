namespace EscolaManager.Domain.Entities
{
    public class Usuario
    {
        public Guid Id { get; private set; }
        public string NomePessoa { get; private set; }
        public string Email { get; private set; }
        public string SenhaHash { get; private set; }
        public Guid EscolaId { get; private set; }
        public virtual Escola? Escola { get; private set; }
        public Guid CargoId { get; private set; }
        public virtual Cargo? Cargo { get; private set; }
        public Guid? SuperiorId { get; private set; }
        public virtual Usuario? Superior { get; private set; }

        public Usuario(string nomePessoa, string email, string senhaHash, Guid escolaId, Guid cargoId)
        {
            if (string.IsNullOrWhiteSpace(nomePessoa))
                throw new ArgumentException("O nome da pessoa é obrigatório.", nameof(nomePessoa));

            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                throw new ArgumentException("O email informado é inválido.", nameof(email));

            if (string.IsNullOrWhiteSpace(senhaHash) || senhaHash.Length < 6)
                throw new ArgumentException("A senha deve ter no mínimo 6 caracteres.", nameof(senhaHash));
            if (escolaId == Guid.Empty) throw new ArgumentException("Usuario deve estar vinculado a uma Escola.", nameof(escolaId));
            if (cargoId == Guid.Empty) throw new ArgumentException("Usuario deve ter um Cargo.", nameof(cargoId));

            Id = Guid.NewGuid();
            NomePessoa = nomePessoa;
            Email = email;
            SenhaHash = senhaHash;
            EscolaId = escolaId;
            CargoId = cargoId;
            SuperiorId = null;
        }

        public void CorrigirNome(string novoNome)
        {
            if (string.IsNullOrWhiteSpace(novoNome))
                throw new ArgumentException("O nome não pode ser vazio.", nameof(novoNome));

            NomePessoa = novoNome;
        }

        public void AlterarSenha(string novaSenha)
        {
            if (string.IsNullOrWhiteSpace(novaSenha) || novaSenha.Length < 6)
                throw new ArgumentException("A nova senha deve ter no mínimo 6 caracteres.", nameof(novaSenha));

            SenhaHash = novaSenha;
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
            NomePessoa = string.Empty;
            Email = string.Empty;
            SenhaHash = string.Empty;
        }
    }

}
