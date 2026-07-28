using System;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

List<Produto> produtos = new List<Produto>
{
    new Produto { Id = 1, Nome = "Mouse", Preco = 80, Categoria = "Periférico" },
    new Produto { Id = 2, Nome = "Teclado", Preco = 150, Categoria = "Periférico" },
    new Produto { Id = 3, Nome = "Monitor", Preco = 900, Categoria = "Tela" },
    new Produto { Id = 4, Nome = "Notebook", Preco = 3500, Categoria = "Computador" },
    new Produto { Id = 5, Nome = "Headset", Preco = 200, Categoria = "Audio" }
};

List<Produto> produtos_categoria = new List<Produto>
{
    new Produto
    {
        Id = 1,
        Nome = "Mouse",
        Preco = 80,
        IdCategoria = 1
    },

    new Produto
    {
        Id = 2,
        Nome = "Notebook",
        Preco = 3500,
        IdCategoria = 2
    },

    new Produto
    {
        Id = 3,
        Nome = "Monitor",
        Preco = 900,
        IdCategoria = 3
    }
};


List<Categoria> categorias = new List<Categoria>
{
    new Categoria { Id = 1, Nome = "Periféricos" },
    new Categoria { Id = 2, Nome = "Computadores" },
    new Categoria { Id = 3, Nome = "Telas" }
};

// estrutura base do LINQ
// lista.Metodo(x => condição)

// WHERE - Filtra elementos
// requer uma condição booleana

// pega produtos com preço maior que 200
var caros = produtos.Where(p => p.Preco > 200);

// SELECT - Seleciona propriedades especificas
// requer o que deseja retornar

// retorna apenas os nomes
var nomes = produtos.Select(p => p.Nome);


// FIRST / FirstOrDefault - Retorna o primeiro elemento
// LAST / LastOrDefault - Retorna o último elemento

// requer opcionalmente uma condição
// se nao encontrar nada FIRST da erro, FIRSTORDEFAULT retorna null

// primeiro produto acima de 100
var primeiro = produtos.First(p => p.Preco > 100);
var primeiro1 = produtos.FirstOrDefault(p => p.Id == 10);

var ultimo = produtos.Last();
var ultimo2 = produtos.LastOrDefault();


// ORDERBY - Ordena crescente
// ORDERBYDESCENDING - Ordena decrescente
// requer propriedade para ordenação

// ordena por preço
var crescente = produtos.OrderBy(p => p.Preco);
var decrescente = produtos.OrderByDescending(p => p.Preco);

// THENBY - Segunda ordenação

// primeiro categoria, depois preço
var lista = produtos
    .OrderBy(p => p.Categoria)
    .ThenBy(p => p.Preco);


// COUNT - Conta elementos

// quantidade total
int total = produtos.Count();
// quantidade com condição
int total2 = produtos.Count(p => p.Preco > 100);


// ANY - verifica se existe algum
// retorna true ou false

// existe produto acima de 3000?
bool existe = produtos.Any(p => p.Preco > 3000);


// ALL - verifica se TODOS atendem condição

// todos custam mais de 50?
bool todos = produtos.All(p => p.Preco > 50);


// SUM - soma valores
// soma dos preços
double soma = produtos.Sum(p => p.Preco);

// AVERAGE - média
// média dos preços
double media = produtos.Average(p => p.Preco);

// MAX - maior valor
// MIN - menor valor
double maior = produtos.Max(p => p.Preco);
double menor = produtos.Min(p => p.Preco);

// TAKE pega quantidade específica
// pega os 2 primeiros
var dois = produtos.Take(2);

// DISTINCT - remove duplicados
List<int> numeros = new List<int> { 1, 1, 2, 2, 3 };

var semDuplicados = numeros.Distinct();

// CONTAINS - verifica se contém valor
bool tem = produtos.Select(p => p.Nome)
                   .Contains("Mouse");


// GROUPBY - agrupa elementos
// requer chave do agrupamento

// agrupa por categoria
var grupos = produtos.GroupBy(p => p.Categoria);

// exemplo GROUPBY completo
foreach (var grupo in grupos)
{
    Console.WriteLine(grupo.Key);

    foreach (var produto in grupo)
    {
        Console.WriteLine(produto.Nome);
    }
}


// JOIN exemplo
// produto com categoria
var resultado = produtos.Join(
    categorias,              // outra lista
    p => p.IdCategoria,      // chave produto
    c => c.Id,               // chave categoria
    (p, c) => new            // retorno
    {
        Produto = p.Nome,
        Categoria = c.Nome
    }
);

// TOList - converte pra List
var tolist = produtos.Where(p => p.Preco > 100)
                    .ToList();
// TOARRAY - converte para array
var array = produtos.ToArray();



// FOREACH com LINQ
// lembrar que o linq vem como uma colecao de objetos, tem q usa foreach
var baratos = produtos.Where(p => p.Preco < 200);

foreach (var p in baratos)
{
    Console.WriteLine(p.Nome);
}



class Produto
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public double Preco { get; set; }
    public string? Categoria { get; set; }

    public int IdCategoria { get; set; }
    // chave estrangeira
}

class Categoria
{
    public int Id { get; set; }
    public string? Nome { get; set; }
}