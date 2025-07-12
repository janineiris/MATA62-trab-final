namespace MATA62_Trab_Final.Comandos;

public class ObservacaoComando : IComando
{
    public string Comando { get; set; }

    public ObservacaoComando(string comando)
    {
        Comando = comando;
    }
    
    public void Executar(string[] args)
    {
        if (args.Length < 2)
        {
            GerenciadorMensagens.ImprimeErroComando(Comando,"necessário passar os parâmetros <codigoUsuario> <codigoLivro>");
            return;
        }

        string codigoUsuario = args[0];
        string codigoLivro = args[1];

        // Lógica da observação aqui
        Console.WriteLine($"Usuário {codigoUsuario} observa o livro {codigoLivro}");
    }
}