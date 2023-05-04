using Controle_do_Bar.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle_do_Bar.ModuloConta
{
    public class RepositorioConta : RepositorioBase<Conta>
    {
        public RepositorioConta(List<Conta> listaConta)
        {
            listaRegistros = listaConta;
        }

        public override Conta SelecionarPorId(int id)
        {
            return base.SelecionarPorId(id);
        }
    }
}
