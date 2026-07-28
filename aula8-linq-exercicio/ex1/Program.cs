// ==================
//       EX - 1
// ==================


List<int> inteiros = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

var somaImpares = inteiros.Where(i => i % 2 != 0).Sum();

Console.WriteLine(somaImpares);