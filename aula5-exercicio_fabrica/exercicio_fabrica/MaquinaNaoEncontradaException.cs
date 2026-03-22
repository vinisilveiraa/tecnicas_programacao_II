
[Serializable]
internal class MaquinaNaoEncontradaException : Exception
{
    public MaquinaNaoEncontradaException()
    {
    }

    public MaquinaNaoEncontradaException(string? message) : base(message)
    {
    }

    public MaquinaNaoEncontradaException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}