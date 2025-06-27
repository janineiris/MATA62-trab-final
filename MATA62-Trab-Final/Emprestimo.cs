namespace MATA62_Trab_Final;

public class Emprestimo
{
    public ExemplarLivro Exemplar { get; set; }
    public Usuario Usuario { get; set; }
    public string DataEmprestimo { get; set; }
    public string DataDevolucao { get; set; }
}