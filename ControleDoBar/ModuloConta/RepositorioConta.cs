using Controle_do_Bar.Compartilhado;
namespace Controle_do_Bar.ModuloConta
{
    public class RepositorioConta : RepositorioBase<Conta>
    {
        public RepositorioConta(List<Conta> listaConta)
        {
            listaRegistros = listaConta;
        }
    }
}
