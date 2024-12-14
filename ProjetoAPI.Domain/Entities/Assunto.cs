using System.ComponentModel.DataAnnotations;

namespace ProjetoAPI.Domain.Entities
{
    public class Assunto
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [StringLength(20)]
        public string Descricao { get; set; }
    }
}
