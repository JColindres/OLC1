using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ejecucion.Ejecucion
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
                case "EXPA":
                    if (raiz.ChildNodes.Count==3)
                    {
                        resultado1 = operar(raiz.ChildNodes[0]);
                        resultado2 = operar(raiz.ChildNodes[2]);
                    }else
                    {
                        return operar(raiz.ChildNodes[0]);
                    }
                    break;
                case "Double":
                    return new Resultado("Double", raiz.Token.Text);
                case "String":
                    String cadena = raiz.Token.Text.Replace("\"","");
                    return new Resultado("String", cadena);
                    
                case "id":
                    //acceder a la tabla de simbolo para tomar el valor y el tipo del id
                    break;
                case "LLAMADAMETODO":
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
                        case "Double":
                            tipo2 = resultado2.tipo;
                            switch (tipo2)
                            {
                                case "Double":
                                    return new Resultado("Double", Double.Parse(resultado1.valor + "") + Double.Parse(resultado2.valor + ""));
                              
                                case "String":
                                    return new Resultado("String", Double.Parse(resultado1.valor + "") + (String)resultado2.valor);
                                    
                            }
                            break;
                        case "String":
                            tipo2 = resultado2.tipo;
                            switch (tipo2)
                            {
                                case "Double":
                                    return new Resultado("String", (String)resultado1.valor + Double.Parse(resultado2.valor + ""));
                                   
                                case "String":
                                    return new Resultado("String", (String)resultado1.valor + (String)resultado2.valor);
                                   
                            }
                            break;

                    }
                    
                    break;
                case "*":
                    tipo1 = resultado1.tipo;
                    switch (tipo1)
                    {
                        case "Double":
                            tipo2 = resultado2.tipo;
                            switch (tipo2)
                            {
                                case "Double":
                                    return new Resultado("Double",Double.Parse(resultado1.valor+"") * Double.Parse(resultado2.valor+""));
                                    
                                case "String":
                                    //reportar error semantico, linea y columna
                                    break;
                            }
                            break;
                        case "String":
                            tipo2 = resultado2.tipo;
                            switch (tipo2)
                            {
                                case "Double":
                                    //reportar error semantico,linea y columna
                                    break;
                                case "String":
                                    //Reportar error semantoco, linea y columna
                                    break;
                            }
                            break;

                    }
                    break;
                case "id":
                    break;
                case "LLAMADAMETODO":
                    break;
                case "Double":
                    return new Resultado("Double",raiz.Token.Text);
                case "String":
                    return new Resultado("String", raiz.Token.Text);

            }

            return null;

        }
    }
}