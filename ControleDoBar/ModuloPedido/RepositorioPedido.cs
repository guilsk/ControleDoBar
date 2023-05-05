using Controle_do_Bar.Compartilhado;

namespace Controle_do_Bar.ModuloPedido
{
    public class RepositorioPedido : RepositorioBase<Pedido>
    {
        public RepositorioPedido(List<Pedido> listaPedidos)
        {
            listaRegistros = listaPedidos;
        }

        public override Pedido SelecionarPorId(int id)
        {
            return base.SelecionarPorId(id);
        }
    }
}
