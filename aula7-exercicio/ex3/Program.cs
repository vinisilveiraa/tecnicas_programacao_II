Console.WriteLine("===============");
Console.WriteLine("  Exercicio 3  ");
Console.WriteLine("===============");
Console.WriteLine("");


Botao botao = new Botao();
ContadorCliques contador = new ContadorCliques();

botao.Clique += contador.AoClicar;

botao.SimularClique();
botao.SimularClique();
botao.SimularClique();


class Botao
{
    public event Action? Clique;

    public void SimularClique()
    {
        Console.WriteLine("Botao foi clicado!");
        Clique?.Invoke();
    }
}

class ContadorCliques
{
    private int count = 0;

    public void AoClicar()
    {
        count++;
        Console.WriteLine($"Contagem de cliques: {count}");
    }
}