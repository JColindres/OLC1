using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using SingularSys.Jep;

namespace _OLC_Practica2.Ejecutar
{
    public class Programa
    {

        public static List<Metodo> metodos;
        public List<Clase> clases;
        public static List<Funcion> funciones;
        public static TablaSimbolo tablaGlobal;
        public static TablaSimbolo tablaLocal;
        public static Metodo met;
        public static Funcion func;
        public TextBox consola;
        public static Stack<String> pilaAmbito;
        String lista;
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
                            ejecutar(nodo.ChildNodes[2]);
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
                        Funcion f = new Funcion(tipo, nombre, ambito, null, nodo);
                        if (!existeFuncion(nombre))
                        {
                            funciones.Add(f);
                            ejecutar(nodo.ChildNodes[2]);
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
                                    Simbolo simbolo = new Simbolo(resultado.tipo, nombre, ambito, resultado.valor);
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
                            resultado = operar(nodo.ChildNodes[2]);
                            if (resultado == null)
                            {
                                consola.Text = consola.Text + "\n" + "El tipo de variable no coincide";
                            }
                            else
                            {
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
                        }
                        else
                        {
                            nombre = nodo.ChildNodes[0].Token.Text;
                            ambito = "global";
                            Boolean estado1 = tablaGlobal.existe(nombre);
                            if (estado1)
                            {
                                opA = new Aritmetica();
                                resultado = operar(nodo.ChildNodes[1]);
                                if (resultado == null)
                                {
                                    consola.Text = consola.Text + "\n" + "El tipo de variable no coincide";
                                }
                                else
                                {
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
            Resultado case1;
            Resultado case2;
            Resultado case3;
            Resultado case4;
            Resultado Otroresultado;
            foreach (ParseTreeNode nodo in raiz.ChildNodes)
            {
                tipoAccion = nodo.Term.Name;
                switch (tipoAccion)
                {
                    case "DECLARACION":
                        lista = "";
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
                                    Simbolo simbolo = new Simbolo(resultado.tipo, nombre, ambito, resultado.valor);
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
                            resultado = operar(nodo.ChildNodes[2]);
                            if (resultado == null)
                            {
                                consola.Text = consola.Text + "\n" + "El tipo de variable no coincide";
                            }
                            else
                            {
                                tipo = resultado.tipo;
                                ambito = "local";
                                Simbolo simbolo = new Simbolo(tipo, nombre, ambito, resultado.valor);
                                Boolean estado = tablaLocal.addSimbolo(simbolo);
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
                        }
                        else
                        {
                            nombre = nodo.ChildNodes[0].Token.Text;
                            ambito = "local";
                            Boolean estado1 = tablaLocal.existe(nombre);
                            if (estado1)
                            {
                                opA = new Aritmetica();
                                resultado = operar(nodo.ChildNodes[1]);
                                if (resultado == null)
                                {
                                    consola.Text = consola.Text + "\n" + "El tipo de variable no coincide";
                                }
                                else
                                {
                                    tablaLocal.removeSimbolo(nombre);
                                    Simbolo simbolo = new Simbolo(resultado.tipo, nombre, ambito, resultado.valor);
                                    Boolean estado = tablaLocal.addSimbolo(simbolo);
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
                    case "DECLA":
                        ambito = "local";
                        nombre = nodo.ChildNodes[1].Token.Text;
                        resultado = new Resultado(null, null);
                        resultado.valor = null;
                        resultado.tipo = null;
                        Simbolo sim = new Simbolo(resultado.tipo, nombre, ambito, resultado.valor);
                        Boolean est = tablaLocal.addSimbolo(sim);
                        if (!est)
                        {
                            consola.Text = consola.Text + "\n" + "La variable " + nombre + " ya existe.";
                        }
                        else
                        {
                            consola.Text = consola.Text + "\n" + "Se guardaro la variable " + nombre + ".";
                        }
                        break;
                    case "E":
                        opA = new Aritmetica();
                        resultado = operar(nodo.ChildNodes[0]);
                        TablaSimbolo auxE = tablaGlobal;
                        tablaGlobal = new TablaSimbolo();
                        tablaGlobal.cambiarAmbito(auxE);
                        if (resultado == null)
                        {
                            consola.Text = consola.Text + "\n" + "El tipo de variable no coincide";
                        }
                        tablaGlobal = auxE;
                        break;
                    case "SI":
                        opR = new Relacional();
                        resultado = opR.relacionar(nodo.ChildNodes[1]);
                        TablaSimbolo aux = tablaLocal;
                        //creo una nueva tabla para cambiar al ambito if
                        tablaLocal = new TablaSimbolo();
                        tablaLocal.cambiarAmbito(aux);
                        if (resultado == null)
                        {
                            consola.Text = consola.Text + "\n" + "El tipo de variable no coincide";
                        }
                        else
                        {
                            if (Boolean.Parse(resultado.valor + ""))
                            {
                                if (nodo.ChildNodes[2].ChildNodes[0].Term.Name == "SALIR")
                                {

                                }
                                else
                                {
                                    ejecutar(nodo.ChildNodes[2]);
                                }
                            }                            
                            else
                            {
                                ejecutar(nodo.ChildNodes[3]);
                            }
                        }
                        //regreso al ambito anterior
                        tablaLocal = aux;
                        break;
                    case "SINOSI":
                        if (nodo.ChildNodes[0].Token.Text == "SINO_SI")
                        {
                            opR = new Relacional();
                            resultado = opR.relacionar(nodo.ChildNodes[1]);
                            TablaSimbolo aux22 = tablaLocal;
                            //creo una nueva tabla para cambiar al ambito if
                            tablaLocal = new TablaSimbolo();
                            tablaLocal.cambiarAmbito(aux22);
                            if (resultado == null)
                            {
                                consola.Text = consola.Text + "\n" + "El tipo de variable no coincide";
                            }
                            else
                            {
                                if (Boolean.Parse(resultado.valor + ""))
                                {
                                    if (nodo.ChildNodes[2].ChildNodes[0].Term.Name == "SALIR")
                                    {

                                    }
                                    else
                                    {
                                        ejecutar(nodo.ChildNodes[2]);
                                    }
                                }
                            }
                            //regreso al ambito anterior
                            tablaLocal = aux22;
                        }
                        else
                        {
                            ejecutar(nodo.ChildNodes[1]);
                        }
                        break;
                    case "SINO":
                        ejecutar(nodo.ChildNodes[1]);
                        break;
                    case "MIENTRAS":
                        opR = new Relacional();
                        resultado = opR.relacionar(nodo.ChildNodes[1]);
                        TablaSimbolo aux2 = tablaLocal;
                        tablaLocal = new TablaSimbolo();
                        tablaLocal.cambiarAmbito(aux2);
                        if (resultado == null)
                        {
                            consola.Text = consola.Text + "\n" + "El tipo de variable no coincide";
                        }
                        else
                        {
                            while (Boolean.Parse(resultado.valor + ""))
                            {
                                if (nodo.ChildNodes[2].ChildNodes[0].Term.Name == "SALIR")
                                {
                                    
                                }
                                else
                                {
                                    opR = new Relacional();
                                    resultado = opR.relacionar(nodo.ChildNodes[1]);
                                    ejecutar(nodo.ChildNodes[2]);
                                    opR = new Relacional();
                                    resultado = opR.relacionar(nodo.ChildNodes[1]);
                                }
                            }
                        }
                        tablaLocal = aux2;
                        break;
                    case "INTERRUMPIR":
                        #region Switch
                        opA = new Aritmetica();
                        resultado = operar(nodo.ChildNodes[1]);
                        if (nodo.ChildNodes[2].ChildNodes.Count == 4) {
                            case1 = opA.operar(nodo.ChildNodes[2].ChildNodes[0].ChildNodes[1]);
                            string caso1 = case1.valor + "";
                            case2 = opA.operar(nodo.ChildNodes[2].ChildNodes[1].ChildNodes[1]);
                            string caso2 = case2.valor + "";
                            case3 = opA.operar(nodo.ChildNodes[2].ChildNodes[2].ChildNodes[1]);
                            string caso3 = case3.valor + "";
                            case4 = opA.operar(nodo.ChildNodes[2].ChildNodes[3].ChildNodes[1]);
                            string caso4 = case4.valor + "";
                            TablaSimbolo auxI = tablaLocal;
                            tablaLocal = new TablaSimbolo();
                            tablaLocal.cambiarAmbito(auxI);
                            if (resultado == null)
                            {
                                consola.Text = consola.Text + "\n" + "El tipo de variable no coincide";
                            }
                            else
                            {
                                if (resultado.valor + "" != null)
                                {
                                    if (caso1 != null && caso1 == resultado.valor + "")
                                    {
                                        if (nodo.ChildNodes[2].ChildNodes[0].ChildNodes[2].ChildNodes[0].Term.Name == "SALIR")
                                        {

                                        }
                                        else
                                        {
                                            ejecutar(nodo.ChildNodes[2].ChildNodes[0].ChildNodes[2]);
                                        }
                                    }
                                    else if (caso2 != null && caso2 == resultado.valor + "")
                                    {
                                        if (nodo.ChildNodes[2].ChildNodes[0].ChildNodes[2].ChildNodes[0].Term.Name == "SALIR")
                                        {

                                        }
                                        else
                                        {
                                            ejecutar(nodo.ChildNodes[2].ChildNodes[1].ChildNodes[2]);
                                        }
                                    }
                                    else if (caso3 != null && caso3 == resultado.valor + "")
                                    {
                                        if (nodo.ChildNodes[2].ChildNodes[0].ChildNodes[2].ChildNodes[0].Term.Name == "SALIR")
                                        {

                                        }
                                        else
                                        {
                                            ejecutar(nodo.ChildNodes[2].ChildNodes[2].ChildNodes[2]);
                                        }
                                    }
                                    else if (caso4 != null && caso4 == resultado.valor + "")
                                    {
                                        if (nodo.ChildNodes[2].ChildNodes[0].ChildNodes[2].ChildNodes[0].Term.Name == "SALIR")
                                        {

                                        }
                                        else
                                        {
                                            ejecutar(nodo.ChildNodes[2].ChildNodes[3].ChildNodes[2]);
                                        }
                                    }
                                    else if (nodo.ChildNodes[3].ChildNodes[0].Token.Text != null && nodo.ChildNodes[3].ChildNodes[0].Token.Text == "DEFECTO")
                                    {
                                        if (nodo.ChildNodes[3].ChildNodes[1].ChildNodes[0].Term.Name == "SALIR")
                                        {

                                        }
                                        else
                                        {
                                            ejecutar(nodo.ChildNodes[3].ChildNodes[1]);
                                        }
                                    }
                                }
                            }
                            tablaLocal = auxI;
                        }
                        else if(nodo.ChildNodes[2].ChildNodes.Count == 3) {
                            case1 = opA.operar(nodo.ChildNodes[2].ChildNodes[0].ChildNodes[1]);
                            string caso1 = case1.valor + "";
                            case2 = opA.operar(nodo.ChildNodes[2].ChildNodes[1].ChildNodes[1]);
                            string caso2 = case2.valor + "";
                            case3 = opA.operar(nodo.ChildNodes[2].ChildNodes[2].ChildNodes[1]);
                            string caso3 = case3.valor + "";
                            TablaSimbolo auxI = tablaLocal;
                            tablaLocal = new TablaSimbolo();
                            tablaLocal.cambiarAmbito(auxI);
                            if (resultado == null)
                            {
                                consola.Text = consola.Text + "\n" + "El tipo de variable no coincide";
                            }
                            else
                            {
                                if (resultado.valor + "" != null)
                                {
                                    if (caso1 != null && caso1 == resultado.valor + "")
                                    {
                                        if (nodo.ChildNodes[2].ChildNodes[0].ChildNodes[2].ChildNodes[0].Term.Name == "SALIR")
                                        {

                                        }
                                        else
                                        {
                                            ejecutar(nodo.ChildNodes[2].ChildNodes[0].ChildNodes[2]);
                                        }
                                    }
                                    else if (caso2 != null && caso2 == resultado.valor + "")
                                    {
                                        if (nodo.ChildNodes[2].ChildNodes[0].ChildNodes[2].ChildNodes[0].Term.Name == "SALIR")
                                        {

                                        }
                                        else
                                        {
                                            ejecutar(nodo.ChildNodes[2].ChildNodes[1].ChildNodes[2]);
                                        }
                                    }
                                    else if (caso3 != null && caso3 == resultado.valor + "")
                                    {
                                        if (nodo.ChildNodes[2].ChildNodes[0].ChildNodes[2].ChildNodes[0].Term.Name == "SALIR")
                                        {

                                        }
                                        else
                                        {
                                            ejecutar(nodo.ChildNodes[2].ChildNodes[2].ChildNodes[2]);
                                        }
                                    }
                                    else if (nodo.ChildNodes[3].ChildNodes[0].Token.Text != null && nodo.ChildNodes[3].ChildNodes[0].Token.Text == "DEFECTO")
                                    {
                                        if (nodo.ChildNodes[3].ChildNodes[1].ChildNodes[0].Term.Name == "SALIR")
                                        {

                                        }
                                        else
                                        {
                                            ejecutar(nodo.ChildNodes[3].ChildNodes[1]);
                                        }
                                    }
                                }
                            }
                            tablaLocal = auxI;
                        }
                        else if (nodo.ChildNodes[2].ChildNodes.Count == 2)
                        {
                            case1 = opA.operar(nodo.ChildNodes[2].ChildNodes[0].ChildNodes[1]);
                            string caso1 = case1.valor + "";
                            case2 = opA.operar(nodo.ChildNodes[2].ChildNodes[1].ChildNodes[1]);
                            string caso2 = case2.valor + "";
                            TablaSimbolo auxI = tablaLocal;
                            tablaLocal = new TablaSimbolo();
                            tablaLocal.cambiarAmbito(auxI);
                            if (resultado == null)
                            {
                                consola.Text = consola.Text + "\n" + "El tipo de variable no coincide";
                            }
                            else
                            {
                                if (resultado.valor + "" != null)
                                {
                                    if (caso1 != null && caso1 == resultado.valor + "")
                                    {
                                        if (nodo.ChildNodes[2].ChildNodes[0].ChildNodes[2].ChildNodes[0].Term.Name == "SALIR")
                                        {

                                        }
                                        else
                                        {
                                            ejecutar(nodo.ChildNodes[2].ChildNodes[0].ChildNodes[2]);
                                        }
                                    }
                                    else if (caso2 != null && caso2 == resultado.valor + "")
                                    {
                                        if (nodo.ChildNodes[2].ChildNodes[0].ChildNodes[2].ChildNodes[0].Term.Name == "SALIR")
                                        {

                                        }
                                        else
                                        {
                                            ejecutar(nodo.ChildNodes[2].ChildNodes[1].ChildNodes[2]);
                                        }
                                    }
                                    else if (nodo.ChildNodes[3].ChildNodes[0].Token.Text != null && nodo.ChildNodes[3].ChildNodes[0].Token.Text == "DEFECTO")
                                    {
                                        if (nodo.ChildNodes[3].ChildNodes[1].ChildNodes[0].Term.Name == "SALIR")
                                        {

                                        }
                                        else
                                        {
                                            ejecutar(nodo.ChildNodes[3].ChildNodes[1]);
                                        }
                                    }
                                }
                            }
                            tablaLocal = auxI;
                        }
                        else if (nodo.ChildNodes[2].ChildNodes.Count == 1)
                        {
                            case1 = opA.operar(nodo.ChildNodes[2].ChildNodes[0].ChildNodes[1]);
                            string caso1 = case1.valor + "";
                            TablaSimbolo auxI = tablaLocal;
                            tablaLocal = new TablaSimbolo();
                            tablaLocal.cambiarAmbito(auxI);
                            if (resultado == null)
                            {
                                consola.Text = consola.Text + "\n" + "El tipo de variable no coincide";
                            }
                            else
                            {
                                if (resultado.valor + "" != null)
                                {
                                    if (caso1 != null && caso1 == resultado.valor + "")
                                    {
                                        if (nodo.ChildNodes[2].ChildNodes[0].ChildNodes[2].ChildNodes[0].Term.Name == "SALIR")
                                        {

                                        }
                                        else
                                        {
                                            ejecutar(nodo.ChildNodes[2].ChildNodes[0].ChildNodes[2]);
                                        }
                                    }
                                    else if (nodo.ChildNodes[3].ChildNodes[0].Token.Text != null && nodo.ChildNodes[3].ChildNodes[0].Token.Text == "DEFECTO")
                                    {
                                        if (nodo.ChildNodes[3].ChildNodes[1].ChildNodes[0].Term.Name == "SALIR")
                                        {

                                        }
                                        else
                                        {
                                            ejecutar(nodo.ChildNodes[3].ChildNodes[1]);
                                        }
                                    }
                                }
                            }
                            tablaLocal = auxI;
                        }
                        #endregion
                        break;
                    case "HACER":
                        opR = new Relacional();
                        resultado = opR.relacionar(nodo.ChildNodes[3]);
                        TablaSimbolo aux24 = tablaLocal;
                        tablaLocal = new TablaSimbolo();
                        tablaLocal.cambiarAmbito(aux24);
                        if (resultado == null)
                        {
                            consola.Text = consola.Text + "\n" + "El tipo de variable no coincide";
                        }
                        else
                        {
                            do
                            {
                                if (nodo.ChildNodes[1].ChildNodes[0].Term.Name == "SALIR")
                                {

                                }
                                else
                                {
                                    opR = new Relacional();
                                    resultado = opR.relacionar(nodo.ChildNodes[3]);
                                    ejecutar(nodo.ChildNodes[1]);
                                    opR = new Relacional();
                                    resultado = opR.relacionar(nodo.ChildNodes[3]);
                                }
                            } while (Boolean.Parse(resultado.valor + ""));
                        }
                        tablaLocal = aux24;
                        break;
                    case "IMP":
                        opA = new Aritmetica();
                        resultado = operar(nodo.ChildNodes[1]);
                        if (resultado == null)
                        {
                            consola.Text = consola.Text + "\n" + "La variable no existe";
                        }
                        else
                        {
                            consola.Text = consola.Text + "\n" + resultado.valor;
                        }
                        break;
                    case "RAIZ":
                        opA = new Aritmetica();
                        resultado = operar(nodo.ChildNodes[1]);
                        Otroresultado = operar(nodo.ChildNodes[2]);
                        if (resultado == null && Otroresultado == null)
                        {
                            consola.Text = consola.Text + "\n" + "La variable no existe";
                        }
                        else
                        {
                            Double ra = Math.Pow(Double.Parse(resultado.valor + ""), 1 / Double.Parse(Otroresultado.valor + ""));
                            consola.Text = consola.Text + "\n" + ra;
                        }
                        break;
                    case "LLAMFUNC":
                        met = buscarMetodo(nodo.ChildNodes[0].ChildNodes[0].Token.Text);
                        func = buscarFuncion(nodo.ChildNodes[0].ChildNodes[0].Token.Text);
                        if (met != null)
                        {
                            tablaLocal = new TablaSimbolo();
                            pilaAmbito.Push(nodo.ChildNodes[0].ChildNodes[0].Token.Text);
                            ejecutar(met.raiz.ChildNodes[3]);
                            pilaAmbito.Pop();
                        }
                        else if (func != null)
                        {
                            tablaLocal = new TablaSimbolo();
                            pilaAmbito.Push(nodo.ChildNodes[0].ChildNodes[0].Token.Text);
                            ejecutar(func.raiz.ChildNodes[3]);
                            resultado = ejecutar(func.raiz.ChildNodes[4]);
                            pilaAmbito.Pop();
                            if (resultado != null)
                            {
                                consola.Text = consola.Text + "\n" + "Se retorna: " + resultado.valor;
                                return resultado;
                            }
                            else
                            {
                                consola.Text = consola.Text + "\n" + "error del retorno";
                            }
                        }
                        else
                        {
                            consola.Text = consola.Text + "\n" + "No existe el metodo o funcion a llamar";
                        }
                        break;
                    case "LLAMADA":
                        met = buscarMetodo(nodo.ChildNodes[0].ChildNodes[0].Token.Text);
                        func = buscarFuncion(nodo.ChildNodes[0].ChildNodes[0].Token.Text);
                        if (met != null)
                        {
                            tablaLocal = new TablaSimbolo();
                            pilaAmbito.Push(nodo.ChildNodes[0].ChildNodes[0].Token.Text);
                            ejecutar(met.raiz.ChildNodes[3]);
                            pilaAmbito.Pop();
                        }
                        else if (func != null)
                        {
                            tablaLocal = new TablaSimbolo();
                            pilaAmbito.Push(nodo.ChildNodes[0].ChildNodes[0].Token.Text);
                            ejecutar(func.raiz.ChildNodes[3]);
                            resultado = ejecutar(func.raiz.ChildNodes[4]);
                            pilaAmbito.Pop();
                            consola.Text = consola.Text + "\n" + "Se retorna: " + resultado.valor;
                            return resultado;
                        }
                        else
                        {
                            consola.Text = consola.Text + "\n" + "No existe el metodo o funcion a llamar";
                        }
                        break;
                    case "SALIR":
                        break;
                    case "RETORNO":
                        func = new Funcion(null, null, null, null, null);
                        opA = new Aritmetica();
                        resultado = opA.operar(nodo.ChildNodes[1]);
                        if (resultado == null)
                        {
                            consola.Text = consola.Text + "\n" + "Retorno no valido";
                            return resultado;
                        }
                        else
                        {
                            consola.Text = consola.Text + "\n" + "Se retorna: " + resultado.valor;
                            func.retorno = resultado.valor;
                            return resultado;
                        }
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

        public static Metodo buscarMetodo(String nombre)
        {
            foreach (Metodo m in metodos)
            {
                if (m.nombre == nombre)
                {
                    return m;
                }

            }

            return null;
        }

        public static Funcion buscarFuncion(String nombre)
        {
            foreach (Funcion f in funciones)
            {
                if (f.nombre == nombre)
                {
                    return f;
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

        public Resultado operar(ParseTreeNode raiz)
        {
            Resultado resultado1 = null;
            Resultado resultado2 = null;

            switch (raiz.Term.Name)
            {
                case "E":
                    if (raiz.ChildNodes.Count == 3)
                    {
                        resultado1 = operar(raiz.ChildNodes[0]);
                        resultado2 = operar(raiz.ChildNodes[2]);
                    }
                    else
                    {
                        return operar(raiz.ChildNodes[0]);
                    }
                    break;
                case "doble":
                    return new Resultado("doble", raiz.Token.Text);
                case "cadena":
                    String cadena = raiz.Token.Text.Replace("\"", "");
                    return new Resultado("cadena", cadena);
                case "booleano":
                    return new Resultado("booleano", raiz.Token.Text);
                case "id":
                    String iden = raiz.Token.Text.Replace("\"", "");
                    if (Programa.tablaGlobal.getSimbolo(iden) != null)
                    {
                        return new Resultado(Programa.tablaGlobal.getSimbolo(iden).tipo, Programa.tablaGlobal.getSimbolo(iden).valor);
                    }
                    else if (Programa.tablaLocal.getSimbolo(iden) != null)
                    {
                        return new Resultado(Programa.tablaLocal.getSimbolo(iden).tipo, Programa.tablaLocal.getSimbolo(iden).valor);
                    }
                    else
                    {
                        return null;
                    }
                case "LLAMADA":
                    func = buscarFuncion(raiz.ChildNodes[0].Token.Text);
                    if (func != null)
                    {
                        tablaLocal = new TablaSimbolo();
                        pilaAmbito.Push(raiz.ChildNodes[0].Token.Text);
                        ejecutar(func.raiz.ChildNodes[3]);
                        resultado1 = ejecutar(func.raiz.ChildNodes[4]);
                        pilaAmbito.Pop();
                        return resultado1;
                    }
                    else
                    {

                    }
                    break;
                case "-":
                    break;
            }

            String operacion = raiz.ChildNodes[1].Token.Text;
            String tipo1;
            String tipo2;
            if (resultado1 != null && resultado2 != null)
            {
                switch (operacion)
                {
                    case "+":
                        tipo1 = resultado1.tipo;
                        switch (tipo1)
                        {
                            case "doble":
                                tipo2 = resultado2.tipo;
                                switch (tipo2)
                                {
                                    case "doble":
                                        return new Resultado("doble", Double.Parse(resultado1.valor + "") + Double.Parse(resultado2.valor + ""));

                                    case "cadena":
                                        return new Resultado("cadena", Double.Parse(resultado1.valor + "") + (String)resultado2.valor);

                                    case "booleano":
                                        return new Resultado("cadena", Double.Parse(resultado1.valor + "") + resultado2.valor.ToString());

                                }
                                break;
                            case "cadena":
                                tipo2 = resultado2.tipo;
                                switch (tipo2)
                                {
                                    case "doble":
                                        return new Resultado("cadena", (String)resultado1.valor + Double.Parse(resultado2.valor + ""));

                                    case "cadena":
                                        return new Resultado("cadena", (String)resultado1.valor + (String)resultado2.valor);

                                    case "booleano":
                                        return new Resultado("cadena", (String)resultado1.valor + resultado2.valor.ToString());

                                }
                                break;
                            case "booleano":
                                tipo2 = resultado2.tipo;
                                switch (tipo2)
                                {
                                    case "doble":
                                        return new Resultado("cadena", resultado1.valor.ToString() + Double.Parse(resultado2.valor + ""));

                                    case "cadena":
                                        return new Resultado("cadena", resultado1.valor.ToString() + (String)resultado2.valor);

                                    case "booleano":
                                        return new Resultado("cadena", resultado2.valor.ToString() + resultado2.valor.ToString());

                                }
                                break;
                        }

                        break;
                    case "*":
                        tipo1 = resultado1.tipo;
                        switch (tipo1)
                        {
                            case "doble":
                                tipo2 = resultado2.tipo;
                                switch (tipo2)
                                {
                                    case "doble":
                                        return new Resultado("doble", Double.Parse(resultado1.valor + "") * Double.Parse(resultado2.valor + ""));

                                    case "cadena":
                                        //reportar error semantico, linea y columna
                                        break;
                                }
                                break;
                            case "cadena":
                                tipo2 = resultado2.tipo;
                                switch (tipo2)
                                {
                                    case "doble":
                                        //reportar error semantico,linea y columna
                                        break;
                                    case "cadena":
                                        //Reportar error semantoco, linea y columna
                                        break;
                                }
                                break;

                        }
                        break;
                    case "/":
                        tipo1 = resultado1.tipo;
                        switch (tipo1)
                        {
                            case "doble":
                                tipo2 = resultado2.tipo;
                                switch (tipo2)
                                {
                                    case "doble":
                                        return new Resultado("doble", Double.Parse(resultado1.valor + "") / Double.Parse(resultado2.valor + ""));

                                    case "cadena":
                                        //reportar error semantico, linea y columna
                                        break;
                                }
                                break;
                            case "cadena":
                                tipo2 = resultado2.tipo;
                                switch (tipo2)
                                {
                                    case "doble":
                                        //reportar error semantico,linea y columna
                                        break;
                                    case "cadena":
                                        //Reportar error semantoco, linea y columna
                                        break;
                                }
                                break;

                        }
                        break;
                    case "-":
                        tipo1 = resultado1.tipo;
                        switch (tipo1)
                        {
                            case "doble":
                                tipo2 = resultado2.tipo;
                                switch (tipo2)
                                {
                                    case "doble":
                                        return new Resultado("doble", Double.Parse(resultado1.valor + "") - Double.Parse(resultado2.valor + ""));

                                    case "cadena":
                                        //reportar error semantico, linea y columna
                                        break;
                                }
                                break;
                            case "cadena":
                                tipo2 = resultado2.tipo;
                                switch (tipo2)
                                {
                                    case "doble":
                                        //reportar error semantico,linea y columna
                                        break;
                                    case "cadena":
                                        //Reportar error semantoco, linea y columna
                                        break;
                                }
                                break;

                        }
                        break;
                    case "^":
                        tipo1 = resultado1.tipo;
                        switch (tipo1)
                        {
                            case "doble":
                                tipo2 = resultado2.tipo;
                                switch (tipo2)
                                {
                                    case "doble":
                                        return new Resultado("doble", Math.Pow(Double.Parse(resultado1.valor + ""), Double.Parse(resultado2.valor + "")));

                                    case "cadena":
                                        //reportar error semantico, linea y columna
                                        break;
                                }
                                break;
                            case "cadena":
                                tipo2 = resultado2.tipo;
                                switch (tipo2)
                                {
                                    case "doble":
                                        //reportar error semantico,linea y columna
                                        break;
                                    case "cadena":
                                        //Reportar error semantoco, linea y columna
                                        break;
                                }
                                break;

                        }
                        break;
                    case "id":
                        String iden = raiz.Token.Text.Replace("\"", "");
                        if (Programa.tablaGlobal.getSimbolo(iden) != null)
                        {
                            return new Resultado(Programa.tablaGlobal.getSimbolo(iden).tipo, Programa.tablaGlobal.getSimbolo(iden).valor);
                        }
                        else if (Programa.tablaLocal.getSimbolo(iden) != null)
                        {
                            return new Resultado(Programa.tablaLocal.getSimbolo(iden).tipo, Programa.tablaLocal.getSimbolo(iden).valor);
                        }
                        else
                        {
                            return null;
                        }
                    case "LLAMADAMETODO":
                        break;
                    case "doble":
                        return new Resultado("doble", raiz.Token.Text);
                    case "cadena":
                        return new Resultado("cadena", raiz.Token.Text);

                }
            }

            return null;

        }
    }
}