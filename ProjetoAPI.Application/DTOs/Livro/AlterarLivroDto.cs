namespace ProjetoAPI.Application.DTOs.Livro
{
    public class AlterarLivroDto
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Editora { get; set; }
        public int Edicao { get; set; }
        public int AnoPublicacao { get; set; }
        public decimal Valor { get; set; }
        public List<Guid> AutorIds { get; set; } = new List<Guid>();
        public List<Guid> AssuntoIds { get; set; } = new List<Guid>();
    }
}
