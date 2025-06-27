namespace MATA62_Trab_Final;

public class Professor: Usuario, IEmprestador
{
    public bool IsAluno { get; set; } = false;
    public int TempoEmprestimo { get; set; } = 8;
    public int LimiteEmprestimos { get; set; } = -1;
    public List<Emprestimo> Emprestimos { get; set; } = new();
    public List<Reserva> Reservas { get; set; } = new();
}