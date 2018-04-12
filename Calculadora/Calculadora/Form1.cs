using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class Form1 : Form
    {
        public static ListVar variables = new ListVar();
        public Form1()
        {
            InitializeComponent();
        }

       
        private void textBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Analisis ej2 = new Analisis();
                if (ej2.isValid(textBox1.Text, new Sintactico()))
                {
                    richTextBox1.Text += "\n" + textBox1.Text +" = " + ej2.resultado;
                    textBox1.Text = "";
                }
                else
                {
                    MessageBox.Show("Invalido ");

                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
