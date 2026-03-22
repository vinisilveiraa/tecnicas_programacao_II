using System;
using System.Collections.Generic;

public class Maquina
{
    public string? Modelo { get; set; }
    public string? HoraOperacao { get; set; }

    public Guid NumeroSerie { get; } = Guid.NewGuid();

    private string? _observacao;
    public string Observacao
    {
        set { _observacao = value; }
    }

    public Equipamento? Equipamento { get; set; }

    public ICollection<Operador> Operadores { get; set; } = new List<Operador>();
}