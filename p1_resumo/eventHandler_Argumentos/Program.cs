// criando objeto
Pedido pedido = new Pedido();

// registrando métodos assinantes
pedido.AoCriarPedido += Enviar.EnviarEmail;
pedido.AoCriarPedido += Enviar.EnviarSms;

// criando pedido com dados
pedido.CriarPedido(
    "maria@gmail.com",
    "(14)99999-8888"
);

Console.ReadKey();


// classe para transportar dados do evento
class PedidoEventArgs : EventArgs
{
    public string? Email { get; set; }
    public string? Telefone { get; set; }
}

// classe principal
class Pedido
{
    // evento usando argumentos personalizados
    public event EventHandler<PedidoEventArgs>? AoCriarPedido;

    public void CriarPedido(string email, string telefone)
    {
        Console.WriteLine("Pedido criado");

        // criando objeto com dados do evento
        PedidoEventArgs dados = new PedidoEventArgs
        {
            Email = email,
            Telefone = telefone
        };

        // dispara o evento
        // this -> quem disparou
        // dados -> informações extras
        AoCriarPedido?.Invoke(this, dados);
    }
}


// classe para centralizar metodos
class Enviar
{
    public static void EnviarEmail(object? sender, PedidoEventArgs e)
    {
        Console.WriteLine($"Email enviado para: {e.Email}");
    }

    // assinante do evento
    public static void EnviarSms(object? sender, PedidoEventArgs e)
    {
        Console.WriteLine($"SMS enviado para: {e.Telefone}");
    }
}