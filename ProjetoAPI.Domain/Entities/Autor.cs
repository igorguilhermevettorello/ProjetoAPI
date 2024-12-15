using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjetoAPI.Domain.Entities
{
    public class Autor
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [StringLength(40)]
        public string Nome { get; set; }
        [JsonIgnore]
        public ICollection<Livro> Livros { get; set; } = new List<Livro>();
    }
}
