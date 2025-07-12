namespace MATA62_Trab_Final.Comandos;

public class InformacoesUsuarioComando : IComando
{
    public void Executar(string[] args)
    {
        if (args.Length < 1)
        {
            Console.WriteLine("Uso: usu <codigoUsuario>");
            return;
        }

        string codigoUsuario = args[0];
        
        Console.WriteLine($"Informações do usuário {codigoUsuario}");
        
        if (string.IsNullOrWhiteSpace(codigoUsuario))
        {
            Console.WriteLine("Código de usuário não informado");
            return;
        }
        
        var repositorio = Repositorio.ObterInstancia();
        var emprestador = repositorio.BuscarUsuarioEmprestadorPorCodigo(codigoUsuario);

        if (emprestador is null)
        {
            GerenciadorMensagens.ImprimeRecursoNaoEncontrado("usuario");
            return;
        }

        emprestador.ImprimeInformacoesEmprestimos();
        emprestador.ImprimeInformacoesReserva();
    }
}