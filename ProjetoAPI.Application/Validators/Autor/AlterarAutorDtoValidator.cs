using FluentValidation;
using ProjetoAPI.Application.DTOs.Autor;

namespace ProjetoAPI.Application.Validators.Autor
{
    public class AlterarAutorDtoValidator : AbstractValidator<AlterarAutorDto>
    {
        public AlterarAutorDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("O ID é obrigatório.");

            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .MaximumLength(40).WithMessage("O nome deve ter no máximo 40 caracteres.");

        }
    }
}
