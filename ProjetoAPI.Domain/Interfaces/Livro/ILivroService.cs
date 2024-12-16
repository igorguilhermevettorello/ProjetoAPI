using ProjetoAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAPI.Domain.Interfaces.Livro
{
    public interface ILivroService
    {
        Task<bool> ValidarAutores(List<Guid> autoresIds);
        Task<bool> ValidarAssuntos(List<Guid> assuntosIds);
        Task<IEnumerable<ViewRelatorio>> BuscarDadosParaRelatorio();
    }
}
