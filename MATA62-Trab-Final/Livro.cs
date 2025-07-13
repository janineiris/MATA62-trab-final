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
        return Reservas.Where(r => r.VerificaReservaAtiva()).ToList().Count;
    }

    public Reserva? ObtemReservaAtivaUsuario(string codigoUsuario)
    {
        return Reservas.FirstOrDefault(r => r.Usuario.VerificaCodigoUsuario(codigoUsuario) && r.VerificaReservaAtiva());
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

    public void ImprimeInformacoesExemplar()
    {
        int qtdReservas = ObterQuantidadeReservasAtivas();
        GerenciadorMensagens.Imprime($"Titulo: {Titulo}");
        GerenciadorMensagens.Imprime($"Quantidade  de reservas realizadas: {qtdReservas}");
        if (qtdReservas > 0)
        {
            foreach (var r in Reservas)
            {
                GerenciadorMensagens.Imprime($"➞nome: {r.GetNomeUsuario()}");
            }
        }
        GerenciadorMensagens.Imprime("Exemplares:");
        foreach (var e in Exemplares)
        {
            GerenciadorMensagens.Imprime($"➞código: {e.CodIdentificacao}");
            GerenciadorMensagens.Imprime($"➞status: {(e.VerificaAptoEmprestimo() ? "disponível" : "emprestado")}");
            GerenciadorMensagens.Imprime("");
        }
    }
}