namespace MATA62_Trab_Final.Comandos;

public class DevolucaoComando : IComando
{
    public string Comando { get; set; }

    public DevolucaoComando(string comando)
    {
        Comando = comando;
    }

    public void Executar(string[] args)
    {
        if (args.Length < 2)
        {
            GerenciadorMensagens.ImprimeErroComando(Comando, "necessário passar os parâmetros <codigoUsuario> <codigoLivro>");
            return;
        }

        string codigoUsuario = args[0];
        string codigoLivro = args[1];

        var repositorio = Repositorio.ObterInstancia();
        var usuario = repositorio.BuscarUsuarioEmprestadorPorCodigo(codigoUsuario);

        if (usuario is null)
        {
            GerenciadorMensagens.ImprimeRecursoNaoEncontrado("usuario");
            return;
        }

        var emprestimo = usuario.ObtemEmprestimoLivro(codigoLivro);

        if (emprestimo is null)
        {
            GerenciadorMensagens.ImprimeErroComando(Comando, "nenhum empréstimo ativo encontrado para este livro");
            return;
        }

        emprestimo.Devolver();
        GerenciadorMensagens.Imprime("Devolução realizada com sucesso!");
    }
}