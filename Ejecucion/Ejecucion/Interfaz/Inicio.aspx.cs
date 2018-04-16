using Ejecucion.Analisis;
using Ejecucion.Ejecucion;
using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WINGRAPHVIZLib;

namespace Ejecucion.Interfaz
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Gramatica grammar = new Gramatica();
            LanguageData lenguaje = new LanguageData(grammar);
            Parser p = new Parser(lenguaje);
            ParseTree arbol = p.Parse(txtCodigo.Text);
            ParseTreeNode raiz = arbol.Root;
            if (arbol.Root!=null)
            {
                txtSalida.Text = "Salida...";
                Programa programa = new Programa(txtSalida,arbol.Root);
                generarImagen(raiz);
                programa.generateGraph("Ejemplo.txt");


            }
            else
            {
                txtSalida.Text = "Ha ocurrido un error";
            }
        }

        private static void generarImagen(ParseTreeNode raiz)
        {
            String grafo_en_DOT = Programa.Genarbol(raiz);
            DOT dot = new DOT();
            BinaryImage img = dot.ToPNG(grafo_en_DOT);
            img.Save("C:/Users/pablo/Desktop/Arbol.png");
        }
    }
}