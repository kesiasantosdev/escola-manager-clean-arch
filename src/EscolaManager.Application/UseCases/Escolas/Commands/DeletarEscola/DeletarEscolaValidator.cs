using FluentValidation;

namespace EscolaManager.Application.UseCases.Escolas.Commands.DeletarEscola
{
    public class DeletarEscolaValidator : AbstractValidator<DeletarEscolaCommand>
    {
        public DeletarEscolaValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("O ID da escola é obrigatório.");
        }
    }
}