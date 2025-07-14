namespace MATA62_Trab_Final;

public class RegraEmprestimoProfessor : IRegraEmprestimo
{
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

        return true;
    }
}