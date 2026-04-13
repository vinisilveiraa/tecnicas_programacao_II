// ========================================
//     LINQ - Language Integrated Query
// ========================================

// * Conjunto de funcionalidadades que permite escrever consultas diratamente no c#, em coleções de dados. Ex: Listas, arrays, Banco de Dados, XML etc...
// * Parecido com SQL
// * Funciona com qualquer coleção que implemente IEnumerable
// * Metodos:
//     Where, Select, OrderBy, First, FirstOrDefault, Any, All, Join, GroupBy
// * As consultas so são executadas quando interadas e retornam IEnumerable


using System.Net.Http.Headers;


// ================
//       EX 1
// ================


int[] numeros = { 1, 2, 3, 4, 5, 6 };

// selecionar n ( numero em numeros) se ele for divisivel por 2
var pares = from n in numeros
            where n % 2 == 0
            select n;

// outra sintaxe usando lambda
var pares2 = numeros.Where(x => x % 2 == 0);


Console.WriteLine("Exemplo base");
foreach (var num in pares)
{
    Console.Write(num + " ");
}

Console.WriteLine("");
Console.WriteLine("Exemplo Usando Lambda");
foreach (var num in pares2)
{
    Console.Write(num + " ");
}
Console.WriteLine("");
