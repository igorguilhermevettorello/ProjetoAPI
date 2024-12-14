using MediatR;
using ProjetoAPI.Application.DTOs.Autor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAPI.Application.Commands.Autor
{
    public class RemoverAutorCommand : IRequest<Unit>
    {
        public Guid Id { get; }

        public RemoverAutorCommand(Guid id)
        {
            Id = id;
        }
    }
}
