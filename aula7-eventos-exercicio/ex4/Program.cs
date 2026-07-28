Console.WriteLine("===============");
Console.WriteLine("  Exercicio 3  ");
Console.WriteLine("===============");
Console.WriteLine("");


Estoque estoque = new Estoque("Arroz", 10, 5);
AlertaEstoque alerta = new AlertaEstoque();

// inscreve no evento
estoque.EstoqueBaixo += alerta.ExibirAlerta;

// saidas
estoque.Remover(3); // ainda ok
estoque.Remover(3); // aqui dispara o evento


class Estoque
{
    public string? Produto { get; set; }
    public int Quantidade { get; set; }
    public int LimiteMin { get; set; }

    public event Action<string, int>? EstoqueBaixo;

    public Estoque(string produto, int quantidade, int limiteMin)
    {
        Produto = produto;
        Quantidade = quantidade;
        LimiteMin = limiteMin;
    }

    public void Remover(int quantidade)
    {
        Quantidade -= quantidade;
        Console.WriteLine($"Removido {quantidade} unidades de {Produto}. Quantidade atual: {Quantidade}");

        if (Quantidade < LimiteMin)
        {
            EstoqueBaixo?.Invoke(Produto, Quantidade);
        }
    }
}

class AlertaEstoque
{
    public void ExibirAlerta(string produto, int quantidade)
    {
        Console.WriteLine($"Alerta: Estoque de {produto} está baixo! Quantidade atual: {quantidade}");
    }
}

