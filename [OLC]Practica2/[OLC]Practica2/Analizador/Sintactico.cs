using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Irony.Ast;
using Irony.Parsing;
using _OLC_Practica2.controlDOT;
using System.Drawing;

namespace _OLC_Practica2.Analizador
{
    public class Sintactico : Grammar
    {
        public static bool analizar(String cadena)
        {
            Gramatica gramatica = new Gramatica();
            LanguageData lenguaje = new LanguageData(gramatica);
            Parser parser = new Parser(lenguaje);
            ParseTree arbol = parser.Parse(cadena);
            ParseTreeNode raiz = arbol.Root;

            if (raiz == null) {
                return false;
            }
            //generarImagen(raiz);
            //Console.WriteLine("Imagen Cargada");
            return true;
        }

        private static void generarImagen(ParseTreeNode raiz)
        {
            String grafoDOT = ControlDOT.getDOT(raiz);
            WINGRAPHVIZLib.DOT dot = new WINGRAPHVIZLib.DOT();
            WINGRAPHVIZLib.BinaryImage img = dot.ToPNG(grafoDOT);
            img.Save("AST.png");
        }
    }
}