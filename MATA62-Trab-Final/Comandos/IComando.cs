namespace MATA62_Trab_Final.Comandos;

public interface IComando
{
    protected string Comando { get; set; }
    
    void Executar(string[] args);
}