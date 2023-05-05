using Controle_do_Bar.Compartilhado;

namespace Controle_do_Bar.ModuloMesa
{
    public class RepositorioMesa : RepositorioBase<Mesa>
    {
        public RepositorioMesa(List<Mesa> listaMesas)
        {
            listaRegistros = listaMesas;
        }
    }
}
