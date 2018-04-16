using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Ast;
using Irony.Interpreter;
using Irony.Parsing;

namespace Hoja_de_Trabajo_3.Analizador
{
    class Gramatica : Grammar
    {
        public Gramatica() : base(caseSensitive: false)
        {
            #region ER
            RegexBasedTerminal numero = new RegexBasedTerminal("numero", "[0-9]+");
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
            var entero = ToTerm("int");
            var texto = ToTerm("String");
            var booleano = ToTerm("bool");
            var decimales = ToTerm("double");
            var parA = ToTerm("(");
            var parC = ToTerm(")");
            var pYc = ToTerm(";");
            var igual = ToTerm("=");
            var coma = ToTerm(",");
            var mayorIgual = ToTerm("<=");
            var menorIgual = ToTerm(">=");
            var IgualIgual = ToTerm("==");
            var diferente = ToTerm("!=");
            var mayor = ToTerm("<");
            var menor = ToTerm(">");
            var VOID = ToTerm("void");
            var llaveA = ToTerm("{");
            var llaveC = ToTerm("}");
            var si = ToTerm("if");
            var mientras = ToTerm("while");
            #endregion

            #region No Terminales
            NonTerminal S = new NonTerminal("S"),
                E = new NonTerminal("E"),
                T = new NonTerminal("T"),
                R = new NonTerminal("R"),
                F = new NonTerminal("F"),
                TIPO = new NonTerminal("TIPO"),
                EXP = new NonTerminal("EXP"),
                DECLARACION = new NonTerminal("DECLARACION"),
                SENTENCIAS = new NonTerminal("SENTENCIAS"),
                SENTIF = new NonTerminal("SENTIF"),
                SENTWHILE = new NonTerminal("SENTWHILE"),
                METODO = new NonTerminal("METODO"),
                PROGRA = new NonTerminal("PROGRA"),
                OPERADOR = new NonTerminal("OPERADOR");
            #endregion

            #region Gramatica
            S.Rule = PROGRA;

            PROGRA.Rule = MakePlusRule(PROGRA,SENTENCIAS)
                | MakePlusRule(PROGRA, METODO);

            DECLARACION.Rule = TIPO + id + igual + EXP + pYc;

            SENTENCIAS.Rule = EXP
                |DECLARACION
                |SENTIF
                |SENTWHILE
                |Empty;
            
            SENTIF.Rule = si + parA + EXP + parC + llaveA + SENTENCIAS + llaveC;

            SENTWHILE.Rule = mientras + parA + EXP + parC + llaveA + SENTENCIAS + llaveC;

            METODO.Rule = VOID + id + parA + parC + llaveA + SENTENCIAS + llaveC;

            EXP.Rule = E
                | EXP + mayor + EXP
                | EXP + menor + EXP
                | EXP + mayorIgual + EXP
                | EXP + menorIgual + EXP
                | EXP + IgualIgual + EXP
                | EXP + diferente + EXP;

            OPERADOR.Rule = mas
                | menos
                | mul
                | div
                | pot;

            E.Rule = E + mas + T
                | E + menos + T
                | T;

            T.Rule = T + mul + R
                | T + div + R
                | R;
            
            R.Rule = R + pot + F
                | F;

            F.Rule = numero
                | id
                | doble
                | cadena;

            TIPO.Rule = entero
                | texto
                | decimales
                | booleano;
            #endregion

            #region Preferencias
            this.Root = S;
            #endregion
        }
    }
}
