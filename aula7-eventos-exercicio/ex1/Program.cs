
Console.WriteLine("===============");
Console.WriteLine("  Exercicio 1  ");
Console.WriteLine("===============");
Console.WriteLine("");

Operacao soma = new Operacao(Somar);
Operacao sub = new Operacao(Subtrair);
Operacao multiplicar = new Operacao(Multiplicar);
Operacao dividir = new Operacao(Dividir);

soma.Invoke(1, 5);
sub.Invoke(6, 5);
multiplicar.Invoke(3, 3);
dividir.Invoke(10, 5);

static void Somar(double n1, double n2)
{
    double resultado = n1 + n2;
    Console.WriteLine($"{n1} + {n2} = {resultado}");
}
static void Subtrair(double n1, double n2)
{
    double resultado = n1 - n2;
    Console.WriteLine($"{n1} - {n2} = {resultado}");

}
static void Multiplicar(double n1, double n2)
{
    double resultado = (n1 * n2);
    Console.WriteLine($"{n1} x {n2} = {resultado}");
}
static void Dividir(double n1, double n2)
{
    double resultado = n1 / n2;
    Console.WriteLine($"{n1} : {n2} = {resultado}");
}
Console.ReadKey();

public delegate void Operacao(double n1, double n2);

