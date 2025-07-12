namespace MATA62_Trab_Final.Comandos;

public class ReservaComando : IComando
{
    public void Executar(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Uso: dev <idUsuario> <idLivro>");
            return;
        }

        string idUsuario = args[0];
        string idLivro = args[1];

        // Lógica da reserva aqui
        Console.WriteLine($"Usuário {idUsuario} reservou o livro {idLivro}");
    }
}