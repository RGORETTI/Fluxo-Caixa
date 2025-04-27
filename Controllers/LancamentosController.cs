using FluxoCaixa.DTOs;
using FluxoCaixa.Models;
using FluxoCaixa.Repositories;
using FluxoCaixa.Services;
using Microsoft.AspNetCore.Mvc;

namespace FluxoCaixa.Controllers
{
    [ApiController]
    [Route("api/lancamentos")]
    public class LancamentosController : ControllerBase
    {
        private readonly ILancamentoRepository _repository;
        private readonly FluxoCaixaService _fluxoCaixaService;

        public LancamentosController(ILancamentoRepository repository, FluxoCaixaService fluxoCaixaService)
        {
            _repository = repository;
            _fluxoCaixaService = fluxoCaixaService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] LancamentoDto lancamentoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var lancamento = new Lancamento
            {
                DataDeLancamento = lancamentoDto.DataDeLancamento,
                TipoDeLancamento = (TipoLancamento)lancamentoDto.TipoDeLancamento,
                Descricao = lancamentoDto.Descricao,
                Conta = lancamentoDto.Conta,
                Banco = lancamentoDto.Banco,
                TipoDeConta = lancamentoDto.TipoDeConta,
                CpfCnpj = lancamentoDto.CpfCnpj,
                ValorDoLancamento = lancamentoDto.ValorDoLancamento
            };

            if (!_fluxoCaixaService.PodeLancarComNovoValor(lancamento, out var motivo))
                return BadRequest(new { erro = motivo });

            _repository.Adicionar(lancamento);
            return Ok(lancamento);
        }
    }
}
