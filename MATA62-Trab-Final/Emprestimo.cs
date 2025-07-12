using System.Globalization;

namespace MATA62_Trab_Final;

public class Emprestimo
{
    public ExemplarLivro Exemplar { get; private set; }
    public Usuario Usuario { get; private set; }
    public string DataEmprestimo { get; private set; }
    public string DataDevolucaoPrevista { get; private set; }
    public string? DataDevolucao { get; private set; }

    public string GetNomeStatus()
    {
        return VerificaEmprestimoDevolvido() ? "Finalizado" : VerificaEmprestimoAtrasado() ? "Atrasado" : "Em curso";
    }

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
    
    public string GetTituloLivro()
    {
        return Exemplar.GetTituloLivro();
    }

    public void Devolver()
    {
        DataDevolucao = DateTime.Now.ToString(CultureInfo.InvariantCulture);
    }
}