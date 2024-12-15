using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAPI.Application.DTOs.Livro
{
    public class CriarLivroDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        
        public string Titulo { get; set; }
        
        public string Editora { get; set; }
        
        public int Edicao { get; set; }
        
        public int AnoPublicao { get; set; }
        //public decimal Valor { get; set; }
        //public ICollection<Guid> Autores { get; set; } = new List<Guid>();
        //public ICollection<Guid> Assuntos { get; set; } = new List<Guid>();
        public List<Guid> AutorIds { get; set; } = new List<Guid>();
        public List<Guid> AssuntoIds { get; set; } = new List<Guid>();
    }
}
