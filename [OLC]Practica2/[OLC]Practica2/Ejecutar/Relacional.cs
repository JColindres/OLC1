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
            Resultado resultado1 = opA.operar(raiz.ChildNodes[0]);
            opA = new Aritmetica();
            Resultado resultado2 = opA.operar(raiz.ChildNodes[2]);

            String tipoRelacional = raiz.ChildNodes[1].Token.Text;

            //falta verificar tipos, deben tomar la idea de la operacion arimetica para este caso
            switch (tipoRelacional)
            {
                case "==":
                    if (resultado1.valor.ToString() == resultado2.valor.ToString())
                    {
                        return new Resultado("Boolean", true);
                    }
                    else
                    {
                        return new Resultado("Boolean", false);
                    }
                case ">":
                    if (Double.Parse(resultado1.valor + "") > Double.Parse(resultado2.valor + ""))
                    {
                        return new Resultado("Boolean", true);
                    }
                    else
                    {
                        return new Resultado("Boolean", false);
                    }
                case "<":
                    if (Double.Parse(resultado1.valor + "") < Double.Parse(resultado2.valor + ""))
                    {
                        return new Resultado("Boolean", true);
                    }
                    else
                    {
                        return new Resultado("Boolean", false);
                    }
                case "<=":
                    if (Double.Parse(resultado1.valor + "") <= Double.Parse(resultado2.valor + ""))
                    {
                        return new Resultado("Boolean", true);
                    }
                    else
                    {
                        return new Resultado("Boolean", false);
                    }
                case ">=":
                    if (Double.Parse(resultado1.valor + "") >= Double.Parse(resultado2.valor + ""))
                    {
                        return new Resultado("Boolean", true);
                    }
                    else
                    {
                        return new Resultado("Boolean", false);
                    }
                case "!=":
                    if (Double.Parse(resultado1.valor + "") != Double.Parse(resultado2.valor + ""))
                    {
                        return new Resultado("Boolean", true);
                    }
                    else
                    {
                        return new Resultado("Boolean", false);
                    }
            }

            return null;
        }
    }
}