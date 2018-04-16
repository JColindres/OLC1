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
            var imprimir = ToTerm("imprimir");
            var raiz = ToTerm("raiz");
            var graficar = ToTerm("graficar");
            var parA = ToTerm("(");
            var parC = ToTerm(")");
            var pYc = ToTerm(";");
            var coma = ToTerm(",");
            var comi = ToTerm("\"");
            #endregion

            #region No Terminales
            NonTerminal S = new NonTerminal("S"),
                E = new NonTerminal("E"),
                F = new NonTerminal("F"),
                PROGRAMA = new NonTerminal("PROGRAMA"),
                SENTENCIAS = new NonTerminal("SENTENCIAS"),
                IMP = new NonTerminal("IMP"),
                RAIZ = new NonTerminal("RAIZ"),
                GRAFICAR = new NonTerminal("GRAFICAR"),
                LLAMFUNC1 = new NonTerminal("LLAMFUNC1"),
                LLAMFUNC2 = new NonTerminal("LLAMFUNC2"),
                OPFUNC = new NonTerminal("OPFUNC"),
                PARAM = new NonTerminal("PARAM"),
                PARAMUNIC = new NonTerminal("PARAMUNIC"),
                OPERADOR = new NonTerminal("OPERADOR");
            #endregion

            #region Gramatica
            S.Rule = PROGRAMA;

            PROGRAMA.Rule = MakePlusRule(PROGRAMA,SENTENCIAS);

            SENTENCIAS.Rule = E
                | IMP
                | RAIZ
                | GRAFICAR;

            IMP.Rule = imprimir + parA + PARAMUNIC + parC + pYc;

            RAIZ.Rule = raiz + parA + PARAMUNIC + coma + numero + parC + pYc;

            GRAFICAR.Rule = graficar + parA + cadena + coma + cadena + coma + E + coma + E + coma + cadena + parC + pYc;

            PARAMUNIC.Rule = LLAMFUNC1
                | E;

            LLAMFUNC1.Rule = OPFUNC
                | LLAMFUNC2;

            OPFUNC.Rule = MakePlusRule(LLAMFUNC2, OPERADOR, E)
                | MakePlusRule(E, OPERADOR, LLAMFUNC1);

            LLAMFUNC2.Rule = id + parA + PARAM + parC;

            PARAM.Rule = MakePlusRule(PARAM, coma, E)
                | MakePlusRule(PARAM, OPERADOR, E);

            OPERADOR.Rule = mas
                | menos
                | mul
                | div
                | pot;

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
            this.MarkTransient(S,F,LLAMFUNC1,OPERADOR,SENTENCIAS);
            this.RegisterOperators(1, Associativity.Left, mas, menos);
            this.RegisterOperators(2, Associativity.Left, mul, div);
            this.RegisterOperators(3, Associativity.Left, pot);
            this.MarkPunctuation("(",")",",",";");
            #endregion
        }
    }
}