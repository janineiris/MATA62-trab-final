namespace MATA62_Trab_Final;

public class Professor: UsuarioEmprestador, IEmprestador, IObservador
{
    public override bool IsAluno => false;
    public string CodigoUsuario => CodIdentificacao;
    
    public int ContadorNotificacoes { get; private set; } = 0;
    
    public Professor(string codigo, string nome)
    {
        TempoEmprestimo = 8;
        LimiteEmprestimos = -1;
        CodIdentificacao = codigo;
        Nome = nome;
        _regraEmprestimo = new RegraEmprestimoProfessor();
    }
    
    public override bool VerificaViabilidadeEmprestimo(Livro livro)
    {
        var existeExemplarDisponivel = livro.ObterQuantidadeExemplaresDisponiveis() > 0;
        var existeEmprestimoAtrasado = ObtemEmprestimosAtrasados().Count > 0;

        return existeExemplarDisponivel && !existeEmprestimoAtrasado;
    }
    
    public void Notificar(Livro livro)
    {
        ContadorNotificacoes++;
        GerenciadorMensagens.Imprime($"Professor {Nome} notificado: livro '{livro.Titulo}' tem mais de 2 reservas.");
    }
}