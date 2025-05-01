using FluxoCaixa.Models;
using FluxoCaixa.Repositories;
using FluxoCaixa.Services;
using Microsoft.AspNetCore.Mvc;

namespace FluxoCaixa.Controllers
{
    [ApiController]
    [Route("api/fluxo-caixa")]
    public class FluxoCaixaController : ControllerBase
    {
        private readonly ILancamentoRepository _repo;
        private readonly FluxoCaixaService _fluxoCaixaService;

        public FluxoCaixaController(ILancamentoRepository repo, FluxoCaixaService fluxoCaixaService)
        {
            _repo = repo;
            _fluxoCaixaService = fluxoCaixaService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var previsao = _fluxoCaixaService.ObterPrevisaoDosProximos30Dias();
            return Ok(previsao);
        }
    }
}
