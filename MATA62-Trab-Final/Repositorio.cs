namespace MATA62_Trab_Final;

public class Repositorio
{
    private List<Usuario> Usuarios { get; set; }
    private List<Livro> Livros { get; set; }

    private static Repositorio? _instancia;

    public static Repositorio ObterInstancia()
    {
        if (_instancia is null)
        {
            _instancia = new Repositorio();
            _instancia.Usuarios = new List<Usuario>();
            _instancia.Livros = new List<Livro>();
        }
        return _instancia;
    }

    public Usuario? BuscarUsuarioPorCodigo(string codigo)
    {
        return Usuarios.FirstOrDefault(u => u.VerificaCodigoUsuario(codigo));
    }
    
    public UsuarioEmprestador? BuscarUsuarioEmprestadorPorCodigo(string codigo)
    {
        return (UsuarioEmprestador?) BuscarUsuarioPorCodigo(codigo);
    }

    public Livro? BuscarLivroPorCodigo(string codigo)
    {
        return Livros.FirstOrDefault(u => u.VerificaCodigoLivro(codigo));
    }

    private bool AdicionarLivros(string codigo, string titulo, string editora, IList<string> autores, string edicao,
        int anoPublicacao)
    {
        var existeLivroCodigo = Livros.Any(l => l.VerificaCodigoLivro(codigo));
        if (existeLivroCodigo) return false;

        var livro = new Livro(codigo, titulo, editora, edicao, autores, anoPublicacao);
        Livros.Add(livro);
        return true;
    }

    public bool AdicionarUsuario(Usuario usuario)
    {
        var existeUsuarioCodigo = Usuarios.Any(u => u.VerificaCodigoUsuario(usuario.CodIdentificacao));
        if (existeUsuarioCodigo) return false;

        Usuarios.Add(usuario);
        return true;
    }

    public bool AdicionaExemplar(string codigoExemplar, Livro livro)
    {
        var existeExemplarCodigo = livro.ObtemExemplarPorCodigo(codigoExemplar) is not null;
        if (existeExemplarCodigo) return false;

        livro.AdicionarExemplar(codigoExemplar);
        return true;
    }

    public void CriarUsuarios()
    {
        AdicionarUsuario(new AlunoGraduacao("123", "João da Silva"));
        AdicionarUsuario(new AlunoPosGraduacao("456", "Luiz Fernando Rodrigues"));
        AdicionarUsuario(new AlunoGraduacao("789", "Pedro Paulo"));
        AdicionarUsuario(new Professor("100", "Carlos Lucena"));
    }

    public void CriarLivros()
    {
        AdicionarLivros("100", "Engenharia de Software", "Addison Wesley", ["Ian Sommervile"], "6ª", 2000);
        AdicionarLivros("101", "UML - Guia do Usuário", "Campus", ["Grady Booch", "James Rumbaugh", "Ivar Jacobson"],
            "7ª", 2000);
        AdicionarLivros("200", "Code Complete", "Microsoft Press", ["Steve McConnell"], "2ª", 2014);
        AdicionarLivros("201", "Agile Software Development Principles, Patterns and Practices", "Prentice Hall",
            ["Robert Martin"], "1ª", 2002);
        AdicionarLivros("300", "Refactoring: Improving the Design of Existing Code", "Addison Wesley Professional",
            ["Martin Fowler"], "1ª", 1999);
        AdicionarLivros("301", "Software Metrics: A rigorous and Practical Approach", "CRC Press",
            ["Norman Fenton", "James Bieman"], "3ª", 2014);
        AdicionarLivros("400", "Design Patterns: Element of Reusable Object-Oriented Software",
            "Addison Wesley Professional", ["Erich Gamma", "Richard Helm", "Ralph Johnson", "John Vlissides"], "1ª",
            1994);
        AdicionarLivros("401", "UML Distilled: A Brief Guide to the Standard Object Modeling Language",
            "Addison Wesley Professional", ["Martin Fowler"], "3ª", 2003);
    }

    public void CriaExemplares()
    {
        var livro100 = BuscarLivroPorCodigo("100")!;
        AdicionaExemplar("01", livro100);
        AdicionaExemplar("02", livro100);
        
        var livro101 = BuscarLivroPorCodigo("101")!;
        AdicionaExemplar("03", livro101);
        
        var livro200 = BuscarLivroPorCodigo("200")!;
        AdicionaExemplar("04", livro200);
        
        var livro201 = BuscarLivroPorCodigo("201")!;
        AdicionaExemplar("05", livro201);
        
        var livro300 = BuscarLivroPorCodigo("300")!;
        AdicionaExemplar("06", livro300);
        AdicionaExemplar("07", livro300);
        
        var livro400 = BuscarLivroPorCodigo("400")!;
        AdicionaExemplar("08", livro400);
        AdicionaExemplar("09", livro400);
    }
}