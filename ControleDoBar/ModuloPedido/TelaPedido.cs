using Controle_do_Bar.Compartilhado;
using Controle_do_Bar.ModuloProduto;

namespace Controle_do_Bar.ModuloPedido
{
    public class TelaPedido : TelaBase<Pedido>
    {
        public TelaProduto telaProduto;

        public TelaPedido(RepositorioPedido repositorioBase, TelaProduto telaProduto) : base(repositorioBase)
        {
            nomeEntidadeSingular = "Pedido";
            nomeEntidadePlural = "Pedidos";
            this.telaProduto = telaProduto;
        }

        protected override void MostrarTabela(List<Pedido> registros)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($"{"Id",-1} | {"Produto",-15} | {"Quantidade",-15} | Total");
            Console.WriteLine("-----------------------------------------");

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            foreach (Pedido pedido in registros)
                Console.WriteLine($"{pedido.id,-2} | {pedido.produto.nome,-15} | {pedido.quantidade,-15} | R${pedido.total}");
            Console.ResetColor();
        }

        protected override Pedido ObterRegistro()
        {
            Produto produto = ObterProduto();

            Console.Write("Digite a quantidade: ");
            int quantidade = Convert.ToInt32(Console.ReadLine());

            double total = produto.preco * quantidade;

            return new Pedido(produto, quantidade, total);
        }

        public Pedido ObterPedido()
        {
            Produto produto = ObterProduto();

            Console.Write("Digite a quantidade: ");
            int quantidade = Convert.ToInt32(Console.ReadLine());

            double total = produto.preco * quantidade;

            return new Pedido(produto, quantidade, total);
        }

        private Produto ObterProduto()
        {
            telaProduto.VisualizarRegistros(false);

            Produto produto = telaProduto.EncontrarRegistro("Digite o id do produto: ");

            Console.WriteLine();

            return produto;
        }
    }
}
