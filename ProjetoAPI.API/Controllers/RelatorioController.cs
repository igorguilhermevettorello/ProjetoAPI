using FastReport.Export.PdfSimple;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjetoAPI.Application.Queries.Autor;
using ProjetoAPI.Domain.Interfaces.Livro;

namespace ProjetoAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatorioController : ControllerBase
    {

        private readonly ILivroService _livroService;
        private readonly IWebHostEnvironment _webHostEnv;
        public RelatorioController(ILivroService livroService, IWebHostEnvironment webHostEnv)
        {
            _livroService = livroService;
            _webHostEnv = webHostEnv;
        }

        [HttpGet]
        public async Task<IActionResult> PrepareReport()
        {
            var caminhoReport = Path.Combine(_webHostEnv.ContentRootPath, @"Report\ReportMvc.frx");
            var reportFile = caminhoReport;
            var freport = new FastReport.Report();
            var livros = await _livroService.BuscarDadosParaRelatorio();
            freport.Dictionary.RegisterBusinessObject((System.Collections.IEnumerable)livros, "listaLivros", 10, true);
            freport.Report.Save(reportFile);
            return Ok(caminhoReport);
        }

        [HttpGet("Livros")]
        public async Task<IActionResult> GenerateReport()
        {
            var caminhoReport = Path.Combine(_webHostEnv.ContentRootPath, @"Report\ReportMvc.frx");
            var reportFile = caminhoReport;
            var freport = new FastReport.Report();
            var livros = await _livroService.BuscarDadosParaRelatorio();
            freport.Report.Load(reportFile);
            freport.Dictionary.RegisterBusinessObject((System.Collections.IEnumerable)livros, "listaLivros", 10, true);
            freport.Prepare();
            var pdfExport = new PDFSimpleExport();
            using MemoryStream ms = new MemoryStream();
            pdfExport.Export(freport, ms);
            ms.Flush();

            //freport.Report.Save(reportFile);
            return File(ms.ToArray(), "application/pdf", "Relatorio.pdf");
        }
    }
}
