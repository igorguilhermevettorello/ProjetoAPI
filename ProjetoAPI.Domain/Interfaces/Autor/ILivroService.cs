using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAPI.Domain.Interfaces.Autor
{
    public interface ILivroService
    {
        bool ValidarAutores(decimal valor);
        bool ValidarAssuntos(decimal valor);
    }
}
