// acoes que executam mediante a uma condicao

// 1- define o delegate
// 2- define na classe onde a acao dispara o evento
// 3- no metodo fazer o invoke
// 4- registrar os metodos assinantes, que contem as acoes a serem executadas quando o evento ocorrer

Console.WriteLine("=================");
Console.WriteLine("  Usando Evento  ");
Console.WriteLine("=================");
Console.WriteLine("");

Pedido pedido = new Pedido();

// registrar as classes assinantes
pedido.OnCriarPedido += EnviarEmail.email;
pedido.OnCriarPedido += EnviarSms.sms;

pedido.criarPedido();
Console.WriteLine("Fim do Pedido");


Console.ReadKey();
delegate void PedidoEvent();
class Pedido
{
    public event PedidoEvent? OnCriarPedido;
    public void criarPedido()
    {
        Console.WriteLine("iniciando o criar pedido");

        if (OnCriarPedido != null)
        {
            OnCriarPedido();
        }
    }
}

class EnviarEmail
{
    public static void email()
    {
        Console.WriteLine("Email Enviado");
    }
}

class EnviarSms
{
    public static void sms()
    {
        Console.WriteLine("SMS Enviado");
    }
}