using System.ComponentModel.DataAnnotations;

namespace ProjetoAPI.Domain.Entities
{
    public class Autor
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [StringLength(40)]
        public string Nome { get; set; }
    }
}
