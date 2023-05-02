using Controle_do_Bar.Compartilhado;
using Controle_do_Bar.ModuloProduto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle_do_Bar.ModuloPedido
{
    public class RepositorioPedido : RepositorioBase
    {
        public RepositorioPedido(ArrayList listaPedidos)
        {
            listaRegistros = listaPedidos;
        }

        public override Pedido SelecionarPorId(int id)
        {
            return (Pedido)base.SelecionarPorId(id);
        }
    }
}
