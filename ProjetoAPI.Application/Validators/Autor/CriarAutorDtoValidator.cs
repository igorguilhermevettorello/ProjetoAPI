using FluentValidation;
using ProjetoAPI.Application.DTOs.Autor;

namespace ProjetoAPI.Application.Validators.Autor
{
    public class CriarAutorDtoValidator : AbstractValidator<CriarAutorDto>
    {
        public CriarAutorDtoValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .MaximumLength(20).WithMessage("O nome deve ter no máximo 40 caracteres.");

        }
    }
}
