using Controle_do_Bar.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle_do_Bar.ModuloMesa
{
    public class TelaMesa : TelaBase<Mesa>
    {
        public TelaMesa(RepositorioMesa repositorioBase) : base(repositorioBase)
        {
            nomeEntidadeSingular = "Mesa";
            nomeEntidadePlural = "Mesas";
        }

        protected override void MostrarTabela(List<Mesa> registros)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($"{"Id",-1} | {"Número", -15} | Situação");
            Console.WriteLine("-----------------------------------------");

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            foreach (Mesa mesa in registros)
                if(mesa.ocupada)
                    Console.WriteLine($"{mesa.id,-2} | {mesa.numero, -15} | Ocupada");
                else
                    Console.WriteLine($"{mesa.id,-2} | {mesa.numero, -15} | Desocupada");
            Console.ResetColor();
        }

        protected override Mesa ObterRegistro()
        {
            Console.Write("Digite o número: ");
            int numero;

            try
            {
                numero = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                numero = 0;
            }

            return new Mesa(numero);
        }
    }
}
