using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAPI.Application.DTOs.Assunto
{
    public class AlterarAssuntoDto
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
    }
}
