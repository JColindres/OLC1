using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _OLC_Practica2.Ejecutar
{
    public class Clase
    {
        public String nombre;
        public String tipo;
        public String ambito;
        public ParseTreeNode raiz;

        public Clase(String tipo, String nombre, String ambito, ParseTreeNode raiz)
        {
            this.nombre = nombre;
            this.tipo = tipo;
            this.raiz = raiz;
        }        
    }
}