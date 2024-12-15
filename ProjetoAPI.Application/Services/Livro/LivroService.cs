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

        public bool ValidarAssuntos(List<Guid> assuntoIds)
        {
            var verificacao = true;
            assuntoIds.ForEach(async assuntoId =>
            {
                var assunto = await _assuntoRepository.GetByIdAsync(assuntoId);
                if (assunto == null) verificacao = false;
            });

            return verificacao;
        }

        public bool ValidarAutores(List<Guid> autorIds)
        {
            var verificacao = true;
            autorIds.ForEach(async autorId =>
            {
                var autor = await _autorRepository.GetByIdAsync(autorId);
                if (autor == null) verificacao = false;
            });

            return verificacao;
        }
    }
}
