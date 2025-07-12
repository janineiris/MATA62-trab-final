namespace MATA62_Trab_Final.Comandos;

public class HelpComando : IComando
{
    public string Comando { get; set; }

    public HelpComando(string comando)
    {
        Comando = comando;
    }

    public void Executar(string[] args)
    {
        var interpretador = InterpretadorComandos.ObterInstancia();
        var comandos = interpretador.ListarComandos();

        GerenciadorMensagens.Imprime($"Comandos: {string.Join(", ", comandos)}");
    }
}