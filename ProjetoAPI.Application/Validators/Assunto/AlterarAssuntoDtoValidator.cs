using FluentValidation;
using ProjetoAPI.Application.DTOs.Assunto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAPI.Application.Validators.Assunto
{
    public class AlterarAssuntoDtoValidator : AbstractValidator<AlterarAssuntoDto>
    {
        public AlterarAssuntoDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("O ID é obrigatório.");

            RuleFor(x => x.Descricao)
                .NotEmpty().WithMessage("A descrição é obrigatório.")
                .MaximumLength(20).WithMessage("A descrição deve ter no máximo 20 caracteres.");

        }
    }
}
