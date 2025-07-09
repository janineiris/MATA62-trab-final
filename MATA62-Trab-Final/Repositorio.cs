namespace MATA62_Trab_Final;

public class Repositorio
{
    private List<Usuario> Usuarios { get; set; }
    private List<Livro> Livros { get; set; }
    
    private static Repositorio? _instancia;
    
    public static Repositorio ObterInstancia() {
        if (_instancia is null) _instancia = new Repositorio();
        return _instancia;
    }

    public Usuario? BuscarUsuarioPorCodigo(string codigo)
    {
        return Usuarios.FirstOrDefault(u => u.VerificaCodigoUsuario(codigo));
    }
    
    public Livro? BuscarLivroPorCodigo(string codigo)
    {
        return Livros.FirstOrDefault(u => u.VerificaCodigoLivro(codigo));
    }

    public void AdicionarLivros(string codigo, string titulo, string editora, string edicao, IList<string> autores,
        int anoPublicacao)
    {
        var livro = new Livro(codigo, titulo, editora, edicao, autores, anoPublicacao);
        Livros.Add(livro);
    }
    
    public void AdicionarUsuario(Usuario usuario)
    {
        Usuarios.Add(usuario);
    }
}