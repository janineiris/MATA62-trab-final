namespace MATA62_Trab_Final;

public class Professor: UsuarioEmprestador, IEmprestador
{
    public bool IsAluno { get; private set; } = false;
    public int TempoEmprestimo { get; private set; } = 8;
    public int LimiteEmprestimos { get; private set; } = -1;
    public List<Emprestimo> Emprestimos { get; private set; } = new();
    public List<Reserva> Reservas { get; private set; } = new();
    
    public Professor(string codigo, string nome)
    {
        CodIdentificacao = codigo;
        Nome = nome;
    }
    
    public override bool VerificaViabilidadeEmprestimo(Livro livro)
    {
        var existeExemplarDisponivel = livro.ObterQuantidadeExemplaresDisponiveis() > 0;
        var existeEmprestimoAtrasado = ObtemEmprestimosAtrasados().Count > 0;

        return existeExemplarDisponivel && !existeEmprestimoAtrasado;
    }
}