using System;
using System.Threading.Tasks;

public class Operador
{
    public string? Nome { get; set; }

    public async Task OperarMaquinaAsync(Fabrica fabrica, string modelo)
    {
        Console.WriteLine($"{Nome} está tentando operar a máquina modelo {modelo}");

        await Task.Delay(2000);

        var maquina = fabrica.BuscarMaquinaPorModelo(modelo);

        if (maquina == null)
        {
            throw new MaquinaNaoEncontradaException(
                $"Máquina modelo {modelo} não encontrada na fábrica {fabrica.Nome}"
            );
        }

        Console.WriteLine($"{Nome} agora está operando a máquina modelo {maquina.Modelo}");

        await Task.Delay(3000);
    }
}