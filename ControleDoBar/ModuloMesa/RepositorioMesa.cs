using Controle_do_Bar.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle_do_Bar.ModuloMesa
{
    public class RepositorioMesa : RepositorioBase<Mesa>
    {
        public RepositorioMesa(List<Mesa> listaMesas)
        {
            listaRegistros = listaMesas;
        }
    }
}
