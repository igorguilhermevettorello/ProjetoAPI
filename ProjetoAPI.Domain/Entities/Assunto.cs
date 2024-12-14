using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAPI.Domain.Entities
{
    public class Assunto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Descricao { get; set; }
    }
}
