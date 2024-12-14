using MediatR;
using ProjetoAPI.Application.DTOs.Autor;

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
