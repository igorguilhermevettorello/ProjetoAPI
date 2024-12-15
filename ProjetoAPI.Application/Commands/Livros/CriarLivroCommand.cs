using MediatR;
using ProjetoAPI.Application.DTOs.Autor;
using ProjetoAPI.Application.DTOs.Livro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAPI.Application.Commands.Livros
{
    public class CriarLivroCommand : IRequest<Guid>
    {
        public CriarLivroDto LivroDto { get; }

        public CriarLivroCommand(CriarLivroDto livroDto)
        {
            LivroDto = livroDto;
        }
    }
}
