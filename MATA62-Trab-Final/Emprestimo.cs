using System.Globalization;

namespace MATA62_Trab_Final;

public class Emprestimo
{
    public ExemplarLivro Exemplar { get; private set; }
    public UsuarioEmprestador Usuario { get; private set; }
    public string DataEmprestimo { get; private set; }
    public string DataDevolucaoPrevista { get; private set; }
    public string? DataDevolucao { get; private set; }

    public Emprestimo(DateTime dataEmprestimo, ExemplarLivro exemplar, UsuarioEmprestador usuario, int diasDeEmprestimo)
    {
        Exemplar = exemplar;
        Usuario = usuario;
        DataEmprestimo = dataEmprestimo.ToString("dd/MM/yyyy", new CultureInfo("pt-BR"));
        DataDevolucaoPrevista = dataEmprestimo.AddDays(diasDeEmprestimo).ToString("dd/MM/yyyy", new CultureInfo("pt-BR"));
    }
    
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
               DateTime.Now > DateTime.Parse(DataDevolucaoPrevista, new CultureInfo("pt-BR"));
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
        DataDevolucao = DateTime.Today.ToString("dd/MM/yyyy", new CultureInfo("pt-BR"));
    }
}