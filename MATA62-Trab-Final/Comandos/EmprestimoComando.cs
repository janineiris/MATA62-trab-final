using System.Globalization;

namespace MATA62_Trab_Final.Comandos;

public class EmprestimoComando : IComando
{
    public string Comando { get; set; }

    public EmprestimoComando(string comando)
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
        
        var livro = repositorio.BuscarLivroPorCodigo(codigoLivro);
        
        if (livro is null)
        {
            GerenciadorMensagens.ImprimeRecursoNaoEncontrado("livro");
            return;
        }
        
        var regra = emprestador.ObterRegraEmprestimo();

        if (!regra.PodeEmprestar(emprestador, livro, out var erro))
        {
            GerenciadorMensagens.ImprimeErroComando(Comando, erro);
            return;
        }

        if (!emprestador.RealizarEmprestimo(livro, DateTime.Today, out var erroEmprestimo))
        {
            GerenciadorMensagens.ImprimeErroComando(Comando, erroEmprestimo);
            return;
        }

        GerenciadorMensagens.Imprime("Empréstimo realizado com sucesso!");


    }
}