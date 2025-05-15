using FluxoCaixa.Context;
using FluxoCaixa.Models;
using MongoDB.Driver;
using System.Collections.Generic;

namespace FluxoCaixa.Repositories
{
    public class LancamentoRepository : ILancamentoRepository
    {
        private readonly IMongoCollection<Lancamento> _lancamentos;

        public LancamentoRepository(MongoDbContext context)
        {
            _lancamentos = context.Lancamentos;
        }

        public void Adicionar(Lancamento lancamento)
        {
            _lancamentos.InsertOne(lancamento);
        }

        public IEnumerable<Lancamento> ObterTodos()
        {
            return _lancamentos.Find(l => true).ToList();
        }
    }
}
