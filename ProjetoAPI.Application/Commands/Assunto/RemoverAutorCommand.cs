using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAPI.Application.Commands.Assunto
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
