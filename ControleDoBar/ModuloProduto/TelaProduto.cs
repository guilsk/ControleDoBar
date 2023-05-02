using Controle_do_Bar.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle_do_Bar.ModuloProduto
{
    public class TelaProduto : TelaBase
    {
        public TelaProduto(RepositorioBase repositorioBase) : base(repositorioBase)
        {
            nomeEntidadeSingular = "Produto";
            nomeEntidadePlural = "Produtos";
        }

        protected override void MostrarTabela(ArrayList registros)
        {
            Console.WriteLine($"{"Id",-1} | {"Nome", -15} | Preço");
            Console.WriteLine("-----------------------------------------");

            foreach (Produto produto in registros)
                Console.WriteLine($"{produto.id,-2} | {produto.nome, -15} | R${produto.preco}");
        }

        protected override Produto ObterRegistro()
        {
            Console.WriteLine("Digite o nome: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o preço: ");
            double preco = Convert.ToDouble(Console.ReadLine());

            return new Produto(nome, preco);
        }
    }
}
