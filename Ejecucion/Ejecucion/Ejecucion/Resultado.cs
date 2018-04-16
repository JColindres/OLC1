using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ejecucion.Ejecucion
{
    public class Resultado
    {
        public Object valor;
        public String tipo;

        public Resultado(String tipo,Object valor)
        {
            this.tipo = tipo;
            this.valor = valor;
        }

    }
}