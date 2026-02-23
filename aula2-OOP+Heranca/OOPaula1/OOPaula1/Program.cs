
// ==============
//     usando
// ==============


using OOPaula1;

Produto prod1 = new Produto();
prod1.Nome = "Caderno";
prod1.Preco = 50.90;

Produto prod2 = new Produto("Lápis", 1.50);

Console.WriteLine("Nome: " + prod1.Nome); // concatenacao
Console.WriteLine($"Preco: {prod1.Preco}"); // interpolacao

Console.WriteLine();

Console.WriteLine($"Nome: {prod2.Nome}");
Console.WriteLine($"Preco: {prod2.Preco}");

Console.WriteLine();
Console.WriteLine("==========================================");
Console.WriteLine();

// ===================
//   Produto2 Objeto
// ===================

Produto2 prod3 = new("Borracha", 4.60, 100);
prod3.Exibir();

Console.ReadKey();
// ==============
//   declarando
// ==============


public class Produto
{
    public Produto() { }// definir um construtor padrao (sem parametros) para nao ter erro no prod1, que tem seus atributos definidos depois

    public Produto(string nome, double Preco)
    {
        Nome = nome; // definindo nome como nome
        this.Preco = Preco; // em caixa alta precisa de atributo
    }

    public string? Nome { get; set; }
    public double Preco { get; set; }
}