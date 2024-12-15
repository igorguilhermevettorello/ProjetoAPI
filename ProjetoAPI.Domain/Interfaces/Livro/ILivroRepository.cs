using LivroEntity = ProjetoAPI.Domain.Entities.Livro;

namespace ProjetoAPI.Domain.Interfaces.Livro
{
    public interface ILivroRepository : IGenericRepository<LivroEntity>
    {
    }
}
