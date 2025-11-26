using EscolaManager.Domain.Interfaces;
using FluentValidation;

namespace EscolaManager.Application.UseCases.Escolas.Commands.CriarEscola
{
    public class CriarEscolaValidator : AbstractValidator<CriarEscolaCommand>
    {
        private readonly IEscolaRepository _escolaRepository;

        public CriarEscolaValidator(IEscolaRepository escolaRepository)
        {
            _escolaRepository = escolaRepository;

            RuleFor(x => x.NomeEscola)
                .NotEmpty().WithMessage("O nome da escola é obrigatório.")
                .MinimumLength(3).WithMessage("O nome da escola deve ter pelo menos 3 letras.");

            RuleFor(x => x.Cnpj)
                .NotEmpty().WithMessage("CNPJ Obrigatório")

                .Must(cnpj => cnpj?.Replace(".", "").Replace("-", "").Replace("/", "").Length == 14)
                .WithMessage("O CNPJ deve conter 14 dígitos.")

                .MustAsync(async (cnpj, cancellation) =>
                {
                    bool existe = await _escolaRepository.ExistePeloCnpjAsync(cnpj);
                    return !existe;
                })
                .WithMessage("Este CNPJ já está cadastrado.");

            RuleFor(x => x.Estado)
                .Length(2).When(x => !string.IsNullOrEmpty(x.Estado))
                .WithMessage("O estado (UF) deve ter 2 letras (Ex: SP, RJ).");

            RuleFor(x => x.NomeGerente)
                .NotEmpty().WithMessage("É obrigatório informar o nome do gerente responsável.");

            RuleFor(x => x.EmailGerente)
                .NotEmpty().WithMessage("O e-mail do gerente é obrigatório.")
                .EmailAddress().WithMessage("O e-mail informado não é válido.");

            RuleFor(x => x.SenhaInicialGerente)
                .NotEmpty().WithMessage("A senha inicial é obrigatória.")
                .MinimumLength(6).WithMessage("A senha deve ter no mínimo 6 caracteres.");
        }
    }
}