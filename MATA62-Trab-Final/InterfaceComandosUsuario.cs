using MATA62_Trab_Final.Comandos;

namespace MATA62_Trab_Final;

public class InterfaceComandosUsuario
{
    private Dictionary<string, IComando> comandos = new();
    
    private static InterfaceComandosUsuario? _instancia;

    private void InicializarComandos()
    {
        comandos.Add("help", new HelpComando("help"));
        comandos.Add("usu", new InformacoesUsuarioComando("usu"));
    }
    
    public static InterfaceComandosUsuario ObterInstancia()
    {
        if (_instancia is null)
        {
            _instancia = new InterfaceComandosUsuario();
            _instancia.InicializarComandos();
        }
        return _instancia;
    }

    public string[] ListarComandos()
    {
        return comandos.Keys.ToArray();
    }

    public void ExecutarComando(string comandoStr, string[] parametros)
    {
        if (!comandos.ContainsKey(comandoStr))
        {
            GerenciadorMensagens.ImprimeRecursoNaoEncontrado($"comando [{comandoStr}]");
            return;
        }

        var comando = comandos.GetValueOrDefault(comandoStr)!;
        comando.Executar(parametros);
    }
}