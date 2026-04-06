// E um delegate pre-definido pela linguagem
// tem dois parametros: object sender e EventArgs e
// sem argumentos: EventArgs.Empty
// vantagem: mesma assinatura para os eventos


Console.WriteLine("==================================");
Console.WriteLine("   EventHandle - Sem Argumentos   ");
Console.WriteLine("==================================");
Console.WriteLine("");

Pedido pedido = new Pedido();

// registrar as classes assinantes
pedido.OnCriarPedido += EnviarEmail.email;
pedido.OnCriarPedido += EnviarSms.sms;

pedido.criarPedido();
Console.WriteLine("Fim do Pedido");


Console.ReadKey();
class Pedido
{
    public event EventHandler? OnCriarPedido;
    public void criarPedido()
    {
        Console.WriteLine("iniciando o criar pedido");

        if (OnCriarPedido != null)
        {
            OnCriarPedido(this, EventArgs.Empty);
        }
    }
}

class EnviarEmail
{
    public static void email(Object? sender, EventArgs e)
    {
        Console.WriteLine("Email Enviado");
    }
}

class EnviarSms
{
    public static void sms(Object? sender, EventArgs e)
    {
        Console.WriteLine("SMS Enviado");
    }
}