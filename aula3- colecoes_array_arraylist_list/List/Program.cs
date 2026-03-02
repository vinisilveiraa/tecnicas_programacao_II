// ====================================
//                 list                                
//    cresce dinamicamente, 1 tipos   
// ====================================


using System.Net.Http.Headers;

var lista = new List<string>();

lista.Add("Laranja");

List<int> lista2 = new();

var lista3 = new List<string>()
{ "Brasil", "`Portugal", "Espanha" };

List<Carro> Carros = new List<Carro>();

Carros.Add(new Carro("Fiat", "Toro", 2026));

public class Carro
{
    public Carro(string marca, string modelo, int ano)
    {
        Marca = marca;
        Modelo = modelo;
        Ano = ano;

    }
    public string? Marca { get; set; }
    public string? Modelo { get; set; }
    public int? Ano { get; set; }

}