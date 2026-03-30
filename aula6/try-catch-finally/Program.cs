
try
{
    Console.WriteLine("Digite o Dividendo");
    int dividendo = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Digite o Divisor");
    int divisor = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("");

    var resultado = dividendo / divisor;
    Console.WriteLine($"O resultado de {dividendo} {divisor} = {resultado}");
}
// format exception = não corresponde aos requisitos do método invocado
catch (FormatException)
{
    Console.WriteLine("");
    Console.WriteLine("Os valores devem ser inteiros");
}

// quando a mensagem ex contem format da esse erro (faz a mesma coisa do de cima)
catch (Exception ex) when (ex.Message.Contains("format"))
{
    Console.WriteLine("");
    Console.WriteLine("Os valores devem ser inteiros");
}

// auto explicativo
catch (DivideByZeroException)
{
    Console.WriteLine("");
    Console.WriteLine("O Divisor nao pode ser 0");
}

// generico
catch (Exception ex)
{
    Console.WriteLine("");
    Console.WriteLine($"Problema na divisao: {ex.Message}");
}

// será executado independentemente se há ou não uma exceção
finally
{
    Console.WriteLine("");
    Console.WriteLine("Acabou a Divisao");
}