namespace MATA62_Trab_Final;

public abstract class UsuarioEmprestador: Usuario, IEmprestador
{
    public int TempoEmprestimo { get; set; }
    public int LimiteEmprestimos { get; set; }
    public List<Emprestimo> Emprestimos { get; set; } = new ();
    public List<Reserva> Reservas { get; set; } = new ();
    public virtual bool IsAluno => false;

    protected List<Emprestimo> ObtemEmprestimosAtrasados()
    {
        return Emprestimos.Where(e => e.VerificaEmprestimoAtrasado()).ToList();
    }
    
    public List<Emprestimo> ObtemEmprestimosAtivos()
    {
        return Emprestimos.Where(e => !e.VerificaEmprestimoDevolvido()).ToList();
    }

    public Emprestimo? ObtemEmprestimoLivro(string codigoLivro)
    {
        return Emprestimos.FirstOrDefault(e => e.VerificaLivroPorCodigo(codigoLivro) && !e.VerificaEmprestimoDevolvido());
    }
    
    public Reserva? ObtemReservaLivro(string codigoLivro)
    {
        return Reservas.FirstOrDefault(r => r.VerificaLivroPorCodigo(codigoLivro));
    }
    
    protected bool VerificaEmprestimoLivro(string codigoLivro)
    {
        return Emprestimos.Any(e => e.VerificaLivroPorCodigo(codigoLivro) && !e.VerificaEmprestimoDevolvido());
    }
    
    public abstract bool VerificaViabilidadeEmprestimo(Livro livro, out string? motivoRejeicao);

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
    
    public bool RealizarEmprestimo(Livro livro, DateTime dataEmprestimo, out string erro)
    {
        erro = "";

        var exemplar = livro.ObtemExemplarDisponivel();
        if (exemplar is null)
        {
            erro = "Não há exemplares disponíveis.";
            return false;
        }

        var emprestimo = new Emprestimo(dataEmprestimo, exemplar, this, TempoEmprestimo);
        Emprestimos.Add(emprestimo);
        exemplar.RegistrarEmprestimo(emprestimo);
        
        var reserva = ObtemReservaLivro(livro.CodIdentificacao);
        if (reserva is not null) reserva.Cancelar();

        return true;
    }

    public void RegistrarReserva(Reserva reserva)
    {
        Reservas.Add(reserva);
    }
}