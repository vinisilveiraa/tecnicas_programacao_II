// criando objeto
Pedido pedido = new Pedido();

// registrando métodos no evento
pedido.AoCriarPedido += Enviar.EnviarEmail;
pedido.AoCriarPedido += Enviar.EnviarSms;

// executando ação principal
pedido.CriarPedido();

Console.ReadKey();



// classe principal
class Pedido
{
    // evento padrão do C#
    // usa:
    // object sender
    // EventArgs e
    public event EventHandler? AoCriarPedido;

    public void CriarPedido()
    {
        Console.WriteLine("Pedido criado");

        // dispara o evento
        // this -> objeto que disparou
        // EventArgs.Empty -> sem dados extras
        AoCriarPedido?.Invoke(this, EventArgs.Empty);
    }
}


// classe pra centralizar metodos 
class Enviar
{
    // método assinante
    public static void EnviarEmail(object? sender, EventArgs e)
    {
        Console.WriteLine("Email enviado");
    }

    // método assinante
    public static void EnviarSms(object? sender, EventArgs e)
    {
        Console.WriteLine("SMS enviado");
    }
}