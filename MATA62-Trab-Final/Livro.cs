namespace MATA62_Trab_Final;

public class Livro
{
    public string CodIdentificacao { get; private set; }
    public string Titulo { get; private set; }
    public string Editora { get; private set; }
    public string Edicao { get; private set; }
    public List<string> Autores { get; private set; }
    public int AnoPublicacao { get; private set; }
    public List<Reserva> Reservas { get; private set; }
    public List<ExemplarLivro> Exemplares { get; private set; }
    
    private List<IObservador> observadores = new();
    
    public int QuantidadeReservas => ObterQuantidadeReservasAtivas();
    public int QuantidadeExemplaresDisponiveis => ObterQuantidadeExemplaresDisponiveis();

    public Livro(string codigo, string titulo, string editora, string edicao, IList<string> autores, int anoPublicacao)
    {
        CodIdentificacao = codigo;
        Titulo = titulo;
        Editora = editora;
        Edicao = edicao;
        Autores = autores.ToList();
        AnoPublicacao = anoPublicacao;
        Reservas = new List<Reserva>();
        Exemplares = new List<ExemplarLivro>();
    }
    
    public void AdicionarObservador(IObservador observador)
    {
        if (!observadores.Contains(observador))
            observadores.Add(observador);
    }

    public void RemoverObservador(IObservador observador)
    {
        if (observadores.Contains(observador))
            observadores.Remove(observador);
    }
    
    public void NotificarSeReservasExcedemLimite()
    {
        if (ObterQuantidadeReservasAtivas() > 2)
        {
            foreach (var observador in observadores)
            {
                observador.Notificar(this);
            }
        }
    }
    
    public bool TemExemplarDisponivel()
    {
        return ObterQuantidadeExemplaresDisponiveis() > 0;
    }
    
    public bool VerificaCodigoLivro(string codigo)
    {
        return CodIdentificacao == codigo;
    }

    public int ObterQuantidadeReservasAtivas()
    {
        return Reservas.Where(r => r.VerificaReservaAtiva()).ToList().Count;
    }

    public int ObterQuantidadeExemplaresDisponiveis()
    {
        return Exemplares.Count(e => e.VerificaAptoEmprestimo());
    }

    public Reserva? ObtemReservaAtivaUsuario(string codigoUsuario)
    {
        return Reservas.FirstOrDefault(r => r.Usuario.VerificaCodigoUsuario(codigoUsuario) && r.VerificaReservaAtiva());
    }
    
    public ExemplarLivro? ObtemExemplarDisponivel()
    {
        return Exemplares.FirstOrDefault(e => e.VerificaAptoEmprestimo());
    }
    
    public ExemplarLivro? ObtemExemplarUsuario(string codigoUsuario)
    {
        return Exemplares.FirstOrDefault(e => e.VerificaEmprestimoUsuario(codigoUsuario));
    }
    
    public ExemplarLivro? ObtemExemplarPorCodigo(string codigoUsuario)
    {
        return Exemplares.FirstOrDefault(e => e.VerificaCodigoExemplar(codigoUsuario));
    }

    public bool VerificaReservaExcedemExemplares()
    {
        return ObterQuantidadeExemplaresDisponiveis() > ObterQuantidadeReservasAtivas();
    }

    public ExemplarLivro AdicionarExemplar(string codigoExemplar)
    {
        var exemplar = new ExemplarLivro(codigoExemplar, this);
        Exemplares.Add(exemplar);
        return exemplar;
    }
    
    public void RealizaReserva(Usuario usuario, string dataReserva)
    {
        Reserva reserva = new Reserva(this, dataReserva, usuario);
        Reservas.Add(reserva);
        
        if (usuario is IEmprestador emprestador)
        {
            emprestador.Reservas.Add(reserva);
        }
        
        NotificarSeReservasExcedemLimite();
    }

    public void ImprimeInformacoesExemplar()
    {
        int qtdReservas = ObterQuantidadeReservasAtivas();
        GerenciadorMensagens.Imprime($"Titulo: {Titulo}");
        GerenciadorMensagens.Imprime($"Quantidade  de reservas realizadas: {qtdReservas}");
        if (qtdReservas > 0)
        {
            foreach (var r in Reservas)
            {
                GerenciadorMensagens.Imprime($"Nome do usuário: {r.GetNomeUsuario()}");
                GerenciadorMensagens.Imprime("");
            }
        }
        GerenciadorMensagens.Imprime("Exemplares:");
        foreach (var e in Exemplares)
        {
            GerenciadorMensagens.Imprime($"Código: {e.CodIdentificacao}");
            GerenciadorMensagens.Imprime($"Status: {(e.VerificaAptoEmprestimo() ? "disponível" : "emprestado")}");
            GerenciadorMensagens.Imprime("");
        }
    }
}