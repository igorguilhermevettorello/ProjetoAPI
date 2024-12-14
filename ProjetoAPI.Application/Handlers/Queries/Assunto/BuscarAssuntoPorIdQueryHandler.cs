using MediatR;
using ProjetoAPI.Application.Queries.Assunto;
using ProjetoAPI.Infrastructure;
using AssuntoEntity = ProjetoAPI.Domain.Entities.Assunto;

namespace ProjetoAPI.Application.Handlers.Queries.Autor
{
    public class BuscarAssuntoPorIdQueryHandler : IRequestHandler<BuscarAssuntoPorIdQuery, AssuntoEntity>
    {
        private readonly ApplicationDbContext _context;

        public BuscarAssuntoPorIdQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AssuntoEntity> Handle(BuscarAssuntoPorIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Assunto.FindAsync(request.id);
        }
    }
}

