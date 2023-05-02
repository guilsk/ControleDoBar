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
    public class TelaPedido : TelaBase
    {
        public TelaProduto telaProduto;

        public TelaPedido(RepositorioBase repositorioBase, TelaProduto telaProduto) : base(repositorioBase)
        {
            nomeEntidadeSingular = "Pedido";
            nomeEntidadePlural = "Pedidos";
            this.telaProduto = telaProduto;
        }

        protected override void MostrarTabela(ArrayList registros)
        {
            Console.WriteLine($"{"Id",-1} | {"Produto",-15} | {"Quantidade",-15} | Total");
            Console.WriteLine("-----------------------------------------");

            foreach (Pedido pedido in registros)
                Console.WriteLine($"{pedido.id,-2} | {pedido.produto.nome,-15} | {pedido.quantidade,-15} | R${pedido.total}");
        }

        protected override Pedido ObterRegistro()
        {
            Produto produto = ObterProduto();

            Console.WriteLine("Digite a quantidade: ");
            int quantidade = Convert.ToInt32(Console.ReadLine());

            double total = produto.preco * quantidade;

            return new Pedido(produto, quantidade, total);
        }

        public Pedido ObterPedido()
        {
            Produto produto = ObterProduto();

            Console.WriteLine("Digite a quantidade: ");
            int quantidade = Convert.ToInt32(Console.ReadLine());

            double total = produto.preco * quantidade;

            return new Pedido(produto, quantidade, total);
        }

        private Produto ObterProduto()
        {
            telaProduto.VisualizarRegistros(false);

            Produto produto = (Produto)telaProduto.EncontrarRegistro("Digite o id do produto: ");

            Console.WriteLine();

            return produto;
        }
    }
}
