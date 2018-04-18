using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _OLC_Practica2.Ejecutar
{
    public class Aritmetica
    {
        public Aritmetica()
        {

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
                    //enviar como parametro la raiz al metodo ejecutar para obtener el valor de la funcion
                    break;
            }

            String operacion = raiz.ChildNodes[1].Token.Text;
            String tipo1;
            String tipo2;
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

            return null;

        }
    }
}