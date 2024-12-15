using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAPI.Domain.Interfaces.Livro
{
    public interface ILivroService
    {
        bool ValidarAutores(List<Guid> autoresIds);
        bool ValidarAssuntos(List<Guid> assuntosIds);
    }
}
