using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace _OLC_Practica2.Ejecutar
{
    public class Programa
    {

        public List<Metodo> metodos;
        public List<Clase> clases;
        public List<Funcion> funciones;
        public static TablaSimbolo tablaGlobal;
        public static TablaSimbolo tablaLocal;
        public TextBox consola;
        public Stack<String> pilaAmbito;
        String lista;


        //operaciones arimeticas, relacionales y logicas
        Aritmetica opA;
        Relacional opR;

        public Programa(TextBox consola, ParseTreeNode raiz)
        {
            this.consola = consola;
            metodos = new List<Metodo>();
            clases = new List<Clase>();
            funciones = new List<Funcion>();
            tablaGlobal = new TablaSimbolo();
            pilaAmbito = new Stack<string>();
            primeraEjecucion(raiz);
            Clase programa = buscarPrograma();
            pilaAmbito.Push("programa");
            segundaEjecucion(programa.raiz.ChildNodes[2]);
            pilaAmbito.Pop();
            Metodo principal = buscarPrincipal();
            if (principal != null)
            {
                tablaLocal = new TablaSimbolo();
                pilaAmbito.Push("principal");
                ejecutar(principal.raiz.ChildNodes[1]);
                pilaAmbito.Pop();
            }
            else
            {
                consola.Text = consola.Text + "\n" + "No hay metodo principal";
            }
        }

        //aqui es donde se guardan los metodos y variables globales
        public void primeraEjecucion(ParseTreeNode raiz)
        {
            String tipoAccion = "";
            String tipo;
            String nombre;
            String ambito;
            foreach (ParseTreeNode nodo in raiz.ChildNodes)
            {
                tipoAccion = nodo.Term.Name;
                switch (tipoAccion)
                {
                    case "PROGRAMA":
                        tipo = nodo.ChildNodes[0].Token.Text;
                        nombre = nodo.ChildNodes[1].Token.Text;
                        ambito = "global";

                        Clase C = new Clase(tipo, nombre, ambito, nodo);
                        clases.Add(C);
                        break;
                }
            }
        }

        public void segundaEjecucion(ParseTreeNode raiz)
        {
            String tipoAccion = "";
            String tipo;
            String nombre;
            String ambito;
            Array listaID;
            Resultado resultado;
            foreach (ParseTreeNode nodo in raiz.ChildNodes)
            {
                tipoAccion = nodo.Term.Name;
                switch (tipoAccion)
                {
                    case "METODO":
                        tipo = nodo.ChildNodes[0].Token.Text;
                        nombre = nodo.ChildNodes[1].Token.Text;
                        ambito = "global";

                        Metodo m = new Metodo(tipo, nombre, ambito, nodo);
                        if (!existeMetodo(nombre))
                        {
                            metodos.Add(m);
                        }
                        else
                        {
                            consola.Text = consola.Text + "\n" + "El metodo " + nombre + " ya existe";
                        }

                        break;
                    case "FUNCION":
                        tipo = nodo.ChildNodes[0].Token.Text;
                        nombre = nodo.ChildNodes[1].Token.Text;
                        ambito = "global";

                        Funcion f = new Funcion(tipo, nombre, ambito, nodo);
                        if (!existeFuncion(nombre))
                        {
                            funciones.Add(f);
                        }
                        else
                        {
                            consola.Text = consola.Text + "\n" + "La funcion " + nombre + " ya existe";
                        }

                        break;
                    case "PRINCIPAL":
                        tipo = "void";
                        nombre = nodo.ChildNodes[0].Token.Text;
                        ambito = "global";

                        Metodo prin = new Metodo(tipo, nombre, ambito, nodo);
                        if (!existeMetodo(nombre))
                        {
                            metodos.Add(prin);
                        }
                        else
                        {
                            consola.Text = consola.Text + "\n" + "El metodo " + nombre + " ya existe";
                        }

                        break;
                    case "DECLARACION":
                        lista = "";
                        tipo = nodo.ChildNodes[0].Token.Text;
                        segundaEjecucion(nodo.ChildNodes[1]);
                        ambito = "global";
                        resultado = new Resultado(null, null);
                        resultado.valor = null;
                        listaID = lista.Split(',');
                        foreach (string item in listaID)
                        {
                            try
                            {
                                if (item.ToString() != "")
                                {
                                    nombre = item.ToString();
                                    Simbolo simbolo = new Simbolo(tipo, nombre, ambito, resultado.valor);
                                    Boolean estado = tablaGlobal.addSimbolo(simbolo);
                                    if (!estado)
                                    {
                                        consola.Text = consola.Text + "\n" + "La variable " + nombre + " ya existe.";
                                        //se debe incluir el tipo de error, linea y columna
                                    }
                                    else
                                    {
                                        consola.Text = consola.Text + "\n" + "Se guardaro la variable " + nombre + ".";
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                            catch (Exception e) { consola.Text = consola.Text + "\n" + e; }                         
                        }
                        break;
                    case "ASIGNACION":
                        if (nodo.ChildNodes[0].Token.Text == "var")
                        {
                            nombre = nodo.ChildNodes[1].Token.Text;
                            opA = new Aritmetica();
                            resultado = opA.operar(nodo.ChildNodes[2]);
                            tipo = resultado.tipo;
                            ambito = "global";
                            Simbolo simbolo = new Simbolo(tipo, nombre, ambito, resultado.valor);
                            Boolean estado = tablaGlobal.addSimbolo(simbolo);
                            if (!estado)
                            {
                                consola.Text = consola.Text + "\n" + "La variable " + nombre + " ya existe.";
                                //se debe incluir el tipo de error, linea y columna
                            }
                            else
                            {
                                consola.Text = consola.Text + "\n" + "Se guardo la variable " + nombre + " = " + resultado.valor + ".";
                            }
                        }
                        else
                        {
                            nombre = nodo.ChildNodes[0].Token.Text;
                            ambito = "global";
                            Boolean estado1 = tablaGlobal.existe(nombre);
                            if (estado1)
                            {
                                opA = new Aritmetica();
                                resultado = opA.operar(nodo.ChildNodes[1]);
                                tablaGlobal.removeSimbolo(nombre);
                                Simbolo simbolo = new Simbolo(resultado.tipo, nombre, ambito, resultado.valor);
                                Boolean estado = tablaGlobal.addSimbolo(simbolo);
                                if (!estado)
                                {
                                    consola.Text = consola.Text + "\n" + "La variable " + nombre + " no existe.";
                                    //se debe incluir el tipo de error, linea y columna
                                }
                                else
                                {
                                    consola.Text = consola.Text + "\n" + "Se actualizo la variable " + nombre + " = " + resultado.valor + ".";
                                }
                            }
                            else
                            {
                                consola.Text = consola.Text + "\n" + "La variable " + nombre + " no existe.";
                            }
                        }
                        break;
                    case "id":
                        lista = lista + nodo.Token.Text.Replace("\"", "") + ",";
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
            Array listaID;
            Resultado resultado;
            Resultado Otroresultado;
            foreach (ParseTreeNode nodo in raiz.ChildNodes)
            {
                tipoAccion = nodo.Term.Name;
                switch (tipoAccion)
                {
                    case "DECLARACION":
                        lista = "";
                        tipo = nodo.ChildNodes[0].Token.Text;
                        ejecutar(nodo.ChildNodes[1]);
                        ambito = "local";
                        resultado = new Resultado(null, null);
                        resultado.valor = null;
                        listaID = lista.Split(',');
                        foreach (string item in listaID)
                        {
                            try
                            {
                                if (item.ToString() != "")
                                {
                                    nombre = item.ToString();
                                    Simbolo simbolo = new Simbolo(tipo, nombre, ambito, resultado.valor);
                                    Boolean estado = tablaLocal.addSimbolo(simbolo);
                                    if (!estado)
                                    {
                                        consola.Text = consola.Text + "\n" + "La variable " + nombre + " ya existe.";
                                        //se debe incluir el tipo de error, linea y columna
                                    }
                                    else
                                    {
                                        consola.Text = consola.Text + "\n" + "Se guardaro la variable " + nombre + ".";
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                            catch (Exception e) { consola.Text = consola.Text + "\n" + e; }
                        }
                        break;
                    case "ASIGNACION":
                        if (nodo.ChildNodes[0].Token.Text == "var")
                        {
                            nombre = nodo.ChildNodes[1].Token.Text;
                            opA = new Aritmetica();
                            resultado = opA.operar(nodo.ChildNodes[2]);
                            tipo = resultado.tipo;
                            ambito = "local";
                            Simbolo simbolo = new Simbolo(tipo, nombre, ambito, resultado.valor);
                            Boolean estado = tablaGlobal.addSimbolo(simbolo);
                            if (!estado)
                            {
                                consola.Text = consola.Text + "\n" + "La variable " + nombre + " ya existe.";
                                //se debe incluir el tipo de error, linea y columna
                            }
                            else
                            {
                                consola.Text = consola.Text + "\n" + "Se guardo la variable " + nombre + " = " + resultado.valor + ".";
                            }
                        }
                        else
                        {
                            nombre = nodo.ChildNodes[0].Token.Text;
                            ambito = "local";
                            Boolean estado1 = tablaGlobal.existe(nombre);
                            if (estado1)
                            {
                                opA = new Aritmetica();
                                resultado = opA.operar(nodo.ChildNodes[1]);
                                tablaGlobal.removeSimbolo(nombre);
                                Simbolo simbolo = new Simbolo(resultado.tipo, nombre, ambito, resultado.valor);
                                Boolean estado = tablaGlobal.addSimbolo(simbolo);
                                if (!estado)
                                {
                                    consola.Text = consola.Text + "\n" + "La variable " + nombre + " no existe.";
                                    //se debe incluir el tipo de error, linea y columna
                                }
                                else
                                {
                                    consola.Text = consola.Text + "\n" + "Se actualizo la variable " + nombre + " = " + resultado.valor + ".";
                                }
                            }
                            else
                            {
                                consola.Text = consola.Text + "\n" + "La variable " + nombre + " no existe.";
                            }
                        }
                        break;
                    case "id":
                        lista = lista + nodo.Token.Text.Replace("\"", "") + ",";
                        break;
                    case "IF":
                        opR = new Relacional();
                        resultado = opR.relacionar(nodo.ChildNodes[0]);
                        TablaSimbolo aux = tablaLocal;
                        //creo una nueva tabla para cambiar al ambito if
                        tablaLocal = new TablaSimbolo();
                        tablaLocal.cambiarAmbito(aux);
                        if (Boolean.Parse(resultado.valor + ""))
                        {

                            ejecutar(nodo.ChildNodes[1]);



                        }
                        else
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
                    case "IMP":
                        opA = new Aritmetica();
                        resultado = opA.operar(nodo.ChildNodes[1]);
                        consola.Text = consola.Text + "\n" + resultado.valor;
                        break;
                    case "RAIZ":
                        opA = new Aritmetica();
                        resultado = opA.operar(nodo.ChildNodes[1]);
                        Otroresultado = opA.operar(nodo.ChildNodes[2]);
                        Double ra = Math.Pow(Double.Parse(resultado.valor + ""), 1 / Double.Parse(Otroresultado.valor + ""));
                        consola.Text = consola.Text + "\n" + ra;
                        break;
                }
            }
            return null;
        }

        public Clase buscarPrograma()
        {
            foreach (Clase c in clases)
            {
                if (c.tipo == "programa")
                {
                    return c;
                }

            }

            return null;
        }

        public Metodo buscarPrincipal()
        {
            foreach (Metodo m in metodos)
            {
                if (m.nombre == "principal")
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
                if (nombre == m.nombre)
                {
                    return true;
                }
            }

            return false;

        }

        public Boolean existeFuncion(String nombre)
        {
            foreach (Funcion f in funciones)
            {
                if (nombre == f.nombre)
                {
                    return true;
                }
            }

            return false;

        }
        
    }
}