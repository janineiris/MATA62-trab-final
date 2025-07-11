namespace MATA62_Trab_Final;

public interface IEmprestador
{
    int TempoEmprestimo { get; set; }
    int LimiteEmprestimos { get; set; }
    List<Emprestimo> Emprestimos { get; set; }
    List<Reserva> Reservas { get; set; }
    bool IsAluno { get; set; }

    bool VerificaViabilidadeEmprestimo(Livro livro);
    bool VerificaUsuarioDevedor();
}