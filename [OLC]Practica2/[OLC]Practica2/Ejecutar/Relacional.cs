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
                    }
                    else
                    {
                        return relacionar(raiz.ChildNodes[0]);
                    }
                    break;
                case "NOT":
                    resultado1 = relacionar(raiz.ChildNodes[1]);
                    if (!Convert.ToBoolean(resultado1.valor))
                    {
                        return new Resultado("booleano", true);
                    }
                    else
                    {
                        return new Resultado("booleano", false);
                    }
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

            //falta verificar tipos, deben tomar la idea de la operacion arimetica para este caso
            switch (tipoRelacional)
            {
                case "==":
                    if (resultado1.valor.ToString() == resultado2.valor.ToString())
                    {
                        return new Resultado("booleano", true);
                    }
                    else
                    {
                        return new Resultado("booleano", false);
                    }
                case ">":
                    if (Double.Parse(resultado1.valor + "") > Double.Parse(resultado2.valor + ""))
                    {
                        return new Resultado("booleano", true);
                    }
                    else
                    {
                        return new Resultado("booleano", false);
                    }
                case "<":
                    if (Double.Parse(resultado1.valor + "") < Double.Parse(resultado2.valor + ""))
                    {
                        return new Resultado("booleano", true);
                    }
                    else
                    {
                        return new Resultado("booleano", false);
                    }
                case "<=":
                    if (Double.Parse(resultado1.valor + "") <= Double.Parse(resultado2.valor + ""))
                    {
                        return new Resultado("booleano", true);
                    }
                    else
                    {
                        return new Resultado("booleano", false);
                    }
                case ">=":
                    if (Double.Parse(resultado1.valor + "") >= Double.Parse(resultado2.valor + ""))
                    {
                        return new Resultado("booleano", true);
                    }
                    else
                    {
                        return new Resultado("booleano", false);
                    }
                case "!=":
                    if (Double.Parse(resultado1.valor + "") != Double.Parse(resultado2.valor + ""))
                    {
                        return new Resultado("booleano", true);
                    }
                    else
                    {
                        return new Resultado("booleano", false);
                    }
            }

            return null;
        }
    }
}