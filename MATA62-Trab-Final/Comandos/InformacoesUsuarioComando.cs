namespace MATA62_Trab_Final.Comandos;

public class InformacoesUsuarioComando : IComando
{
    public string Comando { get; set; }

    public InformacoesUsuarioComando(string comando)
    {
        Comando = comando;
    }
    
    public void Executar(string[] args)
    {
        if (args.Length < 1)
        {
            GerenciadorMensagens.ImprimeErroComando(Comando,"necessário passar o parâmetro <codigoUsuario>");
            return;
        }

        string codigoUsuario = args[0];
        
        if (string.IsNullOrWhiteSpace(codigoUsuario))
        {
            GerenciadorMensagens.ImprimeErroComando(Comando, "código de usuário não informado");
            return;
        }
        
        var repositorio = Repositorio.ObterInstancia();
        var emprestador = repositorio.BuscarUsuarioEmprestadorPorCodigo(codigoUsuario);

        if (emprestador is null)
        {
            GerenciadorMensagens.ImprimeRecursoNaoEncontrado("usuario");
            return;
        }

        emprestador.ImprimeInformacoesEmprestimos();
        emprestador.ImprimeInformacoesReserva();
    }
}