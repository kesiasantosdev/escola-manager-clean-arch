using EscolaManager.Domain.Entities;

namespace EscolaManager.Application.Interfaces
{
    public interface ITokenService
    {
        string GerarToken(Usuario usuario, string nomeCargo, string email);
    }
}