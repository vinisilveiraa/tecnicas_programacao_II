// ==================
//       EX - 2
// ==================


List<int> numeros = new List<int> { 5, 12, 8, 20, 3, 15, 7 };

var maior = numeros.Max(n => n);
Console.WriteLine(maior);


var soma = numeros.Where(n => n >= 10).Sum();
Console.WriteLine(soma);