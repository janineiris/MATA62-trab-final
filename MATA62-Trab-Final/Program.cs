// See https://aka.ms/new-console-template for more information

using MATA62_Trab_Final;

var repositorio = Repositorio.ObterInstancia();
repositorio.CriarUsuarios();
repositorio.CriarLivros();
repositorio.CriaExemplares();
var interfaceComando = InterfaceComandosUsuario.ObterInstancia();

GerenciadorMensagens.ImprimeInicio();

string? input;
while((input = Console.ReadLine()) != null)
{
    if (string.IsNullOrWhiteSpace(input)) continue;
    
    var inputArgs = input.Split(' ');
    var comando = inputArgs.First();
    var parametros = inputArgs.Skip(1).ToArray();
    
    if(comando == "sai") break;
    
    interfaceComando.ExecutarComando(comando, parametros);
}