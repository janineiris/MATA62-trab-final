namespace MATA62_Trab_Final;

public interface IObservador
{
    string CodigoUsuario { get; }
    int ContadorNotificacoes { get; }
    void Notificar(Livro livro);
}