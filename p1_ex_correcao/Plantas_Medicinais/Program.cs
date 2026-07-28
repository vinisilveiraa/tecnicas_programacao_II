using System.Text.Json;

InventarioDePlantas inventario = new InventarioDePlantas();

// Ouvinte 1: Gravar log.txt
inventario.PlantaEmExticao += GravarLog.LogTxt;

// Ouvinte 2: Exibir no console
inventario.PlantaEmExticao += Exibir.ExibirColeta;

// Criar um arquivo JSON de teste para demonstrar
if (!File.Exists("plantas.json")) { 
    CriarJsonTeste();
}
// carregar dados arquivo json
inventario.CarregarDeArquivoJson("plantas.json");

// Mostrar as consultas LINQ
inventario.MostrarConsultasColetas();

Console.WriteLine("\nProcesso Finalizado");
static void CriarJsonTeste()
{
    var lista = new List<Planta>
    {
        new Planta { NomePopular = "Samambaia-Açu", NomeCientifico = "Dicksonia sellowiana", LocalColeta = "Mata Atlântica", EmExtincao = true, DataColeta = DateTime.Now },
        new Planta { NomePopular = "Ipê Amarelo", NomeCientifico = "Handroanthus albus", LocalColeta = "Cerrado", EmExtincao = false, DataColeta = DateTime.Now },
        new Planta { NomePopular = "Pau-Brasil", NomeCientifico = "Paubrasilia echinata", LocalColeta = "Mata Atlântica", EmExtincao = true, DataColeta = DateTime.Now },
        new Planta { NomePopular = "Ipê Amarelo", NomeCientifico = "Handroanthus albus", LocalColeta = "Mata Atlântica", EmExtincao = false, DataColeta = DateTime.Now.AddDays(-1) }
    };
    File.WriteAllText("plantas.json", JsonSerializer.Serialize(lista));
}
    
// Classe Planta
public class Planta
{
    public string? NomeCientifico { get; set; }
    public string? NomePopular { get; set; }
    public string? LocalColeta { get; set; }
    public bool EmExtincao { get; set; }
    public DateTime DataColeta { get; set; }
}

//Delegate e Evento
public delegate void PlantaHandler(Planta p);

public class InventarioDePlantas
{
    public event PlantaHandler PlantaEmExticao;
    private List<Planta> Plantas = new List<Planta>();

    // Método Carregar e Disparar Evento
    public void CarregarDeArquivoJson(string caminho)
    {
        if (!File.Exists("plantas.json"))
        {
            Console.WriteLine("Arquivo JSON não encontrado!");
            return;
        }

        string jsonString = File.ReadAllText(caminho);
        Plantas = JsonSerializer.Deserialize<List<Planta>>(jsonString) ?? new List<Planta>();

        foreach (var p in Plantas)
        {
            if (p.EmExtincao)
            {
                // Dispara o evento para cada planta em extinção encontrada
                PlantaEmExticao?.Invoke(p);
            }
        }
    }

    // Consultas LINQ
    public void MostrarConsultasColetas()
    {
        Console.WriteLine("\n--- INVENTÁRIO ---");

        // Quantidade de coletas por planta (Nome Popular)
        var coletasPorPlanta = Plantas
            .GroupBy(p => p.NomePopular)
            .Select(g => new { Nome = g.Key, Qtd = g.Count() });

        Console.WriteLine("\nQuantidade de coletas por planta:");
        foreach (var item in coletasPorPlanta)
            Console.WriteLine($"- {item.Nome}: {item.Qtd} coleta(s)");

        // Agrupar por Local de Coleta
        var agrupadoPorLocal = Plantas.GroupBy(p => p.LocalColeta);

        Console.WriteLine("\nPlantas agrupadas por Local:");
        foreach (var grupo in agrupadoPorLocal)
        {
            Console.WriteLine($"\nLocal: {grupo.Key}");
            foreach (var p in grupo)
                Console.WriteLine($"  > {p.NomePopular} ({p.NomeCientifico})");
        }
    }
}
class GravarLog
{
    public static void LogTxt(Planta p)
    {
        string logMsg = $"{p.NomePopular} | {p.DataColeta:dd/MM/yyyy} | Alerta: Planta em perigo de extinção.\n";
        File.AppendAllText("log.txt", logMsg);
    }
}
class Exibir
{
    public static void ExibirColeta(Planta p)
    {
       
        Console.WriteLine($"[ALERTA EXTINÇÃO] Nome: {p.NomePopular} | Local: {p.LocalColeta}");
        
    }
}