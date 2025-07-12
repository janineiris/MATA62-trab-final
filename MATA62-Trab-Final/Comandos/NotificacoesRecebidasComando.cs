namespace MATA62_Trab_Final.Comandos;

public class NotificacoesRecebidasComando : IComando
{
    public void Executar(string[] args)
    {
        if (args.Length < 1)
        {
            GerenciadorMensagens.ImprimeErroComando("ntf","Necessário passar o parâmetro <codigoUsuario>");
            return;
        }

        string codigoUsuario = args[0];
        
        Console.WriteLine($"Notificações recebidas do usuário {codigoUsuario}");
    }
}