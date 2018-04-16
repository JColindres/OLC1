using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Parsing;
using System.Windows.Forms;
using System.IO;

namespace Calculadora
{
    class Analisis
    {
        String graph = "";
        public Double resultado = 0;
       
        public bool isValid(string codigo, Grammar grammar)
        {
            LanguageData lenguaje = new LanguageData(grammar);
            Parser p = new Parser(lenguaje);
            ParseTree arbol = p.Parse(codigo);


            if (arbol.Root != null)
            {
                Genarbol(arbol.Root);
                GenerateGraph("Ejemplo.txt", "C:/Users/pablo/Desktop/");
                try
                {
                    resultado = (Double) ejecutar(arbol.Root);
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
                case "DECLA":
                    { 
                          String[] n1 = hijos[1].ToString().Split(new Char[] { ' ' });
                          NodoVar v = Form1.variables.buscar(n1[0]);
                          if (v == null)
                          {
                              NodoVar var = new NodoVar("var", n1[0]);
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
                case "E":
                    {
                        return ejecutar(hijos[0]);
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

                            if (hijos[1].ToString().Contains("+"))
                            {
                                return Convert.ToDouble( iz) + Convert.ToDouble( de);
                            }
                            else
                            {
                                return Convert.ToDouble(iz) + Convert.ToDouble(de);
                            }
                        }
                    }
                case "F":
                    {
                        if (hijos.Count() == 1)
                        {
                            return ejecutar(hijos[0]);
                        }
                        else
                        {
                            Object iz = ejecutar(hijos[0]);
                            Object de = ejecutar(hijos[2]);

                            if (hijos[1].ToString().Contains("/"))
                            {
                                return Convert.ToDouble(iz) / Convert.ToDouble(de);
                            }
                            else
                            {
                                return Convert.ToDouble(iz) * Convert.ToDouble(de);
                            }
                        }
                    }
                case "G":
                    {
                        if (hijos.Count() == 1)
                        {
                            return ejecutar(hijos[0]);
                        }
                        else
                        {
                            Object iz = ejecutar(hijos[0]);
                            Object de = ejecutar(hijos[2]);                            
                                return Math.Pow( Convert.ToDouble(iz) , Convert.ToDouble(de));
                        }
                    }
                case "H":
                    {
                        if (hijos.Count() == 1)
                        {
                            return ejecutar(hijos[0]);
                        }
                        else
                        {
                            Object de = ejecutar(hijos[1]);
                            return (-1 * Convert.ToDouble(de));
                        }
                    }
                case "I":
                    {
                        if (hijos.Count() == 1)
                        {
                            return ejecutar(hijos[0]);
                        }
                        else
                        {
                            Object iz = ejecutar(hijos[0]);
                            Object de = ejecutar(hijos[2]);

                            if (hijos[1].ToString().Contains("--"))
                            {
                                String[] n1 = hijos[0].ToString().Split(new Char[] { ' ' });
                                NodoVar v = Form1.variables.buscar(n1[0]);
                                 if (v != null)
                                 {
                                     v.valor = Convert.ToDouble(v.valor) - 1;
                                     return v.valor;
                                 }
                                 else
                                 {
                                     MessageBox.Show("VAriable no declarada");
                                     return null;
                                 }
                            }
                            else
                            {
                                String[] n1 = hijos[0].ToString().Split(new Char[] { ' ' });
                                NodoVar v = Form1.variables.buscar(n1[0]);
                                if (v != null)
                                {
                                    v.valor = Convert.ToDouble(v.valor) + 1;
                                    return v.valor;
                                }
                                else
                                {
                                    MessageBox.Show("VAriable no declarada");
                                    return null;
                                }
                            }
                        }
                    }
                case "J":
                    {
                        if (hijos[0].ToString().Contains("id"))
                        { 
                            String[] n1 = hijos[0].ToString().Split(new Char[] { ' ' });

                            NodoVar v = Form1.variables.buscar(n1[0]);
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
                        else if (hijos[0].ToString().Contains("entero"))
                        {
                            String[] n1 = hijos[0].ToString().Split(new Char[] { ' ' });
                            return Convert.ToDouble(n1[0]);
                        }
                        else if (hijos[0].ToString().Contains("doble"))
                        {
                            String[] n1 = hijos[0].ToString().Split(new Char[] { ' ' });
                            return Convert.ToDouble(n1[0]);
                        }
                        else
                        {
                            return ejecutar(hijos[0]);
                        }
                    }
                case "FUN":
                    {
                        Object e = ejecutar(hijos[1]);
                        if (hijos[0].ToString().Contains("cos"))
                        {
                            return Math.Cos(Convert.ToDouble(e));
                        }
                        else if (hijos[0].ToString().Contains("sin"))
                        {
                            return Math.Sin(Convert.ToDouble(e));
                        }
                        else
                        {
                            return Math.Tan(Convert.ToDouble(e));
                        }
                    }
                case "CON":
                    {
                        if (hijos[0].ToString().Contains("pi"))
                        {
                            return 3.1416;
                        }
                        else
                        {
                            return 2.7182;
                        }
                    }
            }

            return null;
        
        }
        public void Genarbol(ParseTreeNode raiz)
        {
            System.IO.StreamWriter f = new System.IO.StreamWriter("C:/Users/pablo/Desktop/Ejemplo.txt");
            f.Write("digraph lista{ rankdir=TB;node [shape = box, style=rounded]; ");
            graph = "";
            Generar(raiz);
            f.Write(graph);
            f.Write("}");
            f.Close();

        }
        public void Generar(ParseTreeNode raiz)
        {
            graph = graph + "nodo" + raiz.GetHashCode() + "[label=\"" + raiz.ToString().Replace("\"", "\\\"") + " \", fillcolor=\"red\", style =\"filled\", shape=\"circle\"]; \n";
            if (raiz.ChildNodes.Count > 0)
            {
                ParseTreeNode[] hijos = raiz.ChildNodes.ToArray();
                for (int i = 0; i < raiz.ChildNodes.Count; i++)
                {
                    Generar(hijos[i]);
                    graph = graph + "\"nodo" + raiz.GetHashCode() + "\"-> \"nodo" + hijos[i].GetHashCode() + "\" \n";
                }
            }
        }


        private static void GenerateGraph(string fileName, string path)
        {
            try
            {
               var command = string.Format("dot -Tjpg {0} -o {1}", Path.Combine(path, fileName), Path.Combine(path, fileName.Replace(".txt", ".jpg")));
                //String command = "dot -Tjpg " + fileName + " -o " + fileName.Replace(".txt", ".jpg");
               var procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/C" + command);
                var proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
                proc.WaitForExit();
            }
            catch (Exception x)
            {

            }
        }
    }
}
