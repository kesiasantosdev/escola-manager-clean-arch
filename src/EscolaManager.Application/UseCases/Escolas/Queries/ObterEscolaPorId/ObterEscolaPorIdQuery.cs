using MediatR;

namespace EscolaManager.Application.UseCases.Escolas.Queries.ObterEscolaPorId
{
    public class ObterEscolaPorIdQuery : IRequest<EscolaViewModel?>
    {
        public Guid Id { get; set; }

        public ObterEscolaPorIdQuery(Guid id)
        {
            Id = id;
        }
    }
}