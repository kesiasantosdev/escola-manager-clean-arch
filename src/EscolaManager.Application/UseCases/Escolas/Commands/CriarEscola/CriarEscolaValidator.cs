using FluentValidation;

namespace EscolaManager.Application.UseCases.Escolas.Commands.CriarEscola
{
    public class CriarEscolaValidator : AbstractValidator<CriarEscolaCommand>
    {
        public CriarEscolaValidator()
        {
            RuleFor(x => x.NomeEscola)
                .NotEmpty().WithMessage("O nome da escola é obrigatório.")
                .MinimumLength(3).WithMessage("O nome deve ter pelo menos 3 letras.");

            RuleFor(x => x.Cnpj)
                .NotEmpty().WithMessage("O CNPJ é obrigatório.")
                .Length(14).WithMessage("O CNPJ deve ter exatamente 14 dígitos (apenas números).");
        }
    }
}