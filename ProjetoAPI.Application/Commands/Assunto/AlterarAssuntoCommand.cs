using MediatR;
using ProjetoAPI.Application.DTOs.Assunto;
using ProjetoAPI.Application.DTOs.Autor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAPI.Application.Commands.Assunto
{
    public class AlterarAssuntoCommand : IRequest<Unit>
    {
        public AlterarAssuntoDto AssuntoDto { get; }

        public AlterarAssuntoCommand(AlterarAssuntoDto assuntoDto)
        {
            AssuntoDto = assuntoDto;
        }
    }
}
