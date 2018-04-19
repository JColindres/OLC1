using _OLC_Practica2.Analizador;
using Irony.Parsing;
using System;
using System.Collections.Generic;
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
            ParseTreeNode resultado = Sintactico.analizar(entrada.Text);
            if (resultado != null)
            {
                Label1.Text = "La cadena es correcta";
                salida.Text = "Resultado...";
                Ejecutar.Programa programa = new Ejecutar.Programa(salida,resultado);
            }
            else
            {
                Label1.Text = "La cadena es incorrecta";
                salida.Text = "error";
            }
        }

        protected void Mostrar(object sender, EventArgs e)
        {
            imagen1.Visible = true;
        }
    }
}