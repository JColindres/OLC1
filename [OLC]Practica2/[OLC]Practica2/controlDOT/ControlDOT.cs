﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Irony.Ast;
using Irony.Parsing;

namespace _OLC_Practica2.controlDOT
{
    public class ControlDOT
    {
        /*
         *digraph G{ 
         * nodo0[label="etiqueta"];
         * nodo1[label="hijo1"];
         * nodo2[label="hijo2"];
         * nodo0->nodo1;
         * nodo0->nodo2;
         * }
         */

        private static int contador;
        private static String grafo;

        public static String getDOT(ParseTreeNode raiz) {
            grafo = "digraph G{";
            grafo += "nodo0[label=\"" + escapar(raiz.ToString()) + "\"];\n";
            contador = 1;
            recorrerAST("nodo0",raiz);
            grafo += "}";
            return grafo;
        }

        private static void recorrerAST(String padre, ParseTreeNode hijos)
        {
            foreach (ParseTreeNode hijo in hijos.ChildNodes)
            {
                String nombreHijo = "nodo" + contador.ToString();
                grafo += nombreHijo + "[label=\"" + escapar(hijo.ToString()) + "\"];\n";
                grafo += padre + "->" + nombreHijo + ";\n";
                contador++;
                recorrerAST(nombreHijo,hijo);
            }
        }

        private static String escapar(String cadena)
        {
            cadena = cadena.Replace("\\","\\\\");
            cadena = cadena.Replace("\"", "\\\"");
            return cadena;
        }
    }
}