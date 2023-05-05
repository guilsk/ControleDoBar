using Controle_do_Bar.Compartilhado;

namespace Controle_do_Bar.ModuloProduto
{
    public class RepositorioProduto : RepositorioBase<Produto>
    {
        public RepositorioProduto(List<Produto> listaProdutos)
        {
            this.listaRegistros = listaProdutos;
        }
    }
}
