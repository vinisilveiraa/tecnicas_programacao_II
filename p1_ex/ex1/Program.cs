
using System.Text.Json;

var central = new CentralDeMultas();
var monitor = new MonitorMultas();

central.MultaRegistrada += monitor.VerificarGravidade;

var multa1 = new Multa(
    "ABC1234",
    "Excesso de velocidade",
    700,
    DateOnly.FromDateTime(DateTime.Now)
);
var multa2 = new Multa(
    "ABC4321",
    "Carro atrasado",
    500,
    DateOnly.FromDateTime(DateTime.Now)
);

central.Registrar(multa1);
central.Registrar(multa2);
central.Listar();


//central.SalvarJson();
//central.CarregarJson();


central.FiltrarValor(500);
central.FiltrarPorPlaca("ABC4321");


delegate void MultaHandler(Multa m);
class Multa
{
    public Multa(string placa, string tipo, double valor, DateOnly data)
    {
        Placa = placa;
        TipoInfracao = tipo;
        Valor = valor;
        Data = data;
    }
    public Multa() { }

    public string? Placa { get; set; }
    public string? TipoInfracao { get; set; }
    public double Valor { get; set; }
    public DateOnly Data { get; set; }
}


class CentralDeMultas
{
    private List<Multa> multas = new();

    public event MultaHandler? MultaRegistrada;

    private string caminho = @"c:/Fatec Estudos/tecnicas_programacao_II/p1_ex/multas.json";

    public void Registrar(Multa m)
    {
        multas.Add(m);
        Console.WriteLine("Multa registrada");

        MultaRegistrada?.Invoke(m);
    }
    public void Listar()
    {
        foreach (Multa m in multas)
        {
            Console.WriteLine($"Placa: {m.Placa} - Infracao: {m.TipoInfracao} - Valor: {m.Valor} : {m.Data}");
        }
    }

    public void SalvarJson()
    {
        var json = JsonSerializer.Serialize(multas, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(caminho, json);
        Console.WriteLine("Arquivo Json gravado.");
    }
    public void CarregarJson()
    {
        if (!File.Exists(caminho))
        {
            Console.WriteLine("Multa nao encontrada");
        }
        else
        {
            string conteudo = File.ReadAllText(caminho);
            List<Multa>? listaConteudo = JsonSerializer.Deserialize<List<Multa>>(conteudo);

            if (listaConteudo != null)
            {
                foreach (var m in listaConteudo)
                {
                    Console.WriteLine($"Placa: {m.Placa} - Infracao: {m.TipoInfracao} - Valor: {m.Valor} : {m.Data}");
                }
            }
        }
    }


    public void FiltrarValor(double valor)
    {
        var filtro = multas.Where(m => m.Valor > valor);
        foreach (var m in filtro)
        {
            Console.WriteLine("Multas encontradas:");
            Console.WriteLine($"Placa: {m.Placa} / Valor: {m.Valor}");
        }
    }
    public void FiltrarPorPlaca(string placa)
    {
        var filtro = multas.Where(m => m.Placa == placa);
        foreach (var m in filtro)
        {
            Console.WriteLine("Multa encontrada:");
            Console.WriteLine($"Placa: {m.Placa} / Infracao: {m.TipoInfracao}");
        }
    }
}

class MonitorMultas
{
    public void VerificarGravidade(Multa m)
    {
        if (m.Valor > 500)
        {
            Console.WriteLine($"MULTA GRAVE DETECTADA! Valor de R$:{m.Valor}");
        }
    }
}