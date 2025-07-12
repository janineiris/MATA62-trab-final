namespace MATA62_Trab_Final.Comandos;

public class EmprestimoComando : IComando
{
    public void Executar(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Uso: emp <idUsuario> <idLivro>");
            return;
        }

        string idUsuario = args[0];
        string idLivro = args[1];

        // Lógica do empréstimo aqui
        Console.WriteLine($"Usuário {idUsuario} emprestou o livro {idLivro}");
    }
}