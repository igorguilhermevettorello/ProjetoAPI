using MediatR;
using AssuntoEntity = ProjetoAPI.Domain.Entities.Assunto;

namespace ProjetoAPI.Application.Queries.Assunto
{
    public class BuscarAssuntoPorIdQuery : IRequest<AssuntoEntity>
    {
        public Guid id { get; set; }

        public BuscarAssuntoPorIdQuery(Guid id)
        {
            this.id = id;
        }
    }
}
