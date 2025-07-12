namespace MATA62_Trab_Final.Comandos;

public class ComandoFactory
{
    private readonly Dictionary<string, IComando> _comandos;

    public ComandoFactory()
    {
        _comandos = new Dictionary<string, IComando>
        {
            { "help", new HelpComando("help", () => _comandos.Keys.ToArray()) },
            { "emp", new EmprestimoComando("emp") },
            { "dev", new DevolucaoComando("dev") },
            { "res", new ReservaComando("res") },
            { "obs", new ObservacaoComando("obs") },
            { "usu", new InformacoesUsuarioComando("usu") },
            { "liv", new InformacoesLivroComando("liv") },
            { "ntf", new NotificacoesRecebidasComando("ntf") }
        };
    }
    
    public IComando Obter(string nomeComando)
    {
        return _comandos.GetValueOrDefault(nomeComando, new ComandoDesconhecido(nomeComando));
    }
}