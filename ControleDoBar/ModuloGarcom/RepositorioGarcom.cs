﻿using Controle_do_Bar.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle_do_Bar.ModuloGarcom
{
    public class RepositorioGarcom : RepositorioBase<Garcom>
    {
        public RepositorioGarcom(List<Garcom> listaGarcom)
        {
            listaRegistros = listaGarcom;
        }

        public override Garcom SelecionarPorId(int id)
        {
            return base.SelecionarPorId(id);
        }
    }
}
