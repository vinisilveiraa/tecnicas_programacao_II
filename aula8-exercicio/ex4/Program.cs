// ==================
//       EX - 4
// ==================


var clientes = new List<Cliente>
{
    new Cliente { Nome = "João Silva", Cpf = "123.456.789-00" },
    new Cliente { Nome = "Maria Oliveira", Cpf = "987.654.321-00" },
    new Cliente { Nome = "Carlos Souza", Cpf = "111.222.333-44" },
    new Cliente { Nome = "Ana Costa", Cpf = "555.666.777-88" }
};

var produtos = new List<Produto>
{
    new Produto { Nome = "Notebook", Preco = 3500.00 },
    new Produto { Nome = "Mouse", Preco = 80.50 },
    new Produto { Nome = "Teclado", Preco = 150.00 },
    new Produto { Nome = "Monitor", Preco = 1200.00 }
};

var pedidos = new List<Pedidos>
{
    new Pedidos
    {
        Quantidade = 1,
        DataPedido = new DateOnly(2026, 4, 10),
        Cliente = clientes[0],
        Produto = produtos[0]
    },new Pedidos
    {
        Quantidade = 1,
        DataPedido = new DateOnly(2026, 4, 14),
        Cliente = clientes[0],
        Produto = produtos[1]
    },
    new Pedidos
    {
        Quantidade = 2,
        DataPedido = new DateOnly(2026, 4, 11),
        Cliente = clientes[1],
        Produto = produtos[1]
    },
    new Pedidos
    {
        Quantidade = 1,
        DataPedido = new DateOnly(2026, 4, 12),
        Cliente = clientes[2],
        Produto = produtos[2]
    },
    new Pedidos
    {
        Quantidade = 3,
        DataPedido = new DateOnly(2026, 4, 13),
        Cliente = clientes[3],
        Produto = produtos[3]
    }
};
Console.WriteLine("----------------------------------------------");


var pedidosClientes = pedidos.GroupBy(p => p.Cliente);

// groupby retorna um grupo IGrouping
foreach (var grupo in pedidosClientes)
{
    Console.WriteLine($"Cliente: {grupo.Key?.Nome}");

    foreach (var pedido in grupo)
    {
        Console.WriteLine($"  Produto: {pedido.Produto?.Nome} | Qtde: {pedido.Quantidade} | Data: {pedido.DataPedido}");
    }

    Console.WriteLine();
}

Console.WriteLine();
Console.WriteLine("----------------------------------------------");
Console.WriteLine();

// B

var acimaClientes = pedidos.Where(p => p.Produto?.Preco >= 500).Select(p => p.Cliente?.Nome).Distinct();
// distinct para nao repetir clientes

foreach (var item in acimaClientes)
{
    Console.WriteLine($"{item}");
}

Console.WriteLine();
Console.WriteLine("----------------------------------------------");
Console.WriteLine();


var pedidosPorCliente = pedidos.GroupBy(p => p.Cliente)
    .Select(grupo => new
    {
        Cliente = grupo.Key?.Nome,
        QuantidadePedidos = grupo.Count()
    });

foreach (var item in pedidosPorCliente)
{
    Console.WriteLine($"Cliente: {item.Cliente} | Pedidos: {item.QuantidadePedidos}");
}

class Cliente
{
    public string? Nome { get; set; }
    public string? Cpf { get; set; }
}

class Produto
{
    public string? Nome { get; set; }
    public double Preco { get; set; }
}

class Pedidos
{
    public int Quantidade { get; set; }
    public DateOnly DataPedido { get; set; }

    public Cliente? Cliente { get; set; }
    public Produto? Produto { get; set; }
}