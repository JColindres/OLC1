using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    public class NodoVar
    {
        public NodoVar sig = null, ant = null;
        public String tipo;
        public String nombre;
        public Object valor;
        public NodoVar(String tipo, String nombre)
        {
            this.nombre = nombre;
            this.tipo = tipo;
        }
    }
}
