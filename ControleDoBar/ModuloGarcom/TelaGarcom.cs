using Controle_do_Bar.Compartilhado;

namespace Controle_do_Bar.ModuloGarcom
{
    public class TelaGarcom : TelaBase<Garcom>
    {
        public TelaGarcom(RepositorioGarcom repositorioBase) : base(repositorioBase)
        {
            nomeEntidadeSingular = "Garçom";
            nomeEntidadePlural = "Garçons";
        }

        protected override void MostrarTabela(List<Garcom> registros)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($"{"Id",-1} | Nome");
            Console.WriteLine("-----------------------------------------");

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            foreach (Garcom garcom in registros)
                Console.WriteLine($"{garcom.id, -2} | {garcom.nome}");
            Console.ResetColor();
        }

        protected override Garcom ObterRegistro()
        {
            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();

            return new Garcom(nome);
        }
    }
}
