Vue = interface.
Axios = faz as chamadas HTTP.
ASP.NET API = executa a lógica.
Banco de dados = armazena os dados.

os endpoints são definidos no back-end (Controller).
o front apenas faz chamadas HTTP para esses endpoints usando Axios

primeiro vc chama qual vc ta usando:
    const API_URL = "http://localhost:5144/api/tarefas"; 

a rota fica no controller usado
    [Route("api/[controller]")]
[controller] é substituído automaticamente pelo nome da classe sem o sufixo "Controller"


========== axios ==========

Axios e uma biblioteca JavaScript usada para fazer requisições HTTP para uma API
pode pensar que e como um "mensageiro" entre o front/back

vc trocaria o fetch nativo pelo Axios
-> instala
-> chama:
    import axios from "axios";
    
-> use padrao
    const resposta = await axios.get(
      "http://localhost:5144/api/tarefas"
    );
    
    console.log(resposta.data);
(no projeto essa url ta como uma variavel API_URL)

-> oq ele retorna?
    const resposta = await axios.get(API_URL);

    retorna:
    {
      data: [
        {
          id: 1,
          titulo: "Estudar C#"
        }
      ],
      status: 200,
      statusText: "OK",
      headers: {...}
    }

por isso usar resposta.data pra pegar os dados

========== OS METODOS ==========

tem que ser todos definidos assim no controller
- usar ("{id}") se requerir um item

[HttpGet]               ->  busca dados
[HttpPost]              ->  cria dados
[HttpDelete("{id}")]    ->  exclui
[HttpPut("{id}")]       ->  atualiza um objeto inteiro
[HttpPatch("{id}")]     ->  atualiza parte de um objeto

no axios se chama:
    axios.get(API_URL)
    axios.post(API_URL, dados)
    axios.delete(API_URL/id)

    axios.put(API_URL/id, dadosAtualizados) 
    dadosAtualizados:{
        "titulo": "Nova tarefa",
        "descricao": "Nova descrição",
        "cancelado": false
    }

    axios.patch(API_URL/id, dadoAtualizado) 
    objeto: {
        "nome": value 
    } 
    // nesse projeto ele ta enviando so false


as vezes tbm e necessario enviar as configuracoes
    axios.patch(url`, conteudo, config)
    axios.patch(url`, conteudo, {
      headers: { 'Content-Type': 'application/json' }   // mostrando que o tipo de dado e um json
    });

    content-type seria para o http/servidor nao ter que adivinhar o formato dos dados especificando ele
    - "interprete o body da requisição como JSON", podendo ser: true, false, 123, "string", { obj }

API_URL e uma string entao em cada um seria (`${API_URL}/${id}`) -> no js


Clique no botão
    ↓
Método Vue é executado
    ↓
Axios faz requisição HTTP
    ↓
Controller recebe a requisição
    ↓
Controller chama o Repository
    ↓
Repository acessa o MongoDB
    ↓
MongoDB retorna os dados
    ↓
Repository retorna ao Controller
    ↓
Controller retorna resposta HTTP
    ↓
Axios recebe a resposta
    ↓
Vue atualiza a tela

========= mongodrive =========

Builders<T> -> classe utilitaria do MongoDriver, CONSTRUTOR DE OPERACOES para tarefa
- precisa pros metodos usados, ele nao ATUALIZA ele MONTA
Filter.Eq -> Filtro/Equal pega os documentos equivalentes

tem outros tbm:
    Filter.Eq()     -> igual
    Filter.Ne()     -> diferente
    Filter.Gt()     -> maior
    Filter.Gte()    -> maior/igual
    Filter.Lt()     -> menor
    Filter.Lte()    -> menor/igual

mais comandos (exemplos no codigo do repository)
    Find()
    InsertOneAsync()
    DeleteOneAsync()
    UpdateOneAsync()
    ReplaceOneAsync()
    Filter.Eq()


-> ex de find:
    _tarefasCollection
        .Find(t => t.Titulo == "Estudar Vue")
        .ToListAsync();

-> att de um campo
    var atualizacao = Builders<T>.Update.Set(x => x.Campo, novoCampo)

-> att de multiplos campos
    var atualizacao = Builders<T>.Update
        .Set(x => x.Campo, novoCampo)
        .Set(x => x.Campo2, novoCampo2)

-> conta registros
    var total =
        await _tarefasCollection.CountDocumentsAsync(_ => true);

-> Many - lida com colecoes
    // apenas os ativos
    var filtro = Builders<Tarefa>.Filter.Eq(
        t => t.Cancelado,
        false
    );
    var atualizacao = Builders<Tarefa>.Update.Set(
        t => t.Cancelado,
        true
    );
    await _tarefasCollection.UpdateManyAsync(
        filtro,
        atualizacao
    );

outros: 
    .ToListAsync() -> retorna listas
    .FirstOrDefaultAsync() -> pega primeira
    .SortBy / .SortByDescending
    .Limit(10)