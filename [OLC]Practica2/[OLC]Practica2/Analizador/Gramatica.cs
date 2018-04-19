using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Irony.Ast;
using Irony.Parsing;

namespace _OLC_Practica2.Analizador
{
    public class Gramatica : Grammar
    {
        public Gramatica() : base(caseSensitive: false)
        {
            #region ER
            NumberLiteral doble = new NumberLiteral("doble");
            IdentifierTerminal id = new IdentifierTerminal("id");
            StringLiteral cadena = TerminalFactory.CreateCSharpString("cadena");
            ConstantTerminal booleano = new ConstantTerminal("booleano");
            booleano.Add("true", true);
            booleano.Add("false", false);
            CommentTerminal comentario2 = new CommentTerminal("comentario2", "/*", "*/");
            CommentTerminal comentario1 = new CommentTerminal("comentario1", "//", "\n", "\r\n");
            base.NonGrammarTerminals.Add(comentario2);
            base.NonGrammarTerminals.Add(comentario1);
            #endregion

            #region Terminales
            var mas = ToTerm("+");
            var menos = ToTerm("-");
            var mul = ToTerm("*");
            var div = ToTerm("/");
            var pot = ToTerm("^");
            var parA = ToTerm("(");
            var parC = ToTerm(")");
            var corA = ToTerm("[");
            var corC = ToTerm("]");
            var pYc = ToTerm(";");
            var dosPuntos = ToTerm(":");
            var coma = ToTerm(",");
            var asig = ToTerm("::=");
            var igual = ToTerm("=");
            var mayor = ToTerm(">");
            var menor = ToTerm("<");
            var mayorIgual = ToTerm(">=");
            var menorIgual = ToTerm("<=");
            var igualIgual = ToTerm("==");
            var noIgual = ToTerm("!=");
            var programa = ToTerm("programa");
            var imprimir = ToTerm("imprimir");
            var raiz = ToTerm("raiz");
            var graficar = ToTerm("graficar");
            var variable = ToTerm("var");
            var resInt = ToTerm("int");
            var resDouble = ToTerm("double");
            var resString = ToTerm("string");
            var resChar = ToTerm("char");
            var resBool = ToTerm("bool");
            var resVoid = ToTerm("void");
            var OR = ToTerm("OR");
            var AND = ToTerm("AND");
            var NOT = ToTerm("NOT");
            var resReturn = ToTerm("retornar");
            var principal = ToTerm("principal");
            var si = ToTerm("SI");
            var sino = ToTerm("SINO");
            var sino_si = ToTerm("SINO_SI");
            var interrumpir = ToTerm("INTERRUMPIR");
            var caso = ToTerm("CASO");
            var defecto = ToTerm("DEFECTO");
            var mientras = ToTerm("MIENTRAS");
            var hacer = ToTerm("HACER");
            var salir = ToTerm("salir");
            #endregion

            #region No Terminales
            NonTerminal S = new NonTerminal("S"),
                E = new NonTerminal("E"),
                EXPR = new NonTerminal("EXPR"),
                EXPL = new NonTerminal("EXPL"),
                PROGRAMA = new NonTerminal("PROGRAMA"),
                CUERPOS = new NonTerminal("CUERPOS"),
                CUERPO = new NonTerminal("CUERPO"),
                ATRIBUTOS = new NonTerminal("ATRIBUTOS"),
                ATRIBUTO = new NonTerminal("ATRIBUTO"),
                DECLARACION = new NonTerminal("DECLARACION"),
                ASIGNACION = new NonTerminal("ASIGNACION"),
                PRINCIPAL = new NonTerminal("PRINCIPAL"),
                METODO = new NonTerminal("METODO"),
                FUNCION = new NonTerminal("FUNCION"),
                TIPO = new NonTerminal("TIPO"),
                IMP = new NonTerminal("IMP"),
                RAIZ = new NonTerminal("RAIZ"),
                GRAFICAR = new NonTerminal("GRAFICAR"),
                LISTA_ID = new NonTerminal("LISTA_ID"),
                LISTA_PARAM = new NonTerminal("LISTA_PARAM"),
                DECLA = new NonTerminal("DECLA"),
                UNICO = new NonTerminal("UNICO"),
                UNICOS = new NonTerminal("UNICOS"),
                LLAMADA = new NonTerminal("LLAMADA"),
                LLAMFUNC = new NonTerminal("LLAMFUNC"),
                OPERANDO = new NonTerminal("OPERANDO"),
                RETORNO = new NonTerminal("RETORNO"),
                SI = new NonTerminal("SI"),
                SINO = new NonTerminal("SINO"),
                SINO_SI = new NonTerminal("SINO_SI"),
                SINOSI = new NonTerminal("SINOSI"),
                INTERRUMPIR = new NonTerminal("INTERRUMPIR"),
                CASO = new NonTerminal("CASO"),
                CASOS = new NonTerminal("CASOS"),
                DEFECTO = new NonTerminal("DEFECTO"),
                MIENTRAS = new NonTerminal("MIENTRAS"),
                HACER = new NonTerminal("HACER"),
                SALIR = new NonTerminal("SALIR");
            #endregion

            #region Gramatica
            S.Rule = PROGRAMA;

            PROGRAMA.Rule = programa + id + corA + CUERPO + corC;

            CUERPO.Rule = MakePlusRule(CUERPO, CUERPOS);

            CUERPOS.Rule = METODO
                | FUNCION
                | PRINCIPAL
                | DECLARACION
                | ASIGNACION;

            ATRIBUTOS.Rule = MakePlusRule(ATRIBUTOS, ATRIBUTO)
                | Empty;

            ATRIBUTO.Rule = DECLARACION
                | ASIGNACION
                | IMP
                | RAIZ
                | GRAFICAR
                | LLAMFUNC
                | SALIR
                | SI
                | INTERRUMPIR
                | MIENTRAS
                | HACER;

            METODO.Rule = resVoid + id + parA + LISTA_PARAM + parC + corA + ATRIBUTOS + corC;

            FUNCION.Rule = TIPO + id + parA + LISTA_PARAM + parC + corA + ATRIBUTOS + RETORNO + corC;

            PRINCIPAL.Rule = principal + parA + parC + corA + ATRIBUTOS + corC;

            RETORNO.Rule = resReturn + E + pYc;

            SALIR.Rule = salir + pYc;

            DECLARACION.Rule = variable + LISTA_ID + pYc;

            DECLA.Rule = variable + id;

            ASIGNACION.Rule = variable + id + asig + E + pYc
                | id + asig + E + pYc;

            IMP.Rule = imprimir + parA + E + parC + pYc;

            RAIZ.Rule = raiz + parA + E + coma + E + parC + pYc;

            GRAFICAR.Rule = graficar + parA + E + coma + E + coma + E + coma + E + coma + E + parC + pYc;

            LISTA_ID.Rule = MakePlusRule(LISTA_ID, coma, id);

            LISTA_PARAM.Rule = MakePlusRule(LISTA_PARAM, coma, DECLA)
                | MakePlusRule(LISTA_PARAM, coma, E)
                | Empty;
            
            UNICO.Rule = MakePlusRule(UNICO, OPERANDO, UNICOS);

            UNICOS.Rule = E;

            LLAMADA.Rule = id + parA + LISTA_PARAM + parC;

            LLAMFUNC.Rule = LLAMADA + pYc;

            SI.Rule = si + parA + EXPL + parC + corA + ATRIBUTOS + corC + SINO_SI;

            SINO_SI.Rule = MakePlusRule(SINO_SI, SINOSI)
                | Empty;

            SINOSI.Rule = sino_si + parA + EXPL + parC + corA + ATRIBUTOS + corC
                | sino + corA + ATRIBUTOS + corC;

            SINO.Rule = sino + corA + ATRIBUTOS + corC;

            INTERRUMPIR.Rule = interrumpir + parA + E + parC + corA + CASO + DEFECTO + corC;

            CASO.Rule = MakePlusRule(CASO, CASOS)
                | Empty;

            CASOS.Rule = caso + E + dosPuntos + ATRIBUTOS;

            DEFECTO.Rule = defecto + dosPuntos + ATRIBUTOS
                | Empty;

            MIENTRAS.Rule = mientras + parA + EXPL + parC + corA + ATRIBUTOS + corC;

            HACER.Rule = hacer + corA + ATRIBUTOS + corC + mientras + parA + EXPL + parC + pYc;

            OPERANDO.Rule = mas | menos | mul | div | pot;

            TIPO.Rule = resInt
                | resDouble
                | resString
                | resChar
                | resBool;

            E.Rule = E + mas + E
                | E + menos + E
                | E + mul + E
                | E + div + E
                | E + pot + E 
                | parA + E + parC
                | menos + E
                | LLAMADA
                | id
                | doble
                | cadena
                | booleano;

            EXPR.Rule = E + mayor + E
                | E + menor + E
                | E + mayorIgual + E
                | E + menorIgual + E
                | E + igualIgual + E
                | E + noIgual + E
                | E;

            EXPL.Rule = EXPL + OR + EXPR
                | EXPL + AND + EXPR
                | NOT + EXPL
                | EXPR;
            #endregion

            #region Preferencias
            this.Root = S;
            this.MarkTransient(TIPO, UNICOS, CUERPOS, CASOS, ATRIBUTO);
            this.RegisterOperators(1, Associativity.Left, mas, menos);
            this.RegisterOperators(2, Associativity.Left, mul, div);
            this.RegisterOperators(3, Associativity.Left, pot);
            this.RegisterOperators(4, "==", "!=", "<", ">", "<=", ">=");
            this.RegisterOperators(5, Associativity.Left, OR);
            this.RegisterOperators(6, Associativity.Left, AND);
            this.RegisterOperators(7, Associativity.Right, NOT);
            this.RegisterOperators(8, Associativity.Left, "(", ")");
            this.MarkPunctuation("(",")",",",";","[","]","::=",":");
            #endregion
        }
    }
}