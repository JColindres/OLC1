using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Ast;
using Irony.Interpreter;
using Irony.Parsing;
using Hoja_de_Trabajo_3.TablaSimbolos;
using System.Windows.Forms;

namespace Hoja_de_Trabajo_3.Analizador
{
    class Sintactico
    {
        /*public static ParseTreeNode analizar(String cadena)
         {
             Gramatica gramatica = new Gramatica();
             LanguageData lenguaje = new LanguageData(gramatica);
             Parser parser = new Parser(lenguaje);
             ParseTree arbol = parser.Parse(cadena);
             ParseTreeNode raiz = arbol.Root;
             return arbol.Root;
         }*/
        public Object resultado = 0;

        public bool isValid(string codigo, Grammar grammar)
        {
            LanguageData lenguaje = new LanguageData(grammar);
            Parser p = new Parser(lenguaje);
            ParseTree arbol = p.Parse(codigo);


            if (arbol.Root != null)
            {
                try
                {
                    resultado = (Object) ejecutar(arbol.Root);
                }
                catch { }
            }

            return arbol.Root != null;
        }

        public Object ejecutar(ParseTreeNode raiz)
        {
            string I = raiz.ToString();
            ParseTreeNode[] hijos = null;
            if (raiz.ChildNodes.Count > 0)
            {
                hijos = raiz.ChildNodes.ToArray();
            }
            switch (I)
            {
                case "S":
                    {
                        return ejecutar(hijos[0]);
                    }
                case "PROGRA":
                    {
                        return ejecutar(hijos[0]);
                    }
                case "SENTENCIAS":
                    {
                        return ejecutar(hijos[0]);
                    }
                case "DECLARACION":
                    {
                        String[] n1 = hijos[1].ToString().Split(new Char[] { ' ' });
                        Simbolos v = Form1.variables.buscar(n1[0]);
                        if (v == null)
                        {
                            Simbolos var = new Simbolos("int", n1[0]);
                            var.valor = ejecutar(hijos[3]);
                            Form1.variables.insertar(var);
                            return var.valor;
                        }
                        else if(v == null)
                        {
                            Simbolos var = new Simbolos("String", n1[0]);
                            var.valor = ejecutar(hijos[3]);
                            Form1.variables.insertar(var);
                            return var.valor;
                        }
                        else if (v == null)
                        {
                            Simbolos var = new Simbolos("double", n1[0]);
                            var.valor = ejecutar(hijos[3]);
                            Form1.variables.insertar(var);
                            return var.valor;
                        }
                        else if (v == null)
                        {
                            Simbolos var = new Simbolos("bool", n1[0]);
                            var.valor = ejecutar(hijos[3]);
                            Form1.variables.insertar(var);
                            return var.valor;
                        }
                        else
                        {
                            MessageBox.Show("variable ya existe");
                        }
                        return null;
                    }
                case "EXP":
                    {
                        return ejecutar(hijos[0]);
                    }
                case "E":
                    {
                        if (hijos.Count() == 1)
                        {
                            return ejecutar(hijos[0]);
                        }
                        else
                        {
                            Object iz = ejecutar(hijos[0]);
                            Object de = ejecutar(hijos[2]);

                            if (hijos[1].ToString().Contains("+"))
                            {
                                return Convert.ToDouble(iz) + Convert.ToDouble(de);
                            }
                            else
                            {
                                return Convert.ToDouble(iz) - Convert.ToDouble(de);
                            }
                        }
                    }
                case "T":
                    {
                        if (hijos.Count() == 1)
                        {
                            return ejecutar(hijos[0]);
                        }
                        else
                        {
                            Object iz = ejecutar(hijos[0]);
                            Object de = ejecutar(hijos[2]);

                            if (hijos[1].ToString().Contains("*"))
                            {
                                return Convert.ToDouble(iz) * Convert.ToDouble(de);
                            }
                            else
                            {
                                return Convert.ToDouble(iz) / Convert.ToDouble(de);
                            }
                        }
                    }
                case "R":
                    {
                        if (hijos.Count() == 1)
                        {
                            return ejecutar(hijos[0]);
                        }
                        else
                        {
                            Object iz = ejecutar(hijos[0]);
                            Object de = ejecutar(hijos[2]);
                            return Math.Pow(Convert.ToDouble(iz), Convert.ToDouble(de));
                        }
                    }
                case "F":
                    {
                        if (hijos[0].ToString().Contains("id"))
                        {
                            String[] n1 = hijos[0].ToString().Split(new Char[] { ' ' });

                            Simbolos v = Form1.variables.buscar(n1[0]);
                            if (v != null)
                            {
                                return v.valor;
                            }
                            else
                            {
                                MessageBox.Show("variable no declarada");
                                return null;
                            }
                        }
                        else if (hijos[0].ToString().Contains("numero"))
                        {
                            String[] n1 = hijos[0].ToString().Split(new Char[] { ' ' });
                            return Convert.ToDouble(n1[0]);
                        }
                        else if (hijos[0].ToString().Contains("doble"))
                        {
                            String[] n1 = hijos[0].ToString().Split(new Char[] { ' ' });
                            return Convert.ToDouble(n1[0]);
                        }
                        else if (hijos[0].ToString().Contains("cadena"))
                        {
                            String[] n1 = hijos[0].ToString().Split(new Char[] { ' ' });
                            return n1[0];
                        }
                        else
                        {
                            return ejecutar(hijos[0]);
                        }
                    }
            }

            return ejecutar(raiz);

        }
    }
}
