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
        
        if (string.IsNullOrWhiteSpace(codigoLivro))
        {
            GerenciadorMensagens.ImprimeErroComando(Comando, "código do livro não informado");
            return;
        }
        
        var repositorio = Repositorio.ObterInstancia();
        var livro = repositorio.BuscarLivroPorCodigo(codigoLivro);

        if (livro is null)
        {
            GerenciadorMensagens.ImprimeRecursoNaoEncontrado("livro");
            return;
        }

        livro.ImprimeInformacoesExemplar();
    }
}