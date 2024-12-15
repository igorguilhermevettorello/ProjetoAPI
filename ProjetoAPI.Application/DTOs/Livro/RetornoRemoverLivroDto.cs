using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAPI.Application.DTOs.Livro
{
    public class RetornoRemoverLivroDto
    {
        public bool Status { get; set; }
        public string Mensagem { get; set; }
    }
}
