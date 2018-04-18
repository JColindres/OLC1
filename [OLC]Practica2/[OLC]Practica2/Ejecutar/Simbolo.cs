using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _OLC_Practica2.Ejecutar
{
    public class Simbolo
    {
        public String nombre;
        public String tipo;
        public Object valor;
        public String ambito;

        public Simbolo(String tipo, String nombre, String ambito, Object valor)
        {
            this.tipo = tipo;
            this.nombre = nombre;
            this.ambito = ambito;
            this.valor = valor;
        }
    }
}