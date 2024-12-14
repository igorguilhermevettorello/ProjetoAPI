using FluentValidation;
using ProjetoAPI.Application.DTOs.Assunto;
using ProjetoAPI.Application.DTOs.Autor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                .MaximumLength(20).WithMessage("O nome deve ter no máximo 40 caracteres.");

        }
    }
}
