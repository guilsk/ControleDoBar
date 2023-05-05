using Controle_do_Bar.Compartilhado;
using Controle_do_Bar.ModuloGarcom;
using Controle_do_Bar.ModuloMesa;
using Controle_do_Bar.ModuloPedido;
using System.Collections;

namespace Controle_do_Bar.ModuloConta
{
    public class TelaConta : TelaBase<Conta>
    {
        RepositorioConta repositorioConta;

        TelaMesa telaMesa;
        RepositorioMesa repositorioMesa;

        TelaGarcom telaGarcom;
        RepositorioGarcom repositorioGarcom;

        TelaPedido telaPedido;


        public TelaConta(RepositorioConta repositorioBase, TelaMesa telaMesa, TelaGarcom telaGarcom, TelaPedido telaPedido, RepositorioMesa repositorioMesa, RepositorioGarcom repositorioGarcom) : base(repositorioBase)
        {
            nomeEntidadeSingular = "Conta";
            nomeEntidadePlural = "Contas";

            repositorioConta = repositorioBase;
            this.telaMesa = telaMesa;
            this.telaGarcom = telaGarcom;
            this.telaPedido = telaPedido;
            this.repositorioMesa = repositorioMesa;
            this.repositorioGarcom = repositorioGarcom;
        }

        public override string ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine($"Cadastro de {nomeEntidadePlural}\n");

            Console.WriteLine($"Digite 0 para Sair");
            Console.WriteLine($"Digite 1 para Abrir {nomeEntidadeSingular}");
            Console.WriteLine($"Digite 2 para Fazer um Novo Pedido");
            Console.WriteLine($"Digite 3 para Visualizar {nomeEntidadePlural} Abertas");
            Console.WriteLine($"Digite 4 para Fechar {nomeEntidadeSingular}");
            Console.WriteLine($"Digita 5 para Visualizar Total Faturado\n");

            string opcao = Console.ReadLine();

            return opcao;
        }

        protected override void MostrarTabela(List<Conta> registros)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($"{"Id",-1} | {"Mesa",-15} | {"Garçom", -15} | Total");
            Console.WriteLine("-----------------------------------------");

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            foreach (Conta conta in registros)
                if (conta.isOpen)
                    Console.WriteLine($"{conta.id,-2} | {conta.mesa.numero,-15} | {conta.garcom.nome, -15} | R${conta.total}");
            Console.ResetColor();
        }

        public void VisualizaTotalFaturado()
        {
            List<Conta> lista = repositorioConta.SelecionarTodos();

            double total = 0;

            foreach (Conta conta in lista)
                total += conta.total;

            Console.WriteLine("Total faturado: R$" + total);
        }

        protected override Conta ObterRegistro()
        {
            if (!repositorioMesa.TemRegistros())
                return new Conta();

            Mesa mesa = ObterMesa();

            if (!repositorioGarcom.TemRegistros())
                return new Conta();

            Garcom garcom = ObterGarcom();

            Pedido pedido = ObterPedido();

            ArrayList listaPedidos = new(){pedido};
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
            }
            while (x != "n");

            double total = 0;

            foreach (Pedido p in listaPedidos) 
                total += p.total;

            return new Conta(mesa, garcom, listaPedidos, total);    
        }

        public void ObterNovoPedido()
        {
            MostrarCabecalho($"Cadastro de {nomeEntidadePlural}", "Fazendo novo Pedido...");

            List<Conta> registros = repositorioBase.SelecionarTodos();

            if (registros.Count == 0)
            {
                MostrarMensagem("Nenhum registro cadastrado", ConsoleColor.DarkYellow);
                return;
            }


            VisualizarRegistros(false);
            
            Console.Write("Digite o id da conta: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Conta conta = repositorioConta.SelecionarPorId(id);
            if (!conta.isOpen)
            {
                MostrarMensagem("Esta conta está fechada", ConsoleColor.DarkRed);
                return;
            }

            Pedido pedido = ObterPedido();

            conta.listaPedidos.Add(pedido);

            double total = 0;

            foreach (Pedido p in conta.listaPedidos)
                total += p.total;

            conta.total = total;
        }

        private Mesa ObterMesa()
        {
            telaMesa.VisualizarRegistros(false);

            Mesa mesa = telaMesa.EncontrarRegistro("Digite o id da mesa: ");
            mesa.ocupada = true;

            Console.WriteLine();
            
            return mesa;
        }

        private Garcom ObterGarcom()
        {
            telaGarcom.VisualizarRegistros(false);

            Garcom garcom = telaGarcom.EncontrarRegistro("Digite o id do garçom: ");

            Console.WriteLine();

            return garcom;
        }

        private Pedido ObterPedido()
        { 

            Pedido pedido = telaPedido.ObterPedido();

            Console.WriteLine();

            return pedido;
        }

        public override void InserirNovoRegistro()
        {
            MostrarCabecalho($"Cadastro de {nomeEntidadePlural}", "Inserindo um novo registro...");

            Conta registro = ObterRegistro();

            if (TemErrosDeValidacao(registro))
                return;

            repositorioBase.Inserir(registro);

            MostrarMensagem("Registro inserido com sucesso!", ConsoleColor.Green);
        }

        public void FecharConta()
        {
            MostrarCabecalho($"Cadastro de {nomeEntidadePlural}", "Fechando a conta...");

            List<Conta> registros = repositorioBase.SelecionarTodos();

            if (registros.Count == 0)
            {
                MostrarMensagem("Nenhum registro cadastrado", ConsoleColor.DarkYellow);
                return;
            }

            VisualizarRegistros(false);

            Console.WriteLine();

            Conta registro = EncontrarRegistro("Digite o id do registro: ");

            registro.isOpen = false;

            registro.mesa.ocupada = false;

            MostrarMensagem("Conta fechada com sucesso!", ConsoleColor.Green);
        }
    }
}
