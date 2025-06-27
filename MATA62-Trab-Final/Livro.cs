namespace MATA62_Trab_Final;

public class Livro
{
    public string CodIdentificacao { get; set; }
    public string Titulo { get; set; }
    public string Editora { get; set; }
    public string Edicao { get; set; }
    public List<string> Autores { get; set; }
    public int AnoPublicacao { get; set; }
    public List<Reserva> Reservas { get; set; }
    public List<ExemplarLivro> Exemplares { get; set; }
}