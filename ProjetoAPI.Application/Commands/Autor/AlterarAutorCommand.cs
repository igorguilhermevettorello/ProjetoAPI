using MediatR;
using ProjetoAPI.Application.DTOs.Autor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAPI.Application.Commands.Autor
{
    public class AlterarAutorCommand : IRequest<Unit>
    {
        public AlterarAutorDto AuthorDto { get; }

        public AlterarAutorCommand(AlterarAutorDto authorDto)
        {
            AuthorDto = authorDto;
        }
    }
}
