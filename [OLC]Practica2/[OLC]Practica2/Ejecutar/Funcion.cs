﻿using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _OLC_Practica2.Ejecutar
{
    public class Funcion
    {
        public String nombre;
        public String id;//cuando hay sobrecarga el id es importante y para generarlo se concatena el nombre del metodo con todos los tipos de los parametros
        public String tipo;
        public String ambito;
        public ParseTreeNode raiz;

        public Funcion(String tipo, String nombre, String ambito, ParseTreeNode raiz)
        {
            this.nombre = nombre;
            this.tipo = tipo;
            this.raiz = raiz;
            //this.id=generarId(raiz.childNodes[3]);

        }

        public string generarId(ParseTreeNode parametros)
        {
            //aqui es donde se recorre la lista de parametros y se concatena el tipo de cada uno
            return "";
        }
    }
}