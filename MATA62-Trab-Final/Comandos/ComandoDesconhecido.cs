namespace MATA62_Trab_Final.Comandos;

public class ComandoDesconhecido : IComando
{
    public string Comando { get; set; }

    public ComandoDesconhecido(string comando)
    {
        Comando = comando;
    }

    public void Executar(string[] args)
    {
        GerenciadorMensagens.ImprimeErroComando(Comando, "comando desconhecido");
    }
}