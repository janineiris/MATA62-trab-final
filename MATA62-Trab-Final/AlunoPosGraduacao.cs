namespace MATA62_Trab_Final;

public class AlunoPosGraduacao: Aluno
{
    public AlunoPosGraduacao(string codigo, string nome)
    {
        TempoEmprestimo = 5;
        LimiteEmprestimos = 3;
        CodIdentificacao = codigo;
        Nome = nome;
    }
}