using MediatR;
using ProjetoAPI.Application.Queries.Autor;
using ProjetoAPI.Infrastructure;
using AutorEntity = ProjetoAPI.Domain.Entities.Autor;

namespace ProjetoAPI.Application.Handlers.Queries.Autor
{
    public class BuscarAutorPorIdQueryHandler : IRequestHandler<BuscarAutorPorIdQuery, AutorEntity>
    {
        private readonly ApplicationDbContext _context;

        public BuscarAutorPorIdQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AutorEntity> Handle(BuscarAutorPorIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Autor.FindAsync(request.id);
        }
    }
}
