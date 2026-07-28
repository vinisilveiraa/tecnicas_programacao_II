// 1 - Criando o delegate
// Ele só aceita métodos:
// sem retorno (void)
// e sem parâmetros ()  --  EXEMPLO COM PARAMETROS NA PASTA DE DELEGATE

// 2 - Associando um método ao delegate
MeuDelegate del = MostrarMensagem;

// 3 - Executando o método através do delegate
del();

Console.ReadKey();

// Método compatível com o delegate
static void MostrarMensagem()
{
    Console.WriteLine("Olá, usando delegate!");
}

// descricao acima (1)
delegate void MeuDelegate();