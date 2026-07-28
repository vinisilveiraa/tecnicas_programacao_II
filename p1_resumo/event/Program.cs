// criando objeto
Pedido pedido = new Pedido();

// registrando métodos assinantes
// esses metodos ficam esperando o evento acontecer
pedido.AoCriarPedido += EnviarEmail;
pedido.AoCriarPedido += EnviarSms;

// executando ação principal
pedido.CriarPedido();

Console.ReadKey();



// métodos chamados pelo evento
static void EnviarEmail()
{
    Console.WriteLine("Email enviado");
}
static void EnviarSms()
{
    Console.WriteLine("SMS enviado");
}



// delegate do evento
delegate void PedidoEvent();

// classe principal
class Pedido
{
    // criando o evento
    public event PedidoEvent? AoCriarPedido;

    // ação principal
    public void CriarPedido()
    {
        Console.WriteLine("Pedido criado");

        // dispara o evento
        // executa todos os métodos ouvintes registrados
        AoCriarPedido?.Invoke();
    }
}