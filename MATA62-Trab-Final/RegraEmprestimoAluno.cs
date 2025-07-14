namespace MATA62_Trab_Final;

public class RegraEmprestimoAluno : IRegraEmprestimo
{
    private readonly int _limiteEmprestimos;

    public RegraEmprestimoAluno(int limiteEmprestimos)
    {
        _limiteEmprestimos = limiteEmprestimos;
    }

    public bool PodeEmprestar(Usuario usuario, Livro livro, out string mensagemErro)
    {
        mensagemErro = "";

        if (usuario is not UsuarioEmprestador emprestador)
        {
            mensagemErro = "Usuário não pode realizar empréstimo.";
            return false;
        }

        if (!livro.TemExemplarDisponivel())
        {
            mensagemErro = "Não há exemplares disponíveis.";
            return false;
        }

        if (emprestador.VerificaUsuarioDevedor())
        {
            mensagemErro = "Usuário está com livro em atraso.";
            return false;
        }

        if (emprestador.ObtemEmprestimosAtivos().Count >= _limiteEmprestimos)
        {
            mensagemErro = "Usuário atingiu o limite de empréstimos.";
            return false;
        }

        bool usuarioTemReserva = livro.ObtemReservaAtivaUsuario(emprestador.CodIdentificacao) is not null;

        if (!usuarioTemReserva && livro.QuantidadeReservas >= livro.QuantidadeExemplaresDisponiveis)
        {
            mensagemErro = "Livro possui muitas reservas e o usuário não tem reserva.";
            return false;
        }

        if (emprestador.ObtemEmprestimoLivro(livro.CodIdentificacao) is not null)
        {
            mensagemErro = "Usuário já possui empréstimo deste livro.";
            return false;
        }

        return true;
    }
}