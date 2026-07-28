// é um tipo seguro que funciona como um "ponteiro de método" ou referência para funções
// permitindo passar métodos como parâmetros, retornar métodos, e encapsular comportamentos


Console.WriteLine("===================");
Console.WriteLine("  Usando Delegate  ");
Console.WriteLine("===================");
Console.WriteLine("");

// segunda etapa
MeuDelegate del1 = new MeuDelegate(MeuMetodo);
MeuDelegate del2 = MeuMetodo;
MeuDelegate del3 = (msg) => Console.WriteLine(msg);

// terceira etapa
del1.Invoke("Minha Mensagem 1");
del2("Minha Mensagem 2");
del3("Minha Mensagem 3");

static void MeuMetodo(string mensagem)
{
    Console.WriteLine(mensagem);
}
Console.ReadKey();

// primeira etapa
public delegate void MeuDelegate(string msg);