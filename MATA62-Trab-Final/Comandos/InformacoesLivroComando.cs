namespace MATA62_Trab_Final.Comandos;

public class InformacoesLivroComando : IComando
{
    public void Executar(string[] args)
    {
        if (args.Length < 1)
        {
            Console.WriteLine("Uso: liv <codigoLivro>");
            return;
        }

        string codigoLivro = args[0];
        
        Console.WriteLine($"Informações do livro {codigoLivro}");
    }
}