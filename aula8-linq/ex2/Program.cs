
// ================
//       EX 2
// ================

List<string> nomes = new List<string>() { "Ana", "Maria", "Paulo", "Pedro", "Lais", "Hugo" };

var resultado = from m in nomes where m.Contains("o") select m;


Console.WriteLine("Exemplo Base");
foreach (var nome in resultado)
{
    Console.Write(nome);
}

