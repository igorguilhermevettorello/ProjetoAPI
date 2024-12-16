using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAPI.Domain.Entities
{
    public class ViewRelatorio
    {
        public Guid LivroId { get; set; }
        public string Titulo { get; set; }
        public string Editora { get; set; }
        public int Edicao { get; set; }
        public int AnoPublicacao { get; set; }
        public decimal Valor { get; set; }
        public string Autor { get; set; }
        public string Assunto { get; set; }
    }
}
