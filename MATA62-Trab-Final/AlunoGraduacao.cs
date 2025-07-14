namespace MATA62_Trab_Final;

public class AlunoGraduacao: Aluno
{
    public AlunoGraduacao(string codigo, string nome)
    {
        TempoEmprestimo = 4;
        LimiteEmprestimos = 2;
        CodIdentificacao = codigo;
        Nome = nome;
        _regraEmprestimo = new RegraEmprestimoAluno(2);
    }
}