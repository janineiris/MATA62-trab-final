namespace MATA62_Trab_Final;

public static class GerenciadorMensagens
{
    public static void ImprimeInicio()
    {
        Console.WriteLine("Sistema de Biblioteca. Para listar os comandos, envie \"help\"");
    }
    
    public static void ImprimeRecursoNaoEncontrado(string recurso)
    {
        Console.WriteLine($"Recurso {recurso} não encontrado");
    }
    
    public static void ImprimeErroComando(string comando, string erro)
    {
        Console.WriteLine($"Falha ao executar '{comando}': {erro}");
    }

    public static void Imprime(string mensagem)
    {
        Console.WriteLine(mensagem);
    }

    public static void ImprimeEmprestimo(Emprestimo emprestimo)
    {
        Console.WriteLine(
            $"Título: {emprestimo.GetTituloLivro()} | Data de Empréstimo: {emprestimo.DataEmprestimo} | Status: {emprestimo.GetNomeStatus()} | Data de Devolução{(emprestimo.VerificaEmprestimoDevolvido() ? "" : " Prevista")}: {(emprestimo.VerificaEmprestimoDevolvido() ? emprestimo.DataDevolucao : emprestimo.DataDevolucaoPrevista)}");
    }
    
    public static void ImprimeReserva(Reserva reserva)
    {
        Console.WriteLine($"Título: {reserva.GetTituloLivro()} | Data de Solicitação: {reserva.DataReserva}");
    }
}