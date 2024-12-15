using MediatR;
using ProjetoAPI.Application.DTOs.Livro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAPI.Application.Commands.Livros
{
    public class AlterarLivroCommand : IRequest<RetornoAlterarLivroDto>
    {
        public AlterarLivroDto LivroDto { get; }

        public AlterarLivroCommand(AlterarLivroDto livroDto)
        {
            LivroDto = livroDto;
        }
    }
}
