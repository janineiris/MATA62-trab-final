namespace MATA62_Trab_Final;

enum StatusReserva
{
    ATIVA,
    CANCELADA
}

public class Reserva
{
    public Livro Livro { get; private set; }
    public Usuario Usuario { get; private set; }
    public string DataReserva { get; private set; }
    private StatusReserva Status { get; set; } = StatusReserva.ATIVA;
    
    public void Cancelar()
    {
        Status = StatusReserva.CANCELADA;
    }

    public bool VerificaReservaAtiva()
    {
        return Status == StatusReserva.ATIVA;
    }

    public bool VerificaLivroPorCodigo(string codigoLivro)
    {
        return Livro.VerificaCodigoLivro(codigoLivro);
    }

    public string GetTituloLivro()
    {
        return Livro.Titulo;
    }
    
    public string GetNomeUsuario()
    {
        return Usuario.Nome;
    }
}