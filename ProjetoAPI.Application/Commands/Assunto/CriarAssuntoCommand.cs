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
    internal class CriarAssuntoCommand : IRequest<Guid>
    {
        public CriarAssuntoDto AssuntoDto { get; }

        public CriarAssuntoCommand(CriarAssuntoDto assuntoDto)
        {
            AssuntoDto = assuntoDto;
        }
    }
}
