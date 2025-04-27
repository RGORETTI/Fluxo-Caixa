using FluxoCaixa.Models;
using FluxoCaixa.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FluxoCaixa.Controllers
{
    [ApiController]
    [Route("api/fluxo-caixa")]
    public class FluxoCaixaController : ControllerBase
    {
        private readonly ILancamentoRepository _repo;

        public FluxoCaixaController(ILancamentoRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var hoje = DateTime.Today;
            var lancamentos = _repo.ObterTodos();
            var resultado = new List<FluxoCaixaDia>();
            decimal saldoAnterior = 0;

            for (int i = 0; i <= 30; i++)
            {
                var dia = hoje.AddDays(i);
                var doDia = lancamentos.Where(l => l.DataDeLancamento.Date == dia);

                decimal entradas = doDia.Where(l => l.TipoDeLancamento == TipoLancamento.Recebimento).Sum(l => l.ValorDoLancamento);
                decimal saidas = doDia.Where(l => l.TipoDeLancamento == TipoLancamento.Pagamento).Sum(l => l.ValorDoLancamento);
                decimal saldo = entradas - saidas;

                var diaFluxo = new FluxoCaixaDia
                {
                    Data = dia.ToString("dd-MM-yyyy"),
                    Entradas = doDia.Where(l => l.TipoDeLancamento == TipoLancamento.Recebimento)
                                    .Select(e => new LancamentoResumo
                                    {
                                        Data = e.DataDeLancamento.ToString("dd-MM-yyyy"),
                                        Valor = $"R$ {e.ValorDoLancamento:N2}"
                                    }).ToList(),
                    Saidas = doDia.Where(l => l.TipoDeLancamento == TipoLancamento.Pagamento)
                                  .Select(e => new LancamentoResumo
                                  {
                                      Data = e.DataDeLancamento.ToString("dd-MM-yyyy"),
                                      Valor = $"R$ {e.ValorDoLancamento:N2}"
                                  }).ToList(),
                    Total = saldo.ToString("'R$ '000,000.00"), 
                    PosicaoDoDia = saldoAnterior != 0 ? $"{((saldo - saldoAnterior) / Math.Abs(saldoAnterior) * 100):F1}%" : "0.0%"
                };
                resultado.Add(diaFluxo);
                saldoAnterior = saldo;
            }

            return Ok(resultado);
        }
    }
}
