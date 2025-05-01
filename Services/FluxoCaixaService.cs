using FluxoCaixa.Models;
using FluxoCaixa.Repositories;

namespace FluxoCaixa.Services
{
    public class FluxoCaixaService : IFluxoCaixaService
    {
        private readonly ILancamentoRepository _repository;

        public FluxoCaixaService(ILancamentoRepository repository)
        {
            _repository = repository;
        }

        public bool ValidarLancamento(Lancamento lancamento, out string motivo)
        {
            motivo = "";

            if (lancamento.TipoDeLancamento != TipoLancamento.Recebimento &&
                lancamento.TipoDeLancamento != TipoLancamento.Pagamento)
            {
                motivo = "Tipo de lançamento inválido. Só é permitido Recebimento (1) ou Pagamento (2).";
                return false;
            }

            var todos = _repository.ObterTodos();
            decimal saldoAtual = 0;

            foreach (var l in todos)
            {
                saldoAtual += l.TipoDeLancamento == TipoLancamento.Recebimento
                    ? l.Valor
                    : -l.Valor;
            }

            saldoAtual += lancamento.TipoDeLancamento == TipoLancamento.Recebimento
                ? lancamento.Valor
                : -lancamento.Valor;

            if (saldoAtual < -20000)
            {
                motivo = "Saldo negativo máximo de R$ -20.000,00 ultrapassado.";
                return false;
            }

            if (lancamento.Data < DateTime.Today)
            {
                motivo = "Não é permitido lançar com data no passado.";
                return false;
            }

            return true;
        }

        public IEnumerable<FluxoCaixaDia> ObterPrevisao30Dias()
        {
            var hoje = DateTime.Today;
            var lancamentos = _repository.ObterTodos();
            var resultado = new List<FluxoCaixaDia>();
            decimal saldoAnterior = 0;

            for (int i = 0; i <= 30; i++)
            {
                var dia = hoje.AddDays(i);
                var doDia = lancamentos.Where(l => l.Data.Date == dia);

                decimal entradas = doDia.Where(l => l.TipoDeLancamento == TipoLancamento.Recebimento).Sum(l => l.Valor);
                decimal saidas = doDia.Where(l => l.TipoDeLancamento == TipoLancamento.Pagamento).Sum(l => l.Valor);
                decimal saldo = entradas - saidas;

                var diaFluxo = new FluxoCaixaDia
                {
                    Data = dia.ToString("dd-MM-yyyy"),
                    Entradas = doDia.Where(l => l.TipoDeLancamento == TipoLancamento.Recebimento)
                        .Select(e => new LancamentoResumo
                        {
                            Data = e.Data.ToString("dd-MM-yyyy"),
                            Valor = $"R$ {e.Valor:N2}"
                        }).ToList(),
                    Saidas = doDia.Where(l => l.TipoDeLancamento == TipoLancamento.Pagamento)
                        .Select(e => new LancamentoResumo
                        {
                            Data = e.Data.ToString("dd-MM-yyyy"),
                            Valor = $"R$ {e.Valor:N2}"
                        }).ToList(),
                    Total = saldo.ToString("'R$ '000,000.00"),
                    PosicaoDoDia = saldoAnterior != 0
                        ? $"{((saldo - saldoAnterior) / Math.Abs(saldoAnterior) * 100):F1}%"
                        : "0.0%"
                };

                resultado.Add(diaFluxo);
                saldoAnterior = saldo;
            }

            return resultado;
        }
    }
}
