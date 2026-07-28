using MongoDB.Driver;
using TodoApi.Models;

namespace TodoApi.Repositories
{
    public class TarefaRepository
    {
        // representa a colecao de tarefas do mongo
        private readonly IMongoCollection<Tarefa> _tarefasCollection;

        // repository faz a call com o mongo, assim o controller so chama ele
        public TarefaRepository(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MongoConnection"); // pega connection string
            var client = new MongoClient(connectionString);     // cria um objeto capaz de conversar com o mongo
            var database = client.GetDatabase("TodoDatabase");  // seleciona o banco (mongo cria se n existir)
            _tarefasCollection = database.GetCollection<Tarefa>("Tarefas"); // dentro da db, pega a collection que vai trabalhar no repository
        }

        // metodo get das tarefas, retorna elas
        public async Task<List<Tarefa>> ObterTodasTarefasAsync() =>
            await _tarefasCollection.Find(_ => true).ToListAsync();
        // post da tarefa
        public async Task CriarTarefaAsync(Tarefa novaTarefa) =>
            await _tarefasCollection.InsertOneAsync(novaTarefa);

        // delete, requere id de parametro
        public async Task DeletarAsync(string id)
        {
            // Builders<T> -> classe utilitaria do MongoDriver, CONSTRUTOR DE OPERACOES para tarefa 
            // Filter.Eq - Filtro/Equal pega os documentos equivalentes
            var filtro = Builders<Tarefa>.Filter.Eq(tarefa => tarefa.Id, id);
            await _tarefasCollection.DeleteOneAsync(filtro); // deleta com o filtro de parametro
        }
        // alterar status, requere o id do item e o booleano para atualizar de parametro
        public async Task AlterarStatusAsync(string id, bool cancelado)
        {
            var filtro = Builders<Tarefa>.Filter.Eq(tarefa => tarefa.Id, id); // pega a tarefa
            var atualizacao = Builders<Tarefa>.Update.Set(tarefa => tarefa.Cancelado, cancelado); // altera o campo .Cancelado
            await _tarefasCollection.UpdateOneAsync(filtro, atualizacao);
        }
        // atualiza inteira, precisa do obj atualizado
        public async Task AtualizarTotalAsync(string id, Tarefa tarefaAtualizada)
        {
            var filtro = Builders<Tarefa>.Filter.Eq(tarefa => tarefa.Id, id); // pega a tarefa
            tarefaAtualizada.Id = id; // cria o campo id que nao foi enviado dentro do obj
            await _tarefasCollection.ReplaceOneAsync(filtro, tarefaAtualizada);
        }
    }
}
