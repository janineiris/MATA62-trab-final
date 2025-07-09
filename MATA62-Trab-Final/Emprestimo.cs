using System.Globalization;

namespace MATA62_Trab_Final;

public class Emprestimo
{
    public ExemplarLivro Exemplar { get; protected set; }
    public Usuario Usuario { get; protected set; }
    public string DataEmprestimo { get; protected set; }
    public string DataDevolucaoPrevista { get; protected set; }
    public string? DataDevolucao { get; protected set; }

    public bool VerificaEmprestimoDevolvido()
    {
        return DataDevolucao is not null;
    }
    
    public bool VerificaEmprestimoAtrasado()
    {
        return DataDevolucao is null &&
               DateTime.Now > DateTime.Parse(DataDevolucaoPrevista, CultureInfo.InvariantCulture);
    }

    public bool VerificaUsuarioPorCodigo(string codigo)
    {
        return Usuario.VerificaCodigoUsuario(codigo);
    }
    
    public bool VerificaLivroPorCodigo(string codigo)
    {
        return Exemplar.VerificaLivroPorCodigo(codigo);
    }

    public void Devolver()
    {
        DataDevolucao = DateTime.Now.ToString(CultureInfo.InvariantCulture);
    }
}