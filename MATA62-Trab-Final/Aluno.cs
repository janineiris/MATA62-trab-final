namespace MATA62_Trab_Final;

public abstract class Aluno: UsuarioEmprestador
{
    public int LimiteEmprestimos { get; set; }
    
    public override bool VerificaViabilidadeEmprestimo(Livro livro, out string? motivoRejeicao)
    {
        var existeExemplarDisponivel = livro.TemExemplarDisponivel();
        var existeEmprestimoAtrasado = VerificaUsuarioDevedor();
        
        var quantidadeEmprestimosAtivos = ObtemEmprestimosAtivos().Count;
        var alunoExcedeQntdMaximaEmprestimo = quantidadeEmprestimosAtivos >= LimiteEmprestimos;

        var existeExemplarNaoReservado = livro.VerificaReservaExcedemExemplares();
        var existeEmprestimoAlunoLivro = VerificaEmprestimoLivro(livro.CodIdentificacao);

        var reserva = ObtemReservaLivro(livro.CodIdentificacao);

        motivoRejeicao = !existeExemplarDisponivel
            ? "não há exemplares disponíveis"
            :
            existeEmprestimoAtrasado
                ? "o usuário está com livro em atraso"
                :
                alunoExcedeQntdMaximaEmprestimo
                    ? "o aluno já atingiu o limite de empréstimos"
                    :
                    !existeExemplarNaoReservado & reserva is null
                        ?
                        "todos os exemplares disponíveis estão reservados e o usuário não tem reserva"
                        : existeEmprestimoAlunoLivro
                            ? "o usuário já possui empréstimo deste livro"
                            : null;

        return existeExemplarDisponivel && !existeEmprestimoAtrasado && !alunoExcedeQntdMaximaEmprestimo &&
               (existeExemplarNaoReservado || reserva is not null) && !existeEmprestimoAlunoLivro;
    }
}