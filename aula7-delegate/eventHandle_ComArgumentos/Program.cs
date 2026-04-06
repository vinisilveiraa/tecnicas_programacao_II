// E um delegate pre-definido pela linguagem
// tem dois parametros: object sender e EventArgs e
// sem argumentos: EventArgs.Empty
// vantagem: mesma assinatura para os eventos


Console.WriteLine("==================================");
Console.WriteLine("   EventHandle - Com Argumentos   ");
Console.WriteLine("==================================");
Console.WriteLine("");

Pedido pedido = new Pedido();

// registrar as classes assinantes
pedido.OnCriarPedido += EnviarEmail.email;
pedido.OnCriarPedido += EnviarSms.sms;

pedido.criarPedido("maria@gmail.com", "(14)9999-8888");
Console.WriteLine("Fim do Pedido");


class PedidoEventArgs : EventArgs
{
    public string? Email { get; set; }
    public string? Telefone { get; set; }
}

class Pedido
{
    public event EventHandler<PedidoEventArgs>? OnCriarPedido;
    public void criarPedido(string email, string telefone)
    {
        Console.WriteLine("iniciando o criar pedido");

        if (OnCriarPedido != null)
        {
            OnCriarPedido(this, new PedidoEventArgs
            {
                Email = email,
                Telefone = telefone
            });
        }
    }
}

class EnviarEmail
{
    public static void email(Object? sender, PedidoEventArgs e)
    {
        Console.WriteLine($"Email enviado para: {e.Email}");
    }
}

class EnviarSms
{
    public static void sms(Object? sender, PedidoEventArgs e)
    {
        Console.WriteLine($"SMS enviado para: {e.Telefone}");
    }
}