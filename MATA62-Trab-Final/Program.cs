﻿namespace MATA62_Trab_Final.Comandos;

public class Program
{
    public static void Main(string[] args)
    {
        var repositorio = Repositorio.ObterInstancia();
        repositorio.CriarUsuarios();
        repositorio.CriarLivros();
        repositorio.CriaExemplares();
        
        GerenciadorMensagens.ImprimeInicio();
        
        var interpretador = InterpretadorComandos.ObterInstancia();
        
        while (true)
        {
            Console.Write("> ");
            string? linha = Console.ReadLine();

            if (linha == "sai") break;
            if (linha is null) continue;

            interpretador.ExecutarLinha(linha);
        }
    }
}