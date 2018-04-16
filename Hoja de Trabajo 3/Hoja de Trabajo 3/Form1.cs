using Hoja_de_Trabajo_3.Analizador;
using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hoja_de_Trabajo_3.TablaSimbolos;

namespace Hoja_de_Trabajo_3
{
    public partial class Form1 : Form
    {
        public static Tabla variables = new Tabla();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sintactico ej2 = new Sintactico();
            if (ej2.isValid(richTextBox1.Text, new Gramatica()))
            {
                label1.Text += ej2.resultado + ",";
            }
            else
            {
                MessageBox.Show("Invalido ");

            }
        }
    }
}
