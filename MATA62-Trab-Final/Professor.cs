namespace MATA62_Trab_Final;

public class Professor: UsuarioEmprestador, IObservador
{
    public string CodigoUsuario => CodIdentificacao;
    
    public int ContadorNotificacoes { get; private set; } = 0;
    
    public Professor(string codigo, string nome)
    {
        TempoEmprestimo = 8;
        CodIdentificacao = codigo;
        Nome = nome;
    }
    
    public override bool VerificaViabilidadeEmprestimo(Livro livro, out string? motivoRejeicao)
    {
        var existeExemplarDisponivel = livro.TemExemplarDisponivel();
        var existeEmprestimoAtrasado = VerificaUsuarioDevedor();
        
        motivoRejeicao = !existeExemplarDisponivel ? "não há exemplares disponíveis" :
            existeEmprestimoAtrasado ? "o usuário está com livro em atraso" : null;

        return existeExemplarDisponivel && !existeEmprestimoAtrasado;
    }
    
    public void Notificar(Livro livro)
    {
        ContadorNotificacoes++;
        GerenciadorMensagens.Imprime($"Professor {Nome} notificado: livro '{livro.Titulo}' tem mais de 2 reservas.");
    }
}