using Controle_do_Bar.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
