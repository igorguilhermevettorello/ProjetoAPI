using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjetoAPI.Application.Queries.Autor;
using ProjetoAPI.Infrastructure;
using AutorEntity = ProjetoAPI.Domain.Entities.Autor;

namespace ProjetoAPI.Application.Handlers.Queries.Autor
{
    public class BuscarAutoresQueriyHandler : IRequestHandler<BuscarAutoresQuery, IEnumerable<AutorEntity>>
    {
        private readonly ApplicationDbContext _context;

        public BuscarAutoresQueriyHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AutorEntity>> Handle(BuscarAutoresQuery request, CancellationToken cancellationToken)
        {
            return await _context.Autor.ToListAsync(cancellationToken);
        }
    
    }
}
