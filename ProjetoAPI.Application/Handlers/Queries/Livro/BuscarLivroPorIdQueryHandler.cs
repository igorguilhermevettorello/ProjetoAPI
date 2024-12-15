using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjetoAPI.Application.Queries.Autor;
using ProjetoAPI.Infrastructure;
using LivroEntity = ProjetoAPI.Domain.Entities.Livro;

namespace ProjetoAPI.Application.Handlers.Queries.Livro
{
    public class BuscarLivroPorIdQueryHandler : IRequestHandler<BuscarLivroPorIdQuery, LivroEntity>
    {
        private readonly ApplicationDbContext _context;

        public BuscarLivroPorIdQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<LivroEntity> Handle(BuscarLivroPorIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Livro
                .Include(l => l.Autores)
                .Include(l => l.Assuntos)
                .FirstOrDefaultAsync(l => l.Id == request.Id);
        }
    }
}
