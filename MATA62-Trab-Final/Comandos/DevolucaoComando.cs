namespace MATA62_Trab_Final.Comandos;

public class DevolucaoComando : IComando
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

        // Lógica da devolução aqui
        Console.WriteLine($"Usuário {idUsuario} devolveu o livro {idLivro}");
    }
}