using Controle_do_Bar.Compartilhado;

namespace Controle_do_Bar.ModuloGarcom
{
    public class RepositorioGarcom : RepositorioBase<Garcom>
    {
        public RepositorioGarcom(List<Garcom> listaGarcom)
        {
            listaRegistros = listaGarcom;
        }
    }
}
