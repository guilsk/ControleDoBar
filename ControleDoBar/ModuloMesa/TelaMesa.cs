using Controle_do_Bar.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle_do_Bar.ModuloMesa
{
    public class TelaMesa : TelaBase
    {
        public TelaMesa(RepositorioBase repositorioBase) : base(repositorioBase)
        {
            nomeEntidadeSingular = "Mesa";
            nomeEntidadePlural = "Mesas";
        }

        protected override void MostrarTabela(ArrayList registros)
        {
            Console.WriteLine($"{"Id",-1} | {"Número", -15} | Situação");
            Console.WriteLine("-----------------------------------------");

            foreach (Mesa mesa in registros)
                if(mesa.ocupada)
                    Console.WriteLine($"{mesa.id,-2} | {mesa.numero, -15} | Ocupada");
                else
                    Console.WriteLine($"{mesa.id,-2} | {mesa.numero, -15} | Desocupada");

        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.WriteLine("Digite o número: ");
            int numero = Convert.ToInt32(Console.ReadLine());

            return new Mesa(numero);
        }
    }
}
