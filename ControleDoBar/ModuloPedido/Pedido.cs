﻿using Controle_do_Bar.Compartilhado;
using Controle_do_Bar.ModuloProduto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle_do_Bar.ModuloPedido
{
    public class Pedido : EntidadeBase
    {
        public Produto produto;
        public int quantidade;
        public double total;

        public Pedido(){}

        public Pedido(Produto produto, int quantidade, double total)
        {
            this.produto = produto;
            this.quantidade = quantidade;
            this.total = total;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            throw new NotImplementedException();
        }

        public override ArrayList Validar()
        {
            throw new NotImplementedException();
        }
    }
}
