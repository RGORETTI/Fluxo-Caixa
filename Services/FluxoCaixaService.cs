using FluxoCaixa.Models;
using FluxoCaixa.Repositories;

namespace FluxoCaixa.Services
{
    public class FluxoCaixaService
    {
        private readonly ILancamentoRepository _repository;

        public FluxoCaixaService(ILancamentoRepository repository)
        {
            _repository = repository;
        }

        public bool PodeLancarComNovoValor(Lancamento novoLancamento, out string motivo)
        {
            motivo = "";

            // ✅ Validação 1: Tipo de Lançamento só pode ser Recebimento ou Pagamento
            if (novoLancamento.TipoDeLancamento != TipoLancamento.Recebimento &&
                novoLancamento.TipoDeLancamento != TipoLancamento.Pagamento)
            {
                motivo = "Tipo de lançamento inválido. Só é permitido Recebimento (1) ou Pagamento (2).";
                return false;
            }

            var todosLancamentos = _repository.ObterTodos();

            decimal saldoAtual = 0;
            foreach (var lanc in todosLancamentos)
            {
                if (lanc.TipoDeLancamento == TipoLancamento.Recebimento)
                    saldoAtual += lanc.ValorDoLancamento;
                else if (lanc.TipoDeLancamento == TipoLancamento.Pagamento)
                    saldoAtual -= lanc.ValorDoLancamento;
            }

            if (novoLancamento.TipoDeLancamento == TipoLancamento.Recebimento)
                saldoAtual += novoLancamento.ValorDoLancamento;
            else if (novoLancamento.TipoDeLancamento == TipoLancamento.Pagamento)
                saldoAtual -= novoLancamento.ValorDoLancamento;

            // ✅ Validação 2: Limite de saldo negativo
            if (saldoAtual < -20000)
            {
                motivo = "Saldo negativo máximo de R$ -20.000,00 ultrapassado.";
                return false;
            }

            // ✅ Validação 3: Data não pode ser no passado
            if (novoLancamento.DataDeLancamento.Date < DateTime.Today)
            {
                motivo = "Não é permitido lançar com data no passado.";
                return false;
            }

            return true;
        }
    }
}
