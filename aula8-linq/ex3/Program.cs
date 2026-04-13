// ================
//       EX 3
// ================

var listaProdutos = Produto.GetProdutos();

Console.WriteLine("Produtos Eletrônicos:");
var produtosEletronicos = listaProdutos.Where(p => p.Categoria == "Eletrônicos");
Produto.Mostrar(produtosEletronicos);

Console.WriteLine("-----------------------------------------------------");


Console.WriteLine("Produtos caros e com estoque maior que 5:");
var produtosCaros = listaProdutos.Where(p => p.Estoque > 5 && p.Preco >= 1000.00);
Produto.Mostrar(produtosCaros);

Console.WriteLine("-----------------------------------------------------");


Console.WriteLine("Produtos com Estoque baixo");
var estoqueBaixo = listaProdutos.Where(p => p.Estoque < 15).OrderBy(p => p.Nome);
Produto.Mostrar(estoqueBaixo);

Console.WriteLine("-----------------------------------------------------");


Console.WriteLine("Produtos ordenados por categoria e nome");
var produtosOrdenados = listaProdutos.OrderBy(p => p.Categoria).ThenBy(p => p.Nome);
Produto.Mostrar(produtosOrdenados);

Console.WriteLine("-----------------------------------------------------");


Console.WriteLine("Produtos com preco maior que 500 com aumento de 10% ordenado por nome e criando um tipo anonimo");
var resultado = listaProdutos.Where(p => p.Preco > 500).OrderBy(p => p.Nome)
    .Select(p =>
    new
    {
        nomeProduto = p.Nome?.ToUpper(),
        precoModificado = p.Preco * 1.1
    });

//var resultado = listaProdutos.Where(p => p.Preco > 500).OrderBy(p => p.Nome)
//    .Select(p =>
//    new Produto
//    {
//        Nome = p.Nome.ToUpper(),
//        Preco = p.Preco * 1.1,
//        Id = p.Id,
//        Estoque = p.Estoque,
//        Categoria = p.Categoria
//    });

Produto.MostrarTipoAnonimo(resultado);

Console.WriteLine("-----------------------------------------------------");


Console.WriteLine("Valor Medio dos precos dos eletronicos");
double media = listaProdutos.Where(p => p.Categoria == "Eletrônicos").Average(p => p.Preco);
Console.WriteLine($"Media: {media}");

Console.WriteLine("-----------------------------------------------------");


Console.WriteLine("Produtos com preco maior que 200 com aumento de 20% ordenado pelo preco e criando um tipo anonimo");
var resultado2 = listaProdutos.Where(p => p.Preco > 200).OrderBy(p => p.Preco)
    .Select(p =>
    new
    {
        nomeProduto = p.Nome?.ToUpper(),
        precoModificado = p.Preco * 0.8
    });

//var resultado2 = listaProdutos.Where(p => p.Preco > 200).OrderBy(p => p.Preco)
//    .Select(p =>
//    new Produto
//    {
//        Nome = p.Nome.ToUpper(),
//        Preco = p.Preco * 0.8,
//        Id = p.Id,
//        Estoque = p.Estoque,
//        Categoria = p.Categoria
//    });

Produto.MostrarTipoAnonimo(resultado2);

Console.WriteLine("-----------------------------------------------------");

Console.ReadKey();

public class Produto
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public double Preco { get; set; }
    public int Estoque { get; set; }
    public string? Categoria { get; set; }


    public static List<Produto> GetProdutos()
    {
        List<Produto> Produtos = new List<Produto>() {

        new Produto { Id = 1, Nome = "Camiseta", Preco = 29.99, Estoque = 50, Categoria = "Roupa" },
        new Produto { Id = 2, Nome = "Meia", Preco = 20.99, Estoque = 100, Categoria = "Roupa" },
        new Produto { Id = 3, Nome = "Tenis Nike", Preco = 400.50, Estoque = 10, Categoria = "Calçado" },
        new Produto { Id = 4, Nome = "Celular", Preco = 5000.99, Estoque = 150, Categoria = "Eletrônicos" },
        new Produto { Id = 5, Nome = "Mochila", Preco = 150.15, Estoque = 50, Categoria = "Acessórios" },
        new Produto { Id = 6, Nome = "Relógio", Preco = 320.99, Estoque = 15, Categoria = "Acessórios" },
        new Produto { Id = 7, Nome = "Cadeira", Preco = 260.20, Estoque = 150, Categoria = "Móveis" },
        new Produto { Id = 8, Nome = "Mesa", Preco = 930, Estoque = 30, Categoria = "Móveis" },
        new Produto { Id = 9, Nome = "Smart TV", Preco = 1500.80, Estoque = 5, Categoria = "Eletrônicos" },
        new Produto { Id = 9, Nome = "Notebook", Preco = 6900.75, Estoque = 100, Categoria = "Eletrônicos" }

        };

        return Produtos;
    }

    public static void Mostrar(IEnumerable<Produto> produtos)
    {
        foreach (var item in produtos)
        {
            Console.WriteLine($"{item.Id} - {item.Nome} - {item.Preco} - {item.Estoque} - {item.Categoria}");
        }
    }

    public static void MostrarTipoAnonimo(IEnumerable<dynamic> produtos)
    {
        foreach (var item in produtos)
        {
            Console.WriteLine($"{item.nomeProduto} - {item.precoModificado}");
        }
    }

}