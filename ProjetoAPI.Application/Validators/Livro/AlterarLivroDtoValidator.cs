using FluentValidation;
using ProjetoAPI.Application.DTOs.Autor;
using ProjetoAPI.Application.DTOs.Livro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAPI.Application.Validators.Livro
{
    public class AlterarLivroDtoValidator : AbstractValidator<AlterarLivroDto>
    {
        public AlterarLivroDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("O ID é obrigatório.");

            RuleFor(x => x.Titulo)
                .NotEmpty().WithMessage("O título é obrigatório.")
                .MaximumLength(40).WithMessage("O título deve ter no máximo 40 caracteres.");

            RuleFor(x => x.Editora)
                .NotEmpty().WithMessage("A editora é obrigatório.")
                .MaximumLength(40).WithMessage("A editora deve ter no máximo 40 caracteres.");

            RuleFor(x => x.Edicao)
                .NotEmpty().WithMessage("A edição é obrigatório.")
                .GreaterThan(0).WithMessage("A edição deve ser maior que zero.");

            RuleFor(x => x.AnoPublicao)
                .NotEmpty().WithMessage("O ano de publicação é obrigatório.")
                .GreaterThan(0).WithMessage("O ano de publicação deve ser maior que zero.");

            //RuleFor(x => x.Valor)
            //    .GreaterThan(0).WithMessage("O valor deve ser maior que zero.");

            RuleFor(x => x.Autores)
                .NotEmpty().WithMessage("Pelo menos um autor deve ser informado.");

            RuleFor(x => x.Assuntos)
                .NotEmpty().WithMessage("Pelo menos um assunto deve ser informado.");

        }
    }
}
