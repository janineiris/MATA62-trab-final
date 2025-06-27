namespace MATA62_Trab_Final;

public class Aluno: Usuario, IEmprestador
{
    public bool IsAluno { get; set; } = true;
    public int TempoEmprestimo { get; set; }
    public int LimiteEmprestimos { get; set; }
    public List<Emprestimo> Emprestimos { get; set; } = new();
    public List<Reserva> Reservas { get; set; } = new();
}