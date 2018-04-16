using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Irony.Ast;
using Irony.Parsing;
using _OLC_Practica2.controlDOT;
using System.Drawing;
using WINGRAPHVIZLib;
using System.IO;

namespace _OLC_Practica2.Analizador
{
    public class Sintactico
    {
        public static ParseTreeNode analizar(String cadena)
        {
            Gramatica gramatica = new Gramatica();
            LanguageData lenguaje = new LanguageData(gramatica);
            Parser parser = new Parser(lenguaje);
            ParseTree arbol = parser.Parse(cadena);
            ParseTreeNode raiz = arbol.Root;
            generarImagen(raiz);
            return arbol.Root;
        }

        public static Image getImage(ParseTreeNode raiz)
        {
            String grafoDOT = ControlDOT.getDOT(raiz);
            DOT dot = new DOT();
            BinaryImage img = dot.ToPNG(grafoDOT);
            byte[] imageBytes = Convert.FromBase64String(img.ToBase64String());
            MemoryStream ms = new MemoryStream(imageBytes,0,imageBytes.Length);
            Image imagen = Image.FromStream(ms,true);
            return imagen;
        }

        private static void generarImagen(ParseTreeNode raiz)
        {
            try
            {
                String grafo_en_DOT = ControlDOT.getDOT(raiz);
                DOT dot = new DOT();
                BinaryImage img = dot.ToPNG(grafo_en_DOT);
                img.Save("C:/Users/pablo/Documents/1er-Sem-2018/OLC1/[OLC]Practica2/[OLC]Practica2/bin/AST.png");
            }
            catch (Exception e) { }
        }
    }
}