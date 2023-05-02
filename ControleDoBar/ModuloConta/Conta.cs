﻿using Controle_do_Bar.Compartilhado;
using Controle_do_Bar.ModuloGarcom;
using Controle_do_Bar.ModuloMesa;
using Controle_do_Bar.ModuloPedido;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle_do_Bar.ModuloConta
{
    public class Conta : EntidadeBase
    {
        public Mesa mesa;
        public Garcom garcom;
        public ArrayList listaPedidos;
        public double total;
        public bool isOpen = true;

        public Conta(){}

        public Conta(Mesa mesa, Garcom garcom, ArrayList listaPedidos, double total)
        {
            this.mesa = mesa;
            this.garcom = garcom;
            this.listaPedidos = listaPedidos;
            this.total = total;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Conta contaAtualizada = (Conta)registroAtualizado;

            mesa = contaAtualizada.mesa;
            garcom = contaAtualizada.garcom;
            listaPedidos = contaAtualizada.listaPedidos;
            total = contaAtualizada.total;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();
            
            //erros

            return erros;
        }
    }
}
