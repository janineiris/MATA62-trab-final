namespace MATA62_Trab_Final.Comandos;

public class ComandoFactory
{
    private readonly Dictionary<string, IComando> _comandos;

    public ComandoFactory()
    {
        _comandos = new Dictionary<string, IComando>
        {
            { "emp", new EmprestimoComando() },
            { "dev", new DevolucaoComando() },
            { "res", new ReservaComando() },
            { "obs", new ObservacaoComando() },
            { "usu", new InformacoesUsuarioComando() },
            { "liv", new InformacoesLivroComando() },
            { "ntf", new NotificacoesRecebidasComando() }
        };
    }

    public IComando Obter(string nomeComando)
    {
        return _comandos.GetValueOrDefault(nomeComando, new ComandoDesconhecido(nomeComando));
    }
}