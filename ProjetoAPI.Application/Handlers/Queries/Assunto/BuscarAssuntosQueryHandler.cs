

using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjetoAPI.Application.Queries.Assunto;
using ProjetoAPI.Infrastructure;
using AssutnoEntity = ProjetoAPI.Domain.Entities.Assunto;

namespace ProjetoAPI.Application.Handlers.Queries.Autor
{
    public class BuscarAssuntosQueryHandler : IRequestHandler<BuscarAssuntosQuery, IEnumerable<AssutnoEntity>>
    {
        private readonly ApplicationDbContext _context;

        public BuscarAssuntosQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AssutnoEntity>> Handle(BuscarAssuntosQuery request, CancellationToken cancellationToken)
        {
            return await _context.Assunto.ToListAsync(cancellationToken);
        }

    }
}

