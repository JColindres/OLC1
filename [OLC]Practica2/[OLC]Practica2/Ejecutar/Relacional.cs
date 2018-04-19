using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _OLC_Practica2.Ejecutar
{
    public class Relacional
    {
        private Aritmetica opA;
        public Relacional()
        {

        }

        public Resultado relacionar(ParseTreeNode raiz)
        {
            opA = new Aritmetica();
            Resultado resultado1 = null;
            Resultado resultado2 = null;

            switch (raiz.Term.Name)
            {
                case "EXPL":
                    if (raiz.ChildNodes.Count == 3)
                    {
                        resultado1 = relacionar(raiz.ChildNodes[0]);
                        resultado2 = relacionar(raiz.ChildNodes[2]);
                        if (raiz.ChildNodes[1].Token.Text == "AND")
                        {
                            if (Convert.ToBoolean(resultado1.valor) && Convert.ToBoolean(resultado2.valor))
                            {
                                return new Resultado("booleano", true);
                            }
                            else
                            {
                                return new Resultado("booleano", false);
                            }
                        }
                        else if (raiz.ChildNodes[1].Token.Text == "OR")
                        {
                            if (Convert.ToBoolean(resultado1.valor) || Convert.ToBoolean(resultado2.valor))
                            {
                                return new Resultado("booleano", true);
                            }
                            else
                            {
                                return new Resultado("booleano", false);
                            }
                        }
                    }
                    else if (raiz.ChildNodes.Count == 2)
                    {
                        resultado1 = relacionar(raiz.ChildNodes[1]);
                        if (!Convert.ToBoolean(resultado1.valor))
                        {
                            return new Resultado("booleano", true);
                        }
                        else
                        {
                            return new Resultado("booleano", false);
                        }
                    }
                    else
                    {
                        return relacionar(raiz.ChildNodes[0]);
                    }
                    break;
                case "EXPR":
                    if (raiz.ChildNodes.Count == 3)
                    {
                        resultado1 = opA.operar(raiz.ChildNodes[0]);
                        resultado2 = opA.operar(raiz.ChildNodes[2]);
                    }
                    else
                    {
                        return opA.operar(raiz.ChildNodes[0]);
                    }
                    break;
            }


            String tipoRelacional = raiz.ChildNodes[1].Token.Text;
            String tipo1;
            String tipo2;

            if (resultado1 != null && resultado2 != null)
            {
                switch (tipoRelacional)
                {
                    case "==":
                        tipo1 = resultado1.tipo;
                        switch (tipo1)
                        {
                            case "doble":
                                tipo2 = resultado2.tipo;
                                switch (tipo2)
                                {
                                    case "doble":
                                        if (resultado1.valor.ToString() == resultado2.valor.ToString())
                                        {
                                            return new Resultado("booleano", true);
                                        }
                                        else
                                        {
                                            return new Resultado("booleano", false);
                                        }
                                    case "cadena":
                                        break;
                                }
                                break;
                            case "cadena":
                                tipo2 = resultado2.tipo;
                                switch (tipo2)
                                {
                                    case "doble":
                                        break;
                                    case "cadena":
                                        if (resultado1.valor.ToString() == resultado2.valor.ToString())
                                        {
                                            return new Resultado("booleano", true);
                                        }
                                        else
                                        {
                                            return new Resultado("booleano", false);
                                        }
                                }
                                break;
                        }
                        break;
                    case ">":
                        tipo1 = resultado1.tipo;
                        switch (tipo1)
                        {
                            case "doble":
                                tipo2 = resultado2.tipo;
                                switch (tipo2)
                                {
                                    case "doble":
                                        if (Double.Parse(resultado1.valor + "") > Double.Parse(resultado2.valor + ""))
                                        {
                                            return new Resultado("booleano", true);
                                        }
                                        else
                                        {
                                            return new Resultado("booleano", false);
                                        }
                                    case "cadena":
                                        break;
                                }
                                break;
                            case "cadena":
                                tipo2 = resultado2.tipo;
                                switch (tipo2)
                                {
                                    case "doble":
                                        break;
                                    case "cadena":
                                        break;
                                }
                                break;
                        }
                        break;
                    case "<":
                        tipo1 = resultado1.tipo;
                        switch (tipo1)
                        {
                            case "doble":
                                tipo2 = resultado2.tipo;
                                switch (tipo2)
                                {
                                    case "doble":
                                        if (Double.Parse(resultado1.valor + "") < Double.Parse(resultado2.valor + ""))
                                        {
                                            return new Resultado("booleano", true);
                                        }
                                        else
                                        {
                                            return new Resultado("booleano", false);
                                        }
                                    case "cadena":
                                        break;
                                }
                                break;
                            case "cadena":
                                tipo2 = resultado2.tipo;
                                switch (tipo2)
                                {
                                    case "doble":
                                        break;
                                    case "cadena":
                                        break;
                                }
                                break;
                        }
                        break;
                    case "<=":
                        tipo1 = resultado1.tipo;
                        switch (tipo1)
                        {
                            case "doble":
                                tipo2 = resultado2.tipo;
                                switch (tipo2)
                                {
                                    case "doble":
                                        if (Double.Parse(resultado1.valor + "") <= Double.Parse(resultado2.valor + ""))
                                        {
                                            return new Resultado("booleano", true);
                                        }
                                        else
                                        {
                                            return new Resultado("booleano", false);
                                        }
                                    case "cadena":
                                        break;
                                }
                                break;
                            case "cadena":
                                tipo2 = resultado2.tipo;
                                switch (tipo2)
                                {
                                    case "doble":
                                        break;
                                    case "cadena":
                                        break;
                                }
                                break;
                        }
                        break;
                    case ">=":
                        tipo1 = resultado1.tipo;
                        switch (tipo1)
                        {
                            case "doble":
                                tipo2 = resultado2.tipo;
                                switch (tipo2)
                                {
                                    case "doble":
                                        if (Double.Parse(resultado1.valor + "") >= Double.Parse(resultado2.valor + ""))
                                        {
                                            return new Resultado("booleano", true);
                                        }
                                        else
                                        {
                                            return new Resultado("booleano", false);
                                        }
                                    case "cadena":
                                        break;
                                }
                                break;
                            case "cadena":
                                tipo2 = resultado2.tipo;
                                switch (tipo2)
                                {
                                    case "doble":
                                        break;
                                    case "cadena":
                                        break;
                                }
                                break;
                        }
                        break;
                    case "!=":
                        tipo1 = resultado1.tipo;
                        switch (tipo1)
                        {
                            case "doble":
                                tipo2 = resultado2.tipo;
                                switch (tipo2)
                                {
                                    case "doble":
                                        if (resultado1.valor.ToString() != resultado2.valor.ToString())
                                        {
                                            return new Resultado("booleano", true);
                                        }
                                        else
                                        {
                                            return new Resultado("booleano", false);
                                        }
                                    case "cadena":
                                        break;
                                }
                                break;
                            case "cadena":
                                tipo2 = resultado2.tipo;
                                switch (tipo2)
                                {
                                    case "doble":
                                        break;
                                    case "cadena":
                                        if (resultado1.valor.ToString() != resultado2.valor.ToString())
                                        {
                                            return new Resultado("booleano", true);
                                        }
                                        else
                                        {
                                            return new Resultado("booleano", false);
                                        }
                                }
                                break;
                        }
                        break;
                }
            }

            return null;
        }
    }
}