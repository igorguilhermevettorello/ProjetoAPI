using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAPI.Application.DTOs.Livro
{
    public class RetornoCriarLivroDto
    {
        public bool Status { get; set; }
        public Guid Id { get; set; }
        public string Mensagem { get; set; }
    }
}
