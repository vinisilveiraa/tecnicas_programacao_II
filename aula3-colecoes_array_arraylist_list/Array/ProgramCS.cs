// ======================================
//                 array                                
//    nao cresce dinamicamente, 1 tipo    
// ======================================


using System.Xml;

int[] numeros = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9 , 10 };


// ainda nao alocou a memoria (apenas quando definir os elementos)
int[] valores;
valores = new int[2] { 10, 20 };

string[] nomes = new string[5] { "Maria", "Joao", "Paulo", "Pedro", "Silvia" };


// classe array
Array.Reverse(numeros);
Array.Sort(nomes);
int indice = Array.BinarySearch(nomes, "Pedro");
Console.WriteLine($"Encontrou Pedro no indice: {indice}");

// mostrar com foreach
foreach (var dado in nomes)
{
    Console.WriteLine(dado);
}

for(int i = 0; i <2; i++)
{
    Console.WriteLine(valores[i]);
}
Console.WriteLine("");
Console.WriteLine("Matrizes");
Console.WriteLine("");

// Matriz - mais de uma dimencao
int[,] Mat1;
Mat1 = new int[2, 3];
Mat1[0,0] = 1;


int[,] Mat2 = new int[3, 2] { { 1, 2 }, { 3, 4 }, { 5, 6 } };

for (int i = 0; i < Mat2.GetLength(0); i++)
{
    for (int j = 0; j < Mat2.GetLength(1); j++)
    {
        Console.Write(Mat2[i, j]  + " ");
    }
}

Console.WriteLine("");

foreach (var dado in Mat2)
{
    Console.Write(dado + " ");
}