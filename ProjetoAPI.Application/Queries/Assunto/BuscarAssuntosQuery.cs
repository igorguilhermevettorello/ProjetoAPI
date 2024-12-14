using MediatR;
using AssuntoEntity = ProjetoAPI.Domain.Entities.Assunto;

namespace ProjetoAPI.Application.Queries.Assunto
{
    internal class BuscarAssuntosQuery : IRequest<IEnumerable<AssuntoEntity>>
    {
    }
}
