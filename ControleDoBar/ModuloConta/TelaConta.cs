using Controle_do_Bar.Compartilhado;
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
    public class TelaConta : TelaBase
    {
        RepositorioConta repositorioConta;

        TelaMesa telaMesa;

        TelaGarcom telaGarcom;

        TelaPedido telaPedido;


        public TelaConta(RepositorioBase repositorioBase, TelaMesa telaMesa, TelaGarcom telaGarcom, TelaPedido telaPedido) : base(repositorioBase)
        {
            nomeEntidadeSingular = "Conta";
            nomeEntidadePlural = "Contas";
            this.repositorioConta = (RepositorioConta)repositorioBase;
            this.telaMesa = telaMesa;
            this.telaGarcom = telaGarcom;
            this.telaPedido = telaPedido;
        }


        public override string ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine($"Cadastro de {nomeEntidadePlural}\n");

            Console.WriteLine($"Digite 1 para Abrir {nomeEntidadeSingular}");
            Console.WriteLine($"Digite 2 para Fazer um Novo Pedido");
            Console.WriteLine($"Digite 3 para Visualizar {nomeEntidadePlural} Abertas");
            Console.WriteLine($"Digite 4 para Fechar {nomeEntidadeSingular}");
            Console.WriteLine($"Digita 5 para Visualizar Total Faturado\n");

            Console.WriteLine("Digite s para Sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        protected override void MostrarTabela(ArrayList registros)
        {
            Console.WriteLine($"{"Id",-1} | {"Mesa",-15} | {"Garçom", -15} | Total");
            Console.WriteLine("-----------------------------------------");

            foreach (Conta conta in registros)
                if (conta.isOpen)
                    Console.WriteLine($"{conta.id,-2} | {conta.mesa.numero,-15} | {conta.garcom.nome, -15} | R${conta.total}");
        }

        public void VisualizaTotalFaturado()
        {
            ArrayList lista = repositorioConta.SelecionarTodos();
            double total = 0;
            foreach (Conta conta in lista)
                total += conta.total;
            Console.WriteLine("Total faturado: R$" + total);
        }

        protected override EntidadeBase ObterRegistro()
        {

            Mesa mesa = ObterMesa();
            Garcom garcom = ObterGarcom();
            Pedido pedido = ObterPedido();
            ArrayList listaPedidos = new ArrayList();
            listaPedidos.Add(pedido);
            string x;
            do
            {
                Console.WriteLine("Cadastrar novo Pedido? (s/n)");
                x = Console.ReadLine();
                if(x != "n")
                {
                    pedido = ObterPedido();
                    listaPedidos.Add(pedido);
                }
            }while (x != "n");

            double total = 0;
            foreach (Pedido p in listaPedidos) 
                total += p.total;

            return new Conta(mesa, garcom, listaPedidos, total);    
        }

        public void ObterNovoPedido()
        {
            VisualizarRegistros(false);
            
            Console.WriteLine("Digite o id da conta: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Conta conta = repositorioConta.SelecionarPorId(id);
            Pedido pedido = ObterPedido();
            conta.listaPedidos.Add(pedido);
        }

        private Mesa ObterMesa()
        {
            telaMesa.VisualizarRegistros(false);

            Mesa mesa = (Mesa)telaMesa.EncontrarRegistro("Digite o id da mesa: ");
            mesa.ocupada = true;

            Console.WriteLine();
            
            return mesa;
        }

        private Garcom ObterGarcom()
        {
            telaGarcom.VisualizarRegistros(false);

            Garcom garcom = (Garcom)telaGarcom.EncontrarRegistro("Digite o id do garçom: ");

            Console.WriteLine();

            return garcom;
        }

        private Pedido ObterPedido()
        { 

            Pedido pedido = telaPedido.ObterPedido();

            Console.WriteLine();

            return pedido;
        }

        public void FecharConta()
        {
            MostrarCabecalho($"Cadastro de {nomeEntidadePlural}", "Fechando a conta...");

            VisualizarRegistros(false);

            Console.WriteLine();

            Conta registro = (Conta)EncontrarRegistro("Digite o id do registro: ");

            registro.isOpen = false;

            registro.mesa.ocupada = false;

            MostrarMensagem("Conta fechada com sucesso!", ConsoleColor.Green);
        }
    }
}
