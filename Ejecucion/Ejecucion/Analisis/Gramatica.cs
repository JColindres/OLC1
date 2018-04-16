using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Irony.Parsing;
using Irony.Ast;

namespace Ejecucion.Analisis
{
    public class Gramatica : Grammar
    {
        public Gramatica()
        {

            CommentTerminal comentario2 = new CommentTerminal("comentario2", "/*", "*/");//acepta comentarios de varias lineas
            CommentTerminal comentario1 = new CommentTerminal("comentario1", "//", "\n", "\r\n");//hacepta comentarios que terminan en una sola linea
            base.NonGrammarTerminals.Add(comentario2);
            base.NonGrammarTerminals.Add(comentario1);

            IdentifierTerminal id = new IdentifierTerminal("id");
            StringLiteral cadena = new StringLiteral("String", "\"");
            NumberLiteral numero = new NumberLiteral("Double");

            NonTerminal INICIO = new NonTerminal("INICIO"),// ACEPTACIOM
                METODO = new NonTerminal("METODO"),
                IF = new NonTerminal("IF"),
                WHILE = new NonTerminal("WHILE"),
                EXPA = new NonTerminal("EXPA"),
                EXPR = new NonTerminal("EXPR"),
                DECLARACION = new NonTerminal("DECLARACION"),
                SENTENCIA = new NonTerminal("SENTENCIA"),
                SENTENCIAS = new NonTerminal("SENTENCIAS"),
                CUERPO=new NonTerminal("CUERPO"),
                CUERPOS=new NonTerminal("CUERPOS"),
                IMPRIMIR=new NonTerminal("IMPRIMIR");


            INICIO.Rule = CUERPOS;

            CUERPOS.Rule = MakeStarRule(CUERPOS, CUERPO);

            CUERPO.Rule = DECLARACION
                       |METODO;

            METODO.Rule = ToTerm("void") + id + "(" + ")" + "{" +SENTENCIAS+ "}";

            SENTENCIAS.Rule = MakeStarRule(SENTENCIAS, SENTENCIA);

            SENTENCIA.Rule = IF
                        | WHILE
                        | DECLARACION
                        |IMPRIMIR;

            IF.Rule = ToTerm("if") + "(" + EXPR + ")" + "{" +SENTENCIAS+ "}";

            WHILE.Rule = ToTerm("while") + "(" + EXPR + ")" + "{" + SENTENCIAS + "}";
            IMPRIMIR.Rule = ToTerm("imprimir")+ "(" + EXPA + ")"+";";

            DECLARACION.Rule = ToTerm("Double") + id + "=" + EXPA+";";

            EXPA.Rule = EXPA + "+" + EXPA
                    | EXPA + "*" + EXPA
                    | cadena
                    | numero;

            EXPR.Rule = EXPA + "==" + EXPA
                    | EXPA + ">" + EXPA;


            this.Root = INICIO;
            MarkPunctuation(";","(",")","{","}","var","=","if","while","imprimir");//para quitar hojas inutiles del arbol
            MarkTransient(CUERPO,SENTENCIA,INICIO);//para quitar Nodos inutiles del arbol
            RegisterOperators(1, Associativity.Left, "+", "-");
            RegisterOperators(2, Associativity.Left, "*", "/");
            RegisterOperators(3, Associativity.Right, "^");
            RegisterOperators(4, "==", "!=", "<", ">", "<=", ">=");
            RegisterOperators(5, Associativity.Left, "||");
            RegisterOperators(6, Associativity.Left, "|&");
            RegisterOperators(7, Associativity.Left, "&&");
            RegisterOperators(8, Associativity.Left, "!");
            RegisterOperators(9, Associativity.Left, "(", ")");
        }

        

    }
}