


delegate void MultaHandler(Multa m);
event MultaHandler MultaRegistrada;
class Multa
{
    public string Placa { get; set; }
    public string TipoInfracao { get; set; }
    public double Valor { get; set; }
    public DateOnly Data { get; set; }
}

class CentralDeMultas
{
    public static ListaMultas()
    {
    }
    public static RegistrarMulta(Multa m)
    {
 
    }
    public static SalvarJson(string json) { }
    public static CarregarJson(string json) { }
}