namespace MATA62_Trab_Final.Comandos;

public class HelpComando : IComando
{
    public string Comando { get; set; }
    private readonly Func<string[]> _listarComandos;
    
    public HelpComando(string comando, Func<string[]> listarComandos)
    {
        Comando = comando;
        _listarComandos = listarComandos;
    }
    
    public void Executar(string[] args)
    {
        var comandos = _listarComandos();
        GerenciadorMensagens.Imprime($"Comandos: {string.Join(", ", comandos)}");
    }
}