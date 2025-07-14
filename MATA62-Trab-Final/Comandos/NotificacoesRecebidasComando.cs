namespace MATA62_Trab_Final.Comandos;

public class NotificacoesRecebidasComando : IComando
{
    public string Comando { get; set; }

    public NotificacoesRecebidasComando(string comando)
    {
        Comando = comando;
    }
    
    public void Executar(string[] args)
    {
        if (args.Length < 1)
        {
            GerenciadorMensagens.ImprimeErroComando(Comando, "necessário passar o parâmetro <codigoUsuario>");
            return;
        }
        
        string codigoUsuario = args[0];
        var repositorio = Repositorio.ObterInstancia();
        
        var usuario = repositorio.BuscarUsuarioEmprestadorPorCodigo(codigoUsuario);
        
        if (usuario is null)
        {
            GerenciadorMensagens.ImprimeRecursoNaoEncontrado("usuario");
            return;
        }
        
        if (usuario is IObservador observador)
        {
            GerenciadorMensagens.Imprime($"Total de notificações recebidas: {observador.ContadorNotificacoes}");
        }
        else
        {
            GerenciadorMensagens.Imprime("Usuário não está registrado como observador.");
        }
    }
}