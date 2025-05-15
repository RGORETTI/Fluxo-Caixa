using FluxoCaixa.Models;
using System.Collections.Generic;

namespace FluxoCaixa.Repositories
{
    public interface ILancamentoMongoRepository
    {
        void Adicionar(Lancamento lancamento);
        IEnumerable<Lancamento> ObterTodos();
    }
}
