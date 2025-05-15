using FluxoCaixa.Models;
using MongoDB.Driver;
using FluxoCaixa.Context;

namespace FluxoCaixa.Repositories
{
    public class LancamentoMongoRepository : ILancamentoRepository
    {
        private readonly IMongoCollection<Lancamento> _lancamentos;

        public LancamentoMongoRepository(MongoDbContext context)
        {
            _lancamentos = context.Lancamentos;
        }

        public void Adicionar(Lancamento lancamento)
        {
            if (lancamento == null)
                throw new ArgumentNullException(nameof(lancamento));

            _lancamentos.InsertOneAsync(lancamento).Wait(); // compatível com interface síncrona
        }

        public IEnumerable<Lancamento> ObterTodos()
        {
            return _lancamentos.Find(_ => true).ToList(); // também compatível com IEnumerable
        }
    }
}