using MediatR;
using ProjetoAPI.Application.DTOs.Autor;

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
