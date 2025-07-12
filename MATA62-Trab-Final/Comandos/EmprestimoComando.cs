namespace MATA62_Trab_Final.Comandos;

public class EmprestimoComando : IComando
{
    public void Executar(string[] args)
    {
        if (args.Length < 2)
        {
            GerenciadorMensagens.ImprimeErroComando("emp","Necessário passar os parâmetros <codigoUsuario> <codigoLivro>");
            return;
        }

        string codigoUsuario = args[0];
        string codigoLivro = args[1];

        // Lógica do empréstimo aqui
        Console.WriteLine($"Usuário {codigoUsuario} emprestou o livro {codigoLivro}");
    }
}