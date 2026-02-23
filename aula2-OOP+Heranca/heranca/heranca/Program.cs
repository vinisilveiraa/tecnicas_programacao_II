Aluno aluno1 = new("Paulo", "111.111.111-11", "123456789");
Console.WriteLine($"Nome: {aluno1.Nome}\n CPF: {aluno1.Cpf}\n  RA: {aluno1.Ra}");

Console.WriteLine();

Console.WriteLine("Digite o NOME do Professor:");
var nomeProf = Console.ReadLine();
Console.WriteLine("Digite o CPF do Professor:");
var cpfProf = Console.ReadLine();
Console.WriteLine("Digite a TITULACAO do Professor:");
var titulacaoProf = Console.ReadLine();

Console.WriteLine();

Professor prof1 = new(nomeProf, cpfProf, titulacaoProf);
Professor.Exibir(prof1);

Console.ReadKey();

public class Pessoa
{
    public Pessoa(string? nome, string? cpf)
    {
        Nome = nome;
        Cpf = cpf;
    }
    public string? Nome { get; set; }
    public string? Cpf { get; set; }
}

public class Aluno : Pessoa
{
    public Aluno(string? nome, string? cpf, string ra) : base(nome, cpf)
    {
        Ra = ra;
    }

    public string? Ra { get; set; }
}

public class Professor : Pessoa
{
    public Professor(string? nome, string? cpf, string titulacao) : base(nome, cpf)
    {
        Titulacao = titulacao;
    }
    public string? Titulacao { get; set; }

    public static void Exibir(Professor prof) => Console.WriteLine($"Nome: {prof.Nome}\nCPF: {prof.Cpf}\nTitulacao: {prof.Titulacao}");
}
