// Usa-se FILE
// Escrita: WriteAllText (sobrescreve) ou AppendAllText (acrescenta)
// Leitura: ReadAllText (devolve string) ou ReadAllLines (devolve arraystring)

// Serialização: transforma um objeto em json, xml
// Desserialização: Transforma json, xml, em objeto. utiliza System.Text.json


var caminho = @"c:\Users\0201392511018\tecnicas_programacao_II\aula9-manipulacao_arquivos\ex1.txt";

if (!File.Exists(caminho))
{
    File.WriteAllText(caminho, "Autor desconhecido");
}

var novoTexto = "\r\nQuem canta seus males espanta" + Environment.NewLine + "Água mole em pedra dura tanto bate atá que fura\r\nCasa de ferreiro esperto é  de pau";
// pular linha \r\n ou Environment.NewLine

File.AppendAllText(caminho, novoTexto);
string conteudo = File.ReadAllText(caminho);
Console.WriteLine(conteudo);
