using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjetoAPI.Application.Queries.Autor;
using ProjetoAPI.Infrastructure;
using LivroEntity = ProjetoAPI.Domain.Entities.Livro;

namespace ProjetoAPI.Application.Handlers.Queries.Autor
{
    public class BuscarLivrosQueryHandler : IRequestHandler<BuscarLivrosQuery, IEnumerable<LivroEntity>>
    {
        private readonly ApplicationDbContext _context;

        public BuscarLivrosQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LivroEntity>> Handle(BuscarLivrosQuery request, CancellationToken cancellationToken)
        {
            return await _context.Livro
                .Include(l => l.Autores)
                .Include(l => l.Assuntos)
                .ToListAsync();
        }
    }
}

