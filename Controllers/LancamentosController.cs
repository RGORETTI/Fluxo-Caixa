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
        private readonly IFluxoCaixaService _fluxoCaixaService;

        public LancamentosController(ILancamentoRepository repository, IFluxoCaixaService fluxoCaixaService)
        {
            _repository = repository;
            _fluxoCaixaService = fluxoCaixaService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] LancamentoDto lancamentoDto)
        {
            // Se chegou aqui, FluentValidation já validou o DTO

            var lancamento = new Lancamento
            {
                Data = lancamentoDto.Data,
                TipoDeLancamento = (TipoLancamento)lancamentoDto.TipoDeLancamento,
                Descricao = lancamentoDto.Descricao,
                Conta = lancamentoDto.Conta,
                Banco = lancamentoDto.Banco,
                TipoDeConta = lancamentoDto.TipoDeConta,
                CpfCnpj = lancamentoDto.CpfCnpj,
                Valor = lancamentoDto.Valor
            };

            if (!_fluxoCaixaService.ValidarLancamento(lancamento, out var motivo))
                return BadRequest(new { erro = motivo });

            _repository.Adicionar(lancamento);
            return Ok(lancamento);
        }
    }
}
