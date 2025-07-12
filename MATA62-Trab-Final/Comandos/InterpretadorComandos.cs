namespace MATA62_Trab_Final.Comandos;

public class InterpretadorComandos
{
    private readonly ComandoFactory _fabrica;
    private static InterpretadorComandos? _instancia;
    
    public InterpretadorComandos()
    {
        _fabrica = new ComandoFactory();
    }
    
    public static InterpretadorComandos ObterInstancia()
    {
        if (_instancia is null)
        {
            _instancia = new InterpretadorComandos();
        }
        return _instancia;
    }
    
    public string[] ListarComandos()
    {
        return _fabrica.GetComandos();
    }
    
    public void ExecutarLinha(string linha)
    {
        string[] partesDoComando = linha.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        if (partesDoComando.Length == 0) return;

        string nomeComando = partesDoComando[0];
        string[] args = partesDoComando.Skip(1).ToArray();

        IComando comando = _fabrica.Obter(nomeComando);
        comando.Executar(args);
    }
}