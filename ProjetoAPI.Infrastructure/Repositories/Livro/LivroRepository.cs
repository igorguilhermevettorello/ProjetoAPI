using Microsoft.EntityFrameworkCore;
using ProjetoAPI.Domain.Interfaces.Autor;
using LivroEntity = ProjetoAPI.Domain.Entities.Livro;

namespace ProjetoAPI.Infrastructure.Repositories.Livro
{
    public class LivroRepository : GenericRepository<LivroEntity>, ILivroRepository
    {
        public LivroRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<LivroEntity>> GetLivrosPorTituloAsync(string titulo)
        {
            return await _context.Livro
                .Where(l => l.Titulo.Contains(titulo))
                .ToListAsync();
        }
    }
}
