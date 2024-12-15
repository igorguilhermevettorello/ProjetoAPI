using Microsoft.EntityFrameworkCore;
using ProjetoAPI.Domain.Entities;
using ProjetoAPI.Domain.Interfaces.Assunto;
using ProjetoAPI.Domain.Interfaces.Livro;
using ProjetoAPI.Infrastructure.Repositories.Livro;

namespace ProjetoAPI.Application.Services.Livro
{
    public class LivroService : ILivroService
    {
        private readonly IAssuntoRepository _assuntoRepository;
        private readonly IAutorRepository _autorRepository;

        public LivroService(IAssuntoRepository assuntoRepository, IAutorRepository autorRepository)
        {
            _assuntoRepository = assuntoRepository;
            _autorRepository = autorRepository;
        }

        public async Task<bool> ValidarAssuntos(List<Guid> assuntoIds)
        {
            var verificacao = true;
            foreach (var id in assuntoIds)
            {
                var assunto = await _assuntoRepository.GetByIdAsync(id);
                if (assunto == null) verificacao = false;   
            }
            return verificacao;
        }

        public async Task<bool> ValidarAutores(List<Guid> autorIds)
        {
            var verificacao = true;
            foreach (var id in autorIds)
            {
                var assunto = await _autorRepository.GetByIdAsync(id);
                if (assunto == null) verificacao = false;
            }
            return verificacao;
        }
    }
}
