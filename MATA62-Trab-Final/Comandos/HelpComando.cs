namespace MATA62_Trab_Final.Comandos;

public class HelpComando: IComando
{
    public string Comando { get; set; }

    public HelpComando(string comando)
    {
        Comando = comando;
    }

    public void Executar(string[] parametros)
    {
        var interfaceUsuario = InterfaceComandosUsuario.ObterInstancia();
        var comandos = interfaceUsuario.ListarComandos();
        
        GerenciadorMensagens.Imprime($"Comandos: {string.Join(", ", comandos)}");
    }
}