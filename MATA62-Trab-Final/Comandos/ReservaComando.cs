namespace MATA62_Trab_Final.Comandos;

public class ReservaComando : IComando
{
    public string Comando { get; set; }

    public ReservaComando(string comando)
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
        
        if (emprestador.ObtemReservaLivro(codigoLivro) is not null)
        {
            GerenciadorMensagens.ImprimeErroComando(Comando, "usuário já possui reserva para este livro");
            return;
        }

        emprestador.RealizaReserva(livro, DateTime.Now.ToString("yyyy-MM-dd"));
        livro.RealizaReserva(emprestador, DateTime.Now.ToString("yyyy-MM-dd"));
        GerenciadorMensagens.Imprime("Reserva realizada com sucesso!");
    }
}