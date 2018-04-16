using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Ast;
using Irony.Interpreter;
using Irony.Parsing;

namespace Hoja_de_Trabajo_3.TablaSimbolos
{
   public class Simbolos
    {
        public Simbolos sig = null, ant = null;
        public String nombre;
        public Object valor;
        public String ambito;
        public String tipo;

        public Simbolos(String tipo, String nombre)
        {
            this.nombre = nombre;
            this.tipo = tipo;
        }
    }
}
