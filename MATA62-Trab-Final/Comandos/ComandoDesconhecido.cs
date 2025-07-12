namespace MATA62_Trab_Final.Comandos;

public class ComandoDesconhecido : IComando
{
    private readonly string _nome;

    public ComandoDesconhecido(string nome)
    {
        _nome = nome;
    }

    public void Executar(string[] args)
    {
        Console.WriteLine($"Comando desconhecido: {_nome}");
    }
}