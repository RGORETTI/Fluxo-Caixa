using MongoDB.Driver;
using FluxoCaixa.Models;

namespace FluxoCaixa.Context
{
    public class MongoDbContext
    {
        public IMongoCollection<Lancamento> Lancamentos { get; }

        public MongoDbContext(IConfiguration configuration)
        {
            // Obtém a string de conexão do appsettings.json
            var connectionString = configuration.GetConnectionString("MongoDb");

            // Cria cliente e conecta ao banco de dados
            var client = new MongoClient(connectionString);

            // Se você quiser deixar o nome do banco configurável:
            // var databaseName = configuration["DatabaseSettings:DatabaseName"] ?? "FluxoCaixaDb";

            var database = client.GetDatabase("FluxoCaixaDb");

            // Define a coleção
            Lancamentos = database.GetCollection<Lancamento>("Lancamentos");
        }
    }
}
