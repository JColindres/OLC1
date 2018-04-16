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
            RegexBasedTerminal numero = new RegexBasedTerminal("numero","[0-9]+");
            RegexBasedTerminal doble = new RegexBasedTerminal("doble", "[0-9]+\\.[0-9]+");
            IdentifierTerminal id = new IdentifierTerminal("id");
            StringLiteral cadena = TerminalFactory.CreateCSharpString("cadena");
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
            var coma = ToTerm(",");
            var asig = ToTerm("::=");
            var igual = ToTerm("=");
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
            #endregion

            #region No Terminales
            NonTerminal S = new NonTerminal("S"),
                E = new NonTerminal("E"),
                F = new NonTerminal("F"),
                PROGRAMA = new NonTerminal("PROGRAMA"),
                CUERPOS = new NonTerminal("CUERPOS"),
                CUERPO = new NonTerminal("CUERPO"),
                ATRIBUTOS = new NonTerminal("ATRIBUTOS"),
                ATRIBUTO = new NonTerminal("ATRIBUTO"),
                DECLARACION = new NonTerminal("DECLARACION"),
                ASIGNACION = new NonTerminal("ASIGNACION"),
                METODOS = new NonTerminal("METODOS"),
                TIPO = new NonTerminal("TIPO"),
                IMP = new NonTerminal("IMP"),
                RAIZ = new NonTerminal("RAIZ"),
                GRAFICAR = new NonTerminal("GRAFICAR"),
                LISTA_ID = new NonTerminal("LISTA_ID"),
                LISTA_PARAM = new NonTerminal("LISTA_PARAM"),
                DECLA = new NonTerminal("DECLA"),
                UNICO = new NonTerminal("UNICO");
            #endregion

            #region Gramatica
            S.Rule = PROGRAMA;

            PROGRAMA.Rule = programa + id + corA + CUERPOS + corC;

            CUERPOS.Rule = MakeStarRule(CUERPOS, CUERPO);

            CUERPO.Rule = ATRIBUTOS
                | METODOS;

            ATRIBUTOS.Rule = MakePlusRule(ATRIBUTOS, ATRIBUTO);

            ATRIBUTO.Rule = DECLARACION
                | ASIGNACION
                | IMP
                | RAIZ
                | GRAFICAR;

            METODOS.Rule = TIPO + id + parA + LISTA_PARAM + parC + corA + ATRIBUTOS + corC
                | TIPO + id + parA + parC + corA + ATRIBUTOS + corC;

            DECLARACION.Rule = variable + LISTA_ID + pYc;

            DECLA.Rule = variable + id;

            ASIGNACION.Rule = variable + id + asig + E + pYc
                | id + asig + E + pYc;

            IMP.Rule = imprimir + parA + UNICO + parC + pYc;

            RAIZ.Rule = raiz + parA + UNICO + coma + E + parC + pYc;

            GRAFICAR.Rule = graficar + parA + cadena + coma + cadena + coma + E + coma + E + coma + cadena + parC + pYc;

            LISTA_ID.Rule = MakePlusRule(LISTA_ID, coma, id);

            LISTA_PARAM.Rule = MakePlusRule(LISTA_PARAM, coma, DECLA)
                | MakePlusRule(LISTA_PARAM, coma, E);
            
            UNICO.Rule = E; 

            TIPO.Rule = resInt
                | resDouble
                | resString
                | resChar
                | resBool
                | resVoid;

            E.Rule = E + mas + E
                | E + menos + E
                | E + mul + E
                | E + div + E
                | E + pot + E 
                | parA + E + parC
                | F;

            F.Rule = numero
                | id
                | doble
                | cadena;
            #endregion

            #region Preferencias
            this.Root = S;
            this.MarkTransient(S, F, CUERPO, ATRIBUTO, TIPO);
            this.RegisterOperators(1, Associativity.Left, mas, menos);
            this.RegisterOperators(2, Associativity.Left, mul, div);
            this.RegisterOperators(3, Associativity.Left, pot);
            this.MarkPunctuation("(",")",",",";","[","]","var","::=");
            #endregion
        }
    }
}