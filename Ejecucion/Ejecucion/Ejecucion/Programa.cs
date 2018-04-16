using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using WINGRAPHVIZLib;

namespace Ejecucion.Ejecucion
{
    public class Programa
    {
        public static String graph = "";
        public static String grafo = "";
        public static String ruta = "C:/Users/pablo/Desktop/";
        public List<Metodo> metodos;
        public TablaSimbolo tablaGlobal;
        public TablaSimbolo tablaLocal;
        public TextBox consola;
        public Stack<String> pilaAmbito;


        //operaciones arimeticas, relacionales y logicas
        Aritmetica opA;
        Relacional opR;
        public Programa(TextBox consola,ParseTreeNode raiz)
        {
            this.consola = consola;
            metodos = new List<Metodo>();
            tablaGlobal = new TablaSimbolo();
            pilaAmbito = new Stack<string>();
            primeraEjecucion(raiz);
            Metodo principal = buscarPrincipal();
            tablaLocal = new TablaSimbolo();
            pilaAmbito.Push("principal");
            ejecutar(principal.raiz.ChildNodes[2]);
            pilaAmbito.Pop();
        }

        //aqui es donde se guardan los metodos y variables globales
        public void primeraEjecucion(ParseTreeNode raiz)
        {
            String tipoAccion = "";
            String tipo;
            String nombre;
            String ambito;
            Resultado resultado;
            foreach (ParseTreeNode nodo in raiz.ChildNodes){
                tipoAccion = nodo.Term.Name;
                switch (tipoAccion)
                {
                    case "METODO":
                        tipo = nodo.ChildNodes[0].Token.Text;
                        nombre = nodo.ChildNodes[1].Token.Text;
                        ambito = "global";
                        
                        Metodo m = new Metodo(tipo,nombre,ambito,nodo);
                        if (!existeMetodo(nombre))
                        {
                            metodos.Add(m);
                        }else
                        {
                            consola.Text = consola.Text + "\n" + "El metodo "+nombre+" ya existe";
                        }
                        
                        break;
                    case "DECLARACION":
                        tipo = nodo.ChildNodes[0].Token.Text;
                        nombre = nodo.ChildNodes[1].Token.Text;
                        opA = new Aritmetica();
                        resultado = opA.operar(nodo.ChildNodes[2]);
                        ambito = "global";
                        //antes de agregar el simbolo a la tabla se debe coparar si
                        //el tipo de la variable es igual al tipo del valor
                        //Si los tipos no son iguales se debe hacer un casteo implicito si aplica
                        Simbolo simbolo = new Simbolo(tipo,nombre,ambito,resultado.valor);
                        Boolean estado = tablaGlobal.addSimbolo(simbolo);
                        if (!estado)
                        {
                            consola.Text = consola.Text + "\n" + "La variable " + nombre + " ya existe.";
                            //se debe incluir el tipo de error, linea y columna
                        }
                        break;
                }
            }
        }

        public Resultado ejecutar(ParseTreeNode raiz)
        {
            String tipoAccion = "";
            String tipo;
            String nombre;
            String ambito;
            Resultado resultado;
            foreach (ParseTreeNode nodo in raiz.ChildNodes)
            {
                tipoAccion = nodo.Term.Name;
                switch (tipoAccion)
                {
                    case "LLAMADAMETODO":
                        

                        break;
                    case "DECLARACION":
                        tipo = nodo.ChildNodes[0].Token.Text;
                        nombre = nodo.ChildNodes[1].Token.Text;
                        resultado = null;
                        ambito = "global";
                        Simbolo simbolo = new Simbolo(tipo, nombre, ambito, resultado.valor);
                        Boolean estado = tablaLocal.addSimbolo(simbolo);
                        //antes de agregar el simbolo a la tabla se debe coparar si
                        //el tipo de la variable es igual al tipo del valor
                        //Si los tipos no son iguales se debe hacer un casteo implicito si aplica
                        if (!estado)
                        {
                            consola.Text = consola.Text + "\n" + "La variable " + nombre + " ya existe.";
                            //se debe incluir el tipo de error, linea y columna
                        }
                        break;
                    case "IF":
                        opR = new Relacional();
                        resultado = opR.relacionar(nodo.ChildNodes[0]);
                        TablaSimbolo aux = tablaLocal;
                        //creo una nueva tabla para cambiar al ambito if
                        tablaLocal = new TablaSimbolo();
                        tablaLocal.cambiarAmbito(aux);
                        if (Boolean.Parse(resultado.valor+""))
                        {
                            
                            ejecutar(nodo.ChildNodes[1]);
                            
                            

                        }else
                        {
                            //ejecutar sentencias else
                        }
                        //regreso al ambito anterior
                        tablaLocal = aux;
                        break;
                    case "WHILE":
                        /*esta sentencias while ya esta completo, solo que no para porque no hay 
                         forma de comparar un valor puntual con un ID
                         
                       */
                        opR = new Relacional();
                        resultado = opR.relacionar(nodo.ChildNodes[0]);
                        TablaSimbolo aux2 = tablaLocal;
                        //creo una nueva tabla para cambiar al ambito if
                        tablaLocal = new TablaSimbolo();
                        tablaLocal.cambiarAmbito(aux2);
                        while (Boolean.Parse(resultado.valor + ""))
                        {
                            
                            ejecutar(nodo.ChildNodes[1]);
                            opR = new Relacional();
                            resultado = opR.relacionar(nodo.ChildNodes[0]);


                        }
                        tablaLocal = aux2;
                        break;
                    case "IMPRIMIR":
                        opA = new Aritmetica();
                        resultado = opA.operar(nodo.ChildNodes[0]);
                        consola.Text = consola.Text + "\n" + resultado.valor;
                        break;
                }
            }
                return null;
        }


        public Metodo buscarPrincipal()
        {
            foreach (Metodo m in metodos)
            {
                if (m.nombre=="principal")
                {
                    return m;
                }

            }

            return null;
        }
        public Boolean existeMetodo(String nombre)
        {
            foreach (Metodo m in metodos)
            {
                if (nombre==m.nombre)
                {
                    return true;
                }
            }

            return false;

        }


        public static String Genarbol(ParseTreeNode raiz)
        {
            System.IO.StreamWriter f = new System.IO.StreamWriter(ruta+"Ejemplo.txt");
            f.Write("digraph lista{ rankdir=TB;node [shape = box, style=rounded]; ");
            grafo = "digraph lista{ rankdir=TB;node [shape = box, style=rounded]; ";
            Generar(raiz);
            grafo += graph + "}";
            f.Write(graph);
            f.Write("}");
            f.Close();
            return grafo;

        }
        public static void Generar(ParseTreeNode raiz)
        {
            graph = graph + "nodo" + raiz.GetHashCode() + "[label=\"" + raiz.ToString().Replace("\"", "\\\"") + " \", fillcolor=\"yellow\", style =\"filled\", shape=\"circle\"]; \n";
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


        public  void generateGraph(string fileName)
        {
            try
            {
                var command = string.Format("dot -Tjpg {0} -o {1}", Path.Combine(ruta, fileName), Path.Combine(ruta, fileName.Replace(".txt", ".png")));
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