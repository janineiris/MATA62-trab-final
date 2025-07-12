namespace MATA62_Trab_Final.Comandos;

public class Program
{
    public static void Main(string[] args)
    {
        var interpretador = new HelpComando();

        while (true)
        {
            Console.Write("> ");
            string linha = Console.ReadLine();

            if (linha == "sair") break;

            interpretador.ExecutarLinha(linha);
        }
    }
}