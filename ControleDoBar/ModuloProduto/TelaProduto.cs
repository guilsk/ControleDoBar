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
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($"{"Id",-1} | {"Nome", -15} | Preço");
            Console.WriteLine("-----------------------------------------");

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            foreach (Produto produto in registros)
                Console.WriteLine($"{produto.id,-2} | {produto.nome, -15} | R${produto.preco}");
            Console.ResetColor();
        }

        protected override Produto ObterRegistro()
        {
            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();

            double preco;

            Console.Write("Digite o preço: ");
            try
            {
                preco = Convert.ToDouble(Console.ReadLine());
            }
            catch
            {
                preco = 0;
            }

            return new Produto(nome, preco);
        }
    }
}
