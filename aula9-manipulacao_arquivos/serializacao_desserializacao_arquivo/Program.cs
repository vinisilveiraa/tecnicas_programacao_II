using System.Text.Json;

// cria o arquivo
// salva na projeto\serializacao_desserializacao_arquivo\bin\Debug\net9.0
// colocar o caminho completo para personalizar isso

var caminho = "pessoas.json";

List<Pessoa> listaPessoas = new List<Pessoa>
{
    new Pessoa{ Nome="Ana", Idade= 20 },
    new Pessoa{ Nome="Carlos", Idade= 21 },
    new Pessoa{ Nome="Sandra", Idade= 19 },
};

//serialização em arquivo
if (!File.Exists(caminho))
{
    string jsonString = JsonSerializer.Serialize(listaPessoas, new JsonSerializerOptions { WriteIndented = true });
    File.WriteAllText(caminho, jsonString);
    Console.WriteLine("Arquivo Json gravado");
}

if(File.Exists(caminho))
{
    string conteudo = File.ReadAllText(caminho);
    List<Pessoa> listaConteudo = JsonSerializer.Deserialize<List<Pessoa>>(conteudo);
    foreach (var pes in listaConteudo)
    {
        Console.WriteLine($"Nome: {pes.Nome} - Idade: {pes.Idade}");
    }
}


public class Pessoa
{
    public string? Nome { get; set; }
    public int Idade { get; set; }

    // construtor padrão (sem argumentos) obrigatório para desserialização
    public Pessoa() { }
    public Pessoa(string nome, int idade)
    {
        Nome = nome;
        Idade = idade;
    }
}