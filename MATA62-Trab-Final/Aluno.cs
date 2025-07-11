namespace MATA62_Trab_Final;

public abstract class Aluno: UsuarioEmprestador, IEmprestador
{
    public bool IsAluno { get; protected set; } = true;
    public int TempoEmprestimo { get; protected set; }
    public int LimiteEmprestimos { get; protected set; }
    public List<Emprestimo> Emprestimos { get; protected set; } = new();
    public List<Reserva> Reservas { get; protected set; } = new();
    
    public override bool VerificaViabilidadeEmprestimo(Livro livro)
    {
        var existeExemplarDisponivel = livro.ObterQuantidadeExemplaresDisponiveis() > 0;
        var existeEmprestimoAtrasado = ObtemEmprestimosAtrasados().Count > 0;
        
        var quantidadeEmprestimosAtivos = ObtemEmprestimosAtivos().Count;
        var alunoExcedeQntdMaximaEmprestimo = quantidadeEmprestimosAtivos >= LimiteEmprestimos;

        var existeExemplarNaoReservado = livro.VerificaReservaExcedemExemplares();
        var existeEmprestimoAlunoLivro = VerificaEmprestimoLivro(livro.CodIdentificacao);

        var reserva = ObtemReservaLivro(livro.CodIdentificacao);

        return existeExemplarDisponivel && !existeEmprestimoAtrasado && !alunoExcedeQntdMaximaEmprestimo &&
               (existeExemplarNaoReservado || reserva is not null) && !existeEmprestimoAlunoLivro;
    }
}