namespace MATA62_Trab_Final;

public interface ILivroObservavel
{
    void AdicionarObservador(IObservador observador);
    void RemoverObservador(IObservador observador);
    void NotificarObservadores();
}