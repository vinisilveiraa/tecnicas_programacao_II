using System;
using System.Collections.Generic;
using System.Linq;

public class Fabrica
{
    public string? Nome { get; set; }

    public ICollection<Maquina> Maquinas { get; set; } = new List<Maquina>();

    public void AdicionarMaquina(Maquina maquina)
    {
        Maquinas.Add(maquina);
    }

    public void ListarMaquinas()
    {
        foreach (var m in Maquinas)
        {
            Console.WriteLine($"Nome: {m.Equipamento?.Nome} | Modelo: {m.Modelo} | Data Fabricação: {m.Equipamento?.DataFabricacao} | Nº Série: {m.NumeroSerie}");
        }
    }

    public Maquina? BuscarMaquinaPorModelo(string modelo)
    {
        return Maquinas.FirstOrDefault(m => m.Modelo == modelo);
    }
}