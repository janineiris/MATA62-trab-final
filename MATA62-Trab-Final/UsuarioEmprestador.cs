namespace MATA62_Trab_Final;

public abstract class UsuarioEmprestador: Usuario, IEmprestador
{
    public int TempoEmprestimo { get; set; }
    public int LimiteEmprestimos { get; set; }
    public List<Emprestimo> Emprestimos { get; set; } = new ();
    public List<Reserva> Reservas { get; set; } = new ();
    public bool IsAluno { get; set; }

    protected List<Emprestimo> ObtemEmprestimosAtrasados()
    {
        return Emprestimos.Where(e => e.VerificaEmprestimoAtrasado()).ToList();
    }
    
    protected List<Emprestimo> ObtemEmprestimosAtivos()
    {
        return Emprestimos.Where(e => !e.VerificaEmprestimoDevolvido()).ToList();
    }
    
    protected Reserva? ObtemReservaLivro(string codigoLivro)
    {
        return Reservas.FirstOrDefault(r => r.VerificaLivroPorCodigo(codigoLivro));
    }
    
    protected bool VerificaEmprestimoLivro(string codigoLivro)
    {
        return Emprestimos.Any(e => e.VerificaLivroPorCodigo(codigoLivro) && !e.VerificaEmprestimoDevolvido());
    }
    
    public abstract bool VerificaViabilidadeEmprestimo(Livro livro);

    public bool VerificaUsuarioDevedor()
    {
        return Emprestimos.Any(e => e.VerificaEmprestimoAtrasado());
    }

    public void ImprimeInformacoesEmprestimos()
    {
        GerenciadorMensagens.Imprime("Empréstimos:");
        foreach (var emprestimo in Emprestimos)
        {
           GerenciadorMensagens.ImprimeEmprestimo(emprestimo); 
        }
    }
    
    public void ImprimeInformacoesReserva()
    {
        GerenciadorMensagens.Imprime("Reservas:");
        foreach (var reserva in Reservas)
        {
            GerenciadorMensagens.ImprimeReserva(reserva); 
        }
    }
}