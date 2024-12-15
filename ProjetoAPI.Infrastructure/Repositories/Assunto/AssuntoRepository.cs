using ProjetoAPI.Domain.Interfaces.Assunto;
using AssuntoEntity = ProjetoAPI.Domain.Entities.Assunto;

namespace ProjetoAPI.Infrastructure.Repositories.Assunto
{
    public class AssuntoRepository : GenericRepository<AssuntoEntity>, IAssuntoRepository
    {
        public AssuntoRepository(ApplicationDbContext context) : base(context) { }
    }
}
