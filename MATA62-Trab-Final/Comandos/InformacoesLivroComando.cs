namespace MATA62_Trab_Final.Comandos;

public class InformacoesLivroComando : IComando
{
    public string Comando { get; set; }

    public InformacoesLivroComando(string comando)
    {
        Comando = comando;
    }
    
    public void Executar(string[] args)
    {
        if (args.Length < 1)
        {
            GerenciadorMensagens.ImprimeErroComando(Comando,"necessário passar o parâmetro <codigoLivro>");
            return;
        }

        string codigoLivro = args[0];
        
        Console.WriteLine($"Informações do livro {codigoLivro}");
    }
}