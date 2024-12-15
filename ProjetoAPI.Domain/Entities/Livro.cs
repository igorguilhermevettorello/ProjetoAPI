using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAPI.Domain.Entities
{
    public class Livro
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [StringLength(40)]
        public string Titulo { get; set; }
        [Required]
        [StringLength(40)]
        public string Editora { get; set; }
        [Required]
        public int Edicao { get; set; }
        [Required]
        public int AnoPublicacao { get; set; }
        [Column(TypeName = "decimal(15,2)")]
        public decimal Valor { get; set; }
        public ICollection<Autor> Autores { get; set; } = new List<Autor>();
        public ICollection<Assunto> Assuntos { get; set; } = new List<Assunto>();
    }
}
