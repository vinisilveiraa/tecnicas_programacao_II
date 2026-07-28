using System.Threading;

Console.WriteLine("===============");
Console.WriteLine("  Exercicio 2  ");
Console.WriteLine("===============");
Console.WriteLine("");

// definindo classe, temperatura e seus limites
ArCondicionado ar = new ArCondicionado(25, 18, 30);
// abre a classe monitor
Monitor monitor = new Monitor();

// conecta o evento com o alarme
ar.AlarmeTemperatura += monitor.Alarme;

ar.AjustarTemperatura(38); // fora
ar.AjustarTemperatura(23); // deboa
ar.AjustarTemperatura(16); // fora




// cria o delegate
delegate void AlarmeTemperatura();
class ArCondicionado
{
    public ArCondicionado(double temperatura, double limiteInferior, double limiteSuperior)
    {
        Temperatura = temperatura;
        LimiteInferior = limiteInferior;
        LimiteSuperior = limiteSuperior;
    }
    public event AlarmeTemperatura? AlarmeTemperatura;

    public double Temperatura;
    public double LimiteSuperior;
    public double LimiteInferior;
    
    // metodo para ajustar a temperatura chamando o check
    public void AjustarTemperatura(double novaTemperatura)
    {
        Temperatura = novaTemperatura;
        ChecarTemperatura();
    }

    // se estiver fora do limite chama o evento
    public void ChecarTemperatura()
    {
        if (Temperatura > LimiteSuperior || Temperatura < LimiteInferior)
        {
            AlarmeTemperatura?.Invoke();
        }
    }
}

class Monitor
{
    public void Alarme()
    {
        Console.WriteLine("Temperatura fora do limite!");
    }
}