// ==================
//       EX - 3
// ==================



List<Pessoa> pessoas = new List<Pessoa>() {
    new Pessoa { Nome = "João", Idade = 17 },
    new Pessoa { Nome = "Maria", Idade = 22 },
    new Pessoa { Nome = "Carlos", Idade = 30 },
    new Pessoa { Nome = "Pedro", Idade = 12 },
    new Pessoa { Nome = "Joana", Idade = 45 },
    new Pessoa { Nome = "Roberto", Idade = 33 }
};

var maiorIdade = pessoas
    .Where(p => p.Idade >= 18)
    .OrderBy(p => p.Nome);

Pessoa.Mostrar(maiorIdade);


class Pessoa
{
    public string? Nome { get; set; }
    public int Idade { get; set; }

    internal static void Mostrar(IEnumerable<Pessoa> pessoa)
    {
        foreach (var item in pessoa)
        {
            Console.WriteLine($"{item.Nome} - {item.Idade}");
        }
    }
}
