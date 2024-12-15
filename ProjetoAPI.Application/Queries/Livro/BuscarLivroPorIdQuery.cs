using MediatR;
using LivroEntity = ProjetoAPI.Domain.Entities.Livro;

namespace ProjetoAPI.Application.Queries.Autor
{
    public class BuscarLivroPorIdQuery : IRequest<LivroEntity>
    {
        public Guid Id { get; set; }

        public BuscarLivroPorIdQuery(Guid id)
        {
            Id = id;
        }
    }
}

