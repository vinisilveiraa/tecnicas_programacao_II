using System;
using System.Threading.Tasks;

var fabrica = new Fabrica { Nome = "Fábrica 1" };

var equipamento = new Equipamento
{
    Nome = "Motor X",
    DataFabricacao = new DateTime(2020, 5, 10)
};

var maquina = new Maquina
{
    Modelo = "ABC123",
    HoraOperacao = "10h",
    Equipamento = equipamento
};

fabrica.AdicionarMaquina(maquina);

fabrica.ListarMaquinas();

var operador = new Operador { Nome = "João" };

try
{
    await operador.OperarMaquinaAsync(fabrica, "ABC123");
}
catch (MaquinaNaoEncontradaException ex)
{
    Console.WriteLine(ex.Message);
}
