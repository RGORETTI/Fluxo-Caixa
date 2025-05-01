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
    }
}
