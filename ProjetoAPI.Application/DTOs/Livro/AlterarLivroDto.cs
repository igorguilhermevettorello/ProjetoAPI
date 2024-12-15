using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAPI.Application.DTOs.Livro
{
    public class AlterarLivroDto
    {
        public Guid Id { get; set; }

        public string Titulo { get; set; }

        public string Editora { get; set; }

        public int Edicao { get; set; }

        public int AnoPublicao { get; set; }
        //public decimal Valor { get; set; }
        public ICollection<Guid> Autores { get; set; } = new List<Guid>();
        public ICollection<Guid> Assuntos { get; set; } = new List<Guid>();
    }
}
