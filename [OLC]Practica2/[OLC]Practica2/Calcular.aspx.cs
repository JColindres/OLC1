using _OLC_Practica2.Analizador;
using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _OLC_Practica2
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Analizar(object sender, EventArgs e)
        {
            Gramatica gramatica = new Gramatica();
            LanguageData lenguaje = new LanguageData(gramatica);
            Parser parser = new Parser(lenguaje);
            ParseTree arbol = parser.Parse(entrada.Text);
            ParseTreeNode resultado = arbol.Root;
            Sintactico.generarImagen(resultado);
            if (resultado != null)
            {
                Label1.Text = "La cadena es correcta";
                salida.Text = "Resultado...";
                Ejecutar.Programa programa = new Ejecutar.Programa(salida,resultado);
                GridView1.Visible = false;
            }
            else
            {
                Label1.Text = "La cadena es incorrecta";
                salida.Text = "error";
                DataTable error = new DataTable();
                error.Clear();
                error.Columns.Add("No.");
                error.Columns.Add("Error");
                error.Columns.Add("Fila");
                error.Columns.Add("Columna");
                DataRow fila;
                for (int i = 0; i < arbol.ParserMessages.Count; i++)
                {
                    fila = error.NewRow();
                    fila["No."] = i+1;
                    fila["Error"] = arbol.ParserMessages[i].Message.ToString();
                    fila["Fila"] = arbol.ParserMessages[i].Location.Line.ToString();
                    fila["Columna"] = arbol.ParserMessages[i].Location.Column.ToString();
                    error.Rows.Add(fila);
                }
                GridView1.DataSource = error;
                GridView1.DataBind();
                GridView1.Visible = true;
            }
        }

        protected void Mostrar(object sender, EventArgs e)
        {
            imagen1.Visible = true;
        }
    }
}