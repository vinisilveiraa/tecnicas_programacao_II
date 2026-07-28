
using System.Text.Json;

var inventario = new InventarioPlantas();
var monitor = new MonitorPlantas();

inventario.PlantaEmExtincao += monitor.PlantaEmExtincao;
inventario.PlantaEmExtincao += monitor.GravarLog;

var caminho = @"c:/Fatec Estudos/tecnicas_programacao_II/p1_ex/plantas.json";

inventario.CarregarDeArquivoJson(caminho);


delegate void PlantaHandler(Planta p);
class Planta
{
    public string? NomeCientifico { get; set; }
    public string? NomePopular { get; set; }
    public string? LocalColeta { get; set; }
    public bool EmExtincao { get; set; }
    public DateTime DataColeta { get; set; }
    public Planta(string cientifico, string popular, string local, bool extincao, DateTime data)
    {
        NomeCientifico = cientifico;
        NomePopular = popular;
        LocalColeta = local;
        EmExtincao = extincao;
        DataColeta = data;
    }

    public Planta() { }
}

class InventarioPlantas
{
    List<Planta> plantas = new();
    public event PlantaHandler? PlantaEmExtincao;

    public void CarregarDeArquivoJson(string caminho)
    {
        if (!File.Exists(caminho))
        {
            Console.WriteLine("Caminho nao encontrado");
            return;
        }

        string conteudo = File.ReadAllText(caminho);
        List<Planta>? listaPlantas = JsonSerializer.Deserialize<List<Planta>>(conteudo);

        if (listaPlantas == null) return;

        foreach (var p in listaPlantas)
        {
            plantas.Add(p);
            if (p.EmExtincao)
            {
                PlantaEmExtincao?.Invoke(p);
            }
        }

    }
}

class MonitorPlantas
{
    public void PlantaEmExtincao(Planta p)
    {
        if (p.EmExtincao)
        {
            Console.WriteLine($"Planta em perigo de extincao: {p.NomePopular} - {p.DataColeta}");
        }
    }
    public void GravarLog(Planta p)
    {
        var caminho = @"c:/Fatec Estudos/tecnicas_programacao_II/p1_ex/log.txt";
        var formatada = $"Alerta: Planta em perigo de extincao: {p.NomePopular} - {p.DataColeta}" + Environment.NewLine;

        File.AppendAllText(caminho, formatada);
        string conteudo = File.ReadAllText(caminho);
    }
}