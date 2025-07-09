namespace MATA62_Trab_Final;

public class ExemplarLivro
{
    public string CodIdentificacao { get; private set; }
    public Livro Livro { get; private set; }
    public Emprestimo EmprestimoAtual { get; private set; }

    public bool VerificaAptoEmprestimo()
    {
        return EmprestimoAtual.VerificaEmprestimoDevolvido();
    }

    public bool VerificaEmprestimoUsuario(string codigoUsuario)
    {
        return EmprestimoAtual.VerificaUsuarioPorCodigo(codigoUsuario);
    }

    public bool VerificaLivroPorCodigo(string codigoLivro)
    {
        return Livro.VerificaCodigoLivro(codigoLivro);
    }
}