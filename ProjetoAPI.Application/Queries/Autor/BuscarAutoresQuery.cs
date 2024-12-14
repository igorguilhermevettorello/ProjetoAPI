using MediatR;
using AutorEntity = ProjetoAPI.Domain.Entities.Autor;

namespace ProjetoAPI.Application.Queries.Autor
{
    public class BuscarAutoresQuery : IRequest<IEnumerable<AutorEntity>>
    {
    }
}
