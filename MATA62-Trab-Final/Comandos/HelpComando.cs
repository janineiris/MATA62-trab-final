namespace MATA62_Trab_Final.Comandos;

public class HelpComando
{
    private readonly ComandoFactory _fabrica;
    
    public HelpComando()
    {
        _fabrica = new ComandoFactory();
    }

    public void ExecutarLinha(string linha)
    {
        string[] partesDoComando = linha.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        if (partesDoComando.Length == 0) return;

        string nome = partesDoComando[0];
        string[] args = partesDoComando.Skip(1).ToArray();

        IComando comando = _fabrica.Obter(nome);
        comando.Executar(args);
    }
}