namespace MATA62_Trab_Final;

public static class GerenciadorMensagens
{
    public static void ImprimeMensagemComandoNaoEncontrado(string comando)
    {
        Console.WriteLine($"Comando '{comando}' não encontrado");
    }
}