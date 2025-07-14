namespace MATA62_Trab_Final;

public interface IRegraEmprestimo
{
    bool PodeEmprestar(Usuario usuario, Livro livro, out string mensagemErro);
}