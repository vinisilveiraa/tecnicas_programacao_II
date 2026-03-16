Console.WriteLine("Café da manha Asincrono");
await cafeDaManhaAsync();
Console.WriteLine("Fim do cafe da manha");


static async Task cafeDaManhaAsync()
{
    Console.WriteLine("Preparar cafe");
    var TarefaCafe = prepararCafeAsync();
    Console.WriteLine("\nPreparar Pao");
    var TarefaPao = prepararPaoAsync();

    var cafe = await (TarefaCafe);
    var pao = await (TarefaPao);

    ServirCafeAsync(cafe, pao);
}

static void ServirCafeAsync(Cafe cafe, Pao pao)
{
    Console.WriteLine("\nServindo cafe da manha");
    Thread.Sleep(2000);
    Console.WriteLine("\nCafe da manha servido");
}

static async Task<Pao> prepararPaoAsync()
{
    Console.WriteLine("\n Partir pao");
    await Task.Delay(2000);
    Console.WriteLine("\n Passar manteiga");
    await Task.Delay(2000);
    return new Pao();
}

static async Task<Cafe> prepararCafeAsync()
{
    Console.WriteLine("\n Ferver Agua");
    await Task.Delay(2000);
    Console.WriteLine("\n Coar cafe");
    await Task.Delay(2000);
    return new Cafe();
}

internal class Cafe { }

internal class Pao { }