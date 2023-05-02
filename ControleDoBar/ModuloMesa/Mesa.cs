using Controle_do_Bar.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle_do_Bar.ModuloMesa
{
    public class Mesa : EntidadeBase
    {
        public int numero;
        public bool ocupada;

        public Mesa(){}

        public Mesa(int numero)
        {
            this.numero = numero;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Mesa mesaAtualizada = (Mesa)registroAtualizado;

            numero = mesaAtualizada.numero;
            ocupada = mesaAtualizada.ocupada;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (double.IsNaN(numero))
                erros.Add("O campo \"numero\" é obrigatório e deve ser um número válido");

            return erros;
        }
    }
}
