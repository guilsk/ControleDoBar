using Controle_do_Bar.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle_do_Bar.ModuloGarcom
{
    public class TelaGarcom : TelaBase
    {
        public TelaGarcom(RepositorioGarcom repositorioGarcom) : base(repositorioGarcom)
        {
            nomeEntidadeSingular = "Garçom";
            nomeEntidadePlural = "Garçons";
        }

        protected override void MostrarTabela(ArrayList registros)
        {
            Console.WriteLine($"{"Id",-1} | Nome");
            Console.WriteLine("-----------------------------------------");

            foreach (Garcom garcom in registros)
            Console.WriteLine($"{garcom.id, -2} | {garcom.nome}");
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.WriteLine("Digite o nome: ");
            string nome = Console.ReadLine();

            return new Garcom(nome);
        }
    }
}
