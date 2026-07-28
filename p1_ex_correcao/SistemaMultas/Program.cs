using System.Collections;
using System.Text.Json;

CentralDeMultas central = new CentralDeMultas();
central.CarregarDeJson();
//Registrando um ouvinte
central.MultaRegistrada += VerificarMulta.Mensagem;

// Criando algumas multas para teste
central.Registrar(new Multa { Placa = "ABC-1234", TipoInfracao = "Velocidade", Valor = 180.50m, Data = DateTime.Now });
central.Registrar(new Multa { Placa = "XYZ-9876", TipoInfracao = "Embriaguez", Valor = 2934.70m, Data = DateTime.Now });
central.Registrar(new Multa { Placa = "KJA-4455", TipoInfracao = "Farol apagado", Valor = 130.16m, Data = DateTime.Now });


central.FiltrarPorValor(500);

Console.WriteLine("\nFim do processamento.");
Console.ReadKey();


public class Multa
{
    public Multa() { }
    
    public string? Placa { get; set; }
    public string? TipoInfracao { get; set; }
    public decimal Valor { get; set; }
    public DateTime Data { get; set; }
    
}

// Delegate
public delegate void MultaHandler(Multa m);

// Classe CentralDeMultas
public class CentralDeMultas
{
    // Evento
    public event MultaHandler MultaRegistrada;
    

    private List<Multa> Multas = new List<Multa>();
    public void Registrar(Multa m)
    {
        Multas.Add(m);
        Console.WriteLine($"\nRegistrando multa: {m.Placa}...");

        // Disparando o evento (se houver ouvintes)
        MultaRegistrada?.Invoke(m);

        //salva no json
        SalvarEmJson();
    }

    // Métodos json
    public void SalvarEmJson()
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(Multas, options);
        File.WriteAllText("multas.json", jsonString);
        
    }

    public void CarregarDeJson()
    {
        if (File.Exists("multas.json"))
        {
            string jsonString = File.ReadAllText("multas.json");
            Multas = JsonSerializer.Deserialize<List<Multa>>(jsonString) ?? new List<Multa>();
            Console.WriteLine("Dados carregados do arquivo JSON.");
            ListarMultas(Multas);
        }
    }

    // Consulta LINQ
    public void FiltrarPorValor(decimal valor)
    {
        var multasCaras = Multas.Where(m => m.Valor > valor).ToList();

        Console.WriteLine($"\n--- Multas acima de {valor:C2} ---");
        ListarMultas(multasCaras);
    }
    //listar multas
    public void ListarMultas(IEnumerable<Multa> multas)
    {
        foreach(var multa in multas)
        {
            Console.WriteLine($"Placa:{multa.Placa} - Tipo de Infracao: {multa.TipoInfracao} - Valor: {multa.Valor:C2} - Data da Multa: {multa.Data}/n");
        }
    }
    
}
class VerificarMulta
{
    public static void Mensagem(Multa m)
    {
        if (m.Valor > 500)
        {

            Console.WriteLine("ALERTA: MULTA GRAVE DETECTADA!");

        }
    }
}
