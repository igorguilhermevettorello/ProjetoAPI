using MediatR;
using LivroEntity = ProjetoAPI.Domain.Entities.Livro;

namespace ProjetoAPI.Application.Queries.Autor
{
    public class BuscarLivrosQuery : IRequest<IEnumerable<LivroEntity>>
    {
    }
}
