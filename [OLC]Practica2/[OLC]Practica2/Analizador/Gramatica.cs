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
            IdentifierTerminal id = new IdentifierTerminal("id");
            #endregion

            #region Terminales
            var mas = ToTerm("+");
            var menos = ToTerm("-");
            var mul = ToTerm("*");
            var div = ToTerm("/");
            var pot = ToTerm("^");
            #endregion

            #region No Terminales
            NonTerminal S = new NonTerminal("S"),
                E = new NonTerminal("E"),
                F = new NonTerminal("F"),
                T = new NonTerminal("T");
            #endregion

            #region Gramatica
            S.Rule = E;

            E.Rule = E + mas + T
                | E + menos + T
                | T;

            T.Rule = T + mul + F
                | T + div + F
                | T + pot + F
                | F;

            F.Rule = numero
                | id;
            #endregion

            #region Preferencias
            this.Root = S;
            #endregion
        }
    }
}