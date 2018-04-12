using _OLC_Practica2.Analizador;
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
            bool resultado = Sintactico.analizar(entrada.Text);
            if (resultado)
            {
                Label1.Text = "La cadena es correcta";
            }
            else
            {
                Label1.Text = "La cadena es incorrecta";
            }
        }
    }
}