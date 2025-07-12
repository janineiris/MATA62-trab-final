namespace MATA62_Trab_Final.Comandos;

public class ReservaComando : IComando
{
    public void Executar(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Uso: res <codigoUsuario> <codigoLivro>");
            return;
        }

        string codigoUsuario = args[0];
        string codigoLivro = args[1];

        // Lógica da reserva aqui
        Console.WriteLine($"Usuário {codigoUsuario} reservou o livro {codigoLivro}");
    }
}