using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjetoAPI.Domain.Entities
{
    public class Assunto
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [StringLength(20)]
        public string Descricao { get; set; }
        [JsonIgnore]
        public ICollection<Livro> Livros { get; set; } = new List<Livro>();
    }
}
