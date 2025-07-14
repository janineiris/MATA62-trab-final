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
            GerenciadorMensagens.ImprimeErroComando(Comando, "Parâmetros necessários: <codigoUsuario> <codigoLivro>");
            return;
        }
        
        var codigoUsuario = args[0];
        var codigoLivro = args[1];
        var repositorio = Repositorio.ObterInstancia();
        
        var professor = repositorio.BuscarUsuarioEmprestadorPorCodigo(codigoUsuario) as Professor;
        if (professor == null)
        {
            GerenciadorMensagens.Imprime("Usuário não encontrado ou não é professor.");
            return;
        }
        
        var livro = repositorio.BuscarLivroPorCodigo(codigoLivro);
        if (livro == null)
        {
            GerenciadorMensagens.Imprime("Livro não encontrado.");
            return;
        }
        
        livro.AdicionarObservador(professor);
        GerenciadorMensagens.Imprime($"Professor {professor.Nome} agora observa o livro '{livro.Titulo}'.");
    }
}