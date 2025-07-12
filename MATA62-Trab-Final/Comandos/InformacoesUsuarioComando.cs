namespace MATA62_Trab_Final.Comandos;

public class InformacoesUsuarioComando : IComando
{
    public void Executar(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Uso: dev <idUsuario> <idLivro>");
            return;
        }

        string idUsuario = args[0];
        string idLivro = args[1];

        // Lógica de informações aqui
        Console.WriteLine($"Informações do usuário {idUsuario}");

        var codigoUsuario = idUsuario;
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