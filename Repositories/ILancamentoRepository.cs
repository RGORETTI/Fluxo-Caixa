using FluxoCaixa.Models;

namespace FluxoCaixa.Repositories
{
    public interface ILancamentoRepository
    {
        void Adicionar(Lancamento lancamento);
        IEnumerable<Lancamento> ObterTodos();
    }
}
