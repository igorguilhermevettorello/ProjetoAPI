using MediatR;
using AutorEntity = ProjetoAPI.Domain.Entities.Autor;

namespace ProjetoAPI.Application.Queries.Autor
{
    public class BuscarAutorPorIdQuery: IRequest<AutorEntity>
    {
        public Guid id { get; set; }

        public BuscarAutorPorIdQuery(Guid id)
        {
            this.id = id;
        }   
    }
}
