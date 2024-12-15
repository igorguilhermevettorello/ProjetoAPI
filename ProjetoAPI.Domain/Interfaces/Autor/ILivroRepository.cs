using ProjetoAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAPI.Domain.Interfaces.Autor
{
    public interface ILivroRepository : IGenericRepository<Livro>
    {
        Task<IEnumerable<Livro>> GetLivrosPorTituloAsync(string titulo);
    }
}
