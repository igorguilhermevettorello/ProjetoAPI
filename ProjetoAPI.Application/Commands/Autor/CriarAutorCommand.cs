using MediatR;
using ProjetoAPI.Application.DTOs.Autor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAPI.Application.Commands.Autor
{
    public class CriarAutorCommand : IRequest<Guid>
    {
        public CriarAutorDto AuthorDto { get; }

        public CriarAutorCommand(CriarAutorDto authorDto)
        {
            AuthorDto = authorDto;
        }
    }
}
