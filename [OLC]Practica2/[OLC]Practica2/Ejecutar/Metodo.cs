using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _OLC_Practica2.Ejecutar
{
    public class Metodo
    {
        public String nombre;
        public String id;//cuando hay sobrecarga el id es importante y para generarlo se concatena el nombre del metodo con todos los tipos de los parametros
        public String tipo;
        public String ambito;
        public ParseTreeNode raiz;

        public Metodo(String tipo, String nombre, String ambito, ParseTreeNode raiz)
        {
            this.nombre = nombre;
            this.tipo = tipo;
            this.raiz = raiz;
            //this.id = generarId(raiz.ChildNodes[3]);

        }

        public string generarId(ParseTreeNode parametros)
        {
            //aqui es donde se recorre la lista de parametros y se concatena el tipo de cada uno
            string tipoAccion;
            foreach (ParseTreeNode nodo in parametros.ChildNodes)
            {
                tipoAccion = nodo.Term.Name;
                switch (tipoAccion)
                {
                    case "DECLA":
                        ambito = "local";
                        nombre = nodo.ChildNodes[0].Token.Text;
                        Simbolo simbolo = new Simbolo(null, nombre, ambito, null);
                        Boolean estado = Programa.tablaLocal.addSimbolo(simbolo);
                        id += nombre + " ";
                        return id;
                    case "E":
                        generarId(nodo.ChildNodes[0]);
                        break;
                    case "id":
                        String iden = raiz.Token.Text.Replace("\"", "");
                        if (Programa.tablaGlobal.getSimbolo(iden) != null)
                        {
                            id += iden + " ";
                            return id;
                        }
                        else if (Programa.tablaLocal.getSimbolo(iden) != null)
                        {
                            id += iden + " ";
                            return id;
                        }
                        else
                        {
                            return null;
                        }

                }
            }
                return id;
        }
    }
}