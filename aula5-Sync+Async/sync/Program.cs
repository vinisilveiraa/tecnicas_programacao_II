Console.WriteLine("Café da manha sincrono");
cafeDaManha();
Console.WriteLine("Fim do cafe da manha");


static void cafeDaManha()
{
    Console.WriteLine("Preparar cafe");
    var cafe = prepararCafe();

    Console.WriteLine("\nPreparar Pao");
    var pao = prepararPao();

    ServirCafe(cafe, pao);
}

static void ServirCafe(Cafe cafe, Pao pao)
{
    Console.WriteLine("\nServindo cafe da manha");
    Thread.Sleep(2000);
    Console.WriteLine("\nCafe da manha servido");
}

static Pao prepararPao()
{
    Console.WriteLine("\n Partir pao");
    Thread.Sleep(2000);
    Console.WriteLine("\n Passar manteiga");
    Thread.Sleep(2000);
    return new Pao();
}

static Cafe prepararCafe()
{
    Console.WriteLine("\n Ferver Agua");
    Thread.Sleep(2000);
    Console.WriteLine("\n Coar cafe");
    Thread.Sleep(2000);
    return new Cafe();
}

internal class Cafe {}

internal class Pao {}