namespace EscolaManager.Domain.Entities
{
    public class Pessoa
    {
        public Guid Id { get; private set; }
        public string NomePessoa { get; private set; }
        public string Email { get; private set; }
        public string SenhaHash { get; private set; }

        public Pessoa(string nomePessoa, string email, string senhaHash)
        {
            if (string.IsNullOrWhiteSpace(nomePessoa))
                throw new ArgumentException("O nome da pessoa é obrigatório.", nameof(nomePessoa));

            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                throw new ArgumentException("O email informado é inválido.", nameof(email));

            if (string.IsNullOrWhiteSpace(senhaHash) || senhaHash.Length < 6)
                throw new ArgumentException("A senha deve ter no mínimo 6 caracteres.", nameof(senhaHash));

            Id = Guid.NewGuid();
            NomePessoa = nomePessoa;
            Email = email;
            SenhaHash = senhaHash;
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

        protected Pessoa()
        {
            NomePessoa = string.Empty;
            Email = string.Empty;
            SenhaHash = string.Empty;
        }
    }
}