using EscolaManager.Domain.Entities;
using MediatR;

namespace EscolaManager.Application.UseCases.Escolas.Queries.ObterTodasEscolas
{
    public class ObterTodasEscolasQuery : IRequest<IEnumerable<Escola>>
    {
    }
}