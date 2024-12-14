using MediatR;
using AssuntoEntity = ProjetoAPI.Domain.Entities.Assunto;

namespace ProjetoAPI.Application.Queries.Assunto
{
    public class BuscaAssuntoPorIdQuery : IRequest<AssuntoEntity>
    {
    }
}
