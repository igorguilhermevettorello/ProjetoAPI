using ProjetoAPI.Domain.Interfaces.Assunto;
using AutorEntity = ProjetoAPI.Domain.Entities.Autor;

namespace ProjetoAPI.Infrastructure.Repositories.Assunto
{
    public class AutorRepository : GenericRepository<AutorEntity>, IAutorRepository
    {
        public AutorRepository(ApplicationDbContext context) : base(context) { }
    }
}