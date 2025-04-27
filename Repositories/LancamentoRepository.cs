using FluxoCaixa.Models;
using System.Collections.Concurrent;

namespace FluxoCaixa.Repositories
{
    public class LancamentoRepository : ILancamentoRepository
    {
        private readonly ConcurrentBag<Lancamento> _lancamentos = new();

        public void Adicionar(Lancamento lancamento)
        {
            _lancamentos.Add(lancamento);
        }

        public IEnumerable<Lancamento> ObterTodos()
        {
            return _lancamentos;
        }
    }
}
