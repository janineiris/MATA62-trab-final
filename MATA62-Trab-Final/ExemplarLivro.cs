namespace MATA62_Trab_Final;

public class ExemplarLivro
{
    public string CodIdentificacao { get; private set; }
    public Livro Livro { get; private set; }
    public Emprestimo? EmprestimoAtual { get; private set; }

    public ExemplarLivro(string codigo, Livro livro)
    {
        CodIdentificacao = codigo;
        Livro = livro;
        EmprestimoAtual = null;
    }

    public bool VerificaCodigoExemplar(string codigoExemplar)
    {
        return CodIdentificacao == codigoExemplar;
    }

    public bool VerificaAptoEmprestimo()
    {
        return EmprestimoAtual?.VerificaEmprestimoDevolvido() ?? true;
    }

    public bool VerificaEmprestimoUsuario(string codigoUsuario)
    {
        return EmprestimoAtual?.VerificaUsuarioPorCodigo(codigoUsuario) ?? false;
    }

    public bool VerificaLivroPorCodigo(string codigoLivro)
    {
        return Livro.VerificaCodigoLivro(codigoLivro);
    }
    
    public string GetTituloLivro()
    {
        return Livro.Titulo;
    }
}