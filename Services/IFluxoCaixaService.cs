using FluxoCaixa.Models;

namespace FluxoCaixa.Services
{
    public interface IFluxoCaixaService
    {
        bool ValidarLancamento(Lancamento lancamento, out string motivo);
        IEnumerable<FluxoCaixaDia> ObterPrevisao30Dias();
    }
}
