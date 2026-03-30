ContaBancaria conta = new ContaBancaria(300.00m);
try
{
    conta.Sacar("100");
}
catch (SaldoInsuficienteException ex)
{
    Console.WriteLine("Erro de saldo" + ex.Message);
}

try
{
    conta.Sacar("500");
}
catch (SaldoInsuficienteException ex)
{
    Console.WriteLine("Erro de saldo" + ex.Message);
}

try
{
    conta.Sacar("assasasa");
}
catch (SaldoInsuficienteException ex)
{
    Console.WriteLine("Erro de saldo" + ex.Message);
}

public class ContaBancaria
{
    public decimal Saldo { get; private set; }
    public ContaBancaria(decimal saldoInicial)
    {
        Saldo = saldoInicial;
    }

    public void Sacar(string valorTexto)
    {
        try
        {
            decimal valor = decimal.Parse(valorTexto);
            if (valor > Saldo)
            {
                throw new SaldoInsuficienteException($"Saldo insuficiente. Saldo atual {Saldo}. " + $"Tentativa de saque no valor de {valor}");
            }
            Saldo -= valor;
            Console.WriteLine($"Saldo atual: {Saldo}");
        }
        catch (FormatException fe)
        {
            throw new ApplicationException("Erro ao converter o valor do saque", fe);
        }
        finally
        {
            Console.WriteLine("Fim do Saque");
        }
    }
}

public class SaldoInsuficienteException : Exception
{

    public SaldoInsuficienteException() { }
    public SaldoInsuficienteException(string mensagem) : base(mensagem) { }
    public SaldoInsuficienteException(string mensagem, Exception innerException) : base(mensagem, innerException) { }
}