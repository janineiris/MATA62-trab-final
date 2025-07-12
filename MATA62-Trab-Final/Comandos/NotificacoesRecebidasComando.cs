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
            GerenciadorMensagens.ImprimeErroComando(Comando,"necessário passar o parâmetro <codigoUsuario>");
            return;
        }

        string codigoUsuario = args[0];
        
        Console.WriteLine($"Notificações recebidas do usuário {codigoUsuario}");
    }
}