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
        
        var repositorio = Repositorio.ObterInstancia();
        var emprestador = repositorio.BuscarUsuarioEmprestadorPorCodigo(codigoUsuario);
        
        if (emprestador is null)
        {
            GerenciadorMensagens.ImprimeRecursoNaoEncontrado("usuario");
            return;
        }
        
        if (emprestador.IsAluno.Equals(true))
        {
            GerenciadorMensagens.ImprimeErroComando(Comando,"usuário deve ser um professor");
            return;
        }
        
        var livro = repositorio.BuscarLivroPorCodigo(codigoLivro);
        
        if (livro is null)
        {
            GerenciadorMensagens.ImprimeRecursoNaoEncontrado("livro");
            return;
        }

        int qtdReservas = livro.Reservas.Count - 2;
        if (qtdReservas <= 0)
        {
            GerenciadorMensagens.Imprime("Sem notificações no momento");
            return;
        }
        
        GerenciadorMensagens.Imprime($"Quantidade de notificações encontradas: {qtdReservas}");
    }
}