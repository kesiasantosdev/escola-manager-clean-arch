using MediatR;

namespace EscolaManager.Application.UseCases.Pessoas.Commands.CriarPessoa
{
    public class CriarPessoaCommand : IRequest<Guid>
    {
        public string NomePessoa { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string SenhaHash { get; set; } = string.Empty;
    }
}
