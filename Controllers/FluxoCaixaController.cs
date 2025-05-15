using Microsoft.AspNetCore.Mvc;
using FluxoCaixa.Repositories;
using FluxoCaixa.Services;
using FluxoCaixa.Models;

namespace FluxoCaixa.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FluxoCaixaController : ControllerBase
    {
        private readonly ILancamentoRepository _repo;
        private readonly IFluxoCaixaService _fluxoCaixaService;

        public FluxoCaixaController(ILancamentoRepository repo, IFluxoCaixaService fluxoCaixaService)
        {
            _repo = repo;
            _fluxoCaixaService = fluxoCaixaService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var previsao = _fluxoCaixaService.ObterPrevisao30Dias();
            return Ok(previsao);
        }

        // ✅ Novo endpoint para listar todos os lançamentos salvos (em memória ou Mongo)
        [HttpGet("lancamentos")]
        public IActionResult ObterLancamentos()
        {
            var lancamentos = _repo.ObterTodos();
            return Ok(lancamentos);
        }
    }
}
