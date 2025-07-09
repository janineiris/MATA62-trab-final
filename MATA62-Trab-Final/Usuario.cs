namespace MATA62_Trab_Final;

public class Usuario
{
    public string CodIdentificacao { get; protected set; }
    public string Nome { get; protected set; }

    public bool VerificaCodigoUsuario(string codigo)
    {
        return CodIdentificacao == codigo;
    }
}