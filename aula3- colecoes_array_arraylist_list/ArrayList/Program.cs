// ========================================
//                 array list              
//    cresce dinamicamente, varios tipos  
// ========================================

using System.Collections;

ArrayList lista = new ArrayList(5);
ArrayList lista2 = new(2);
//adiciona um elemento na ordem
lista.Add("Maria");
lista.Add(18);
lista.Add(1.65);
lista.Add(true);
lista.Add(null);

// adiciona um elemento no indice especificado -- insert(indice, elemento)
lista.Insert(3, 65);

// adiciona uma colecao no final do arraylist
int[] array1 = { 1, 2, 3 };
lista.AddRange(array1);

// adiciona uma colecao a partir do indice especificado
lista.InsertRange(0, array1);

// remove -- remove um elemento da arraylist especifico
lista.Remove("Maria");

// removeat -- remove de um indice especifico 
lista.RemoveAt(1);

// removerange
lista.RemoveRange(2, 4);

// mostrar 
foreach (var i in lista)
{
    Console.WriteLine(i);
}


var lista3 = new ArrayList() { "Maria", "Paulo", "Ana" };
lista3.Sort();
var res1 = lista3.Contains("a"); // true

foreach (var i in lista3)
{
    Console.WriteLine(i);
};

if (res1)
{
    Console.WriteLine("Contem");
}
else
{
    Console.WriteLine("Nao Contem");
}

lista3.Clear();

foreach (var i in lista3)
{
    Console.WriteLine(i);
}
