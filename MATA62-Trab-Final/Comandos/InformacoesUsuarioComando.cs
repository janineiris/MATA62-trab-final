namespace MATA62_Trab_Final.Comandos;

public class InformacoesUsuarioComando: IComando
{
    public string Comando { get; set; }

    public InformacoesUsuarioComando(string comando)
    {
        Comando = comando;
    }
    
    public void Executar(string[] parametros)
    {
        var codigoUsuario = parametros.FirstOrDefault();
        if (string.IsNullOrWhiteSpace(codigoUsuario))
        {
            GerenciadorMensagens.ImprimeErroComando(Comando, "código de usuário não informado");
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