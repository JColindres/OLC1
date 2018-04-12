using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Parsing;
using Irony.Ast;

namespace Calculadora
{
    class Sintactico : Grammar
    {

        public Sintactico()
        {

            // Comentarios
            var comentario = new CommentTerminal("comentario", ">>", "\n", "\r\n");
            var Mcomentario = new CommentTerminal("Mcomentario", "<-", "->");
            base.NonGrammarTerminals.Add(comentario);
            base.NonGrammarTerminals.Add(Mcomentario);

            //ER
            IdentifierTerminal id = new IdentifierTerminal("id");
            RegexBasedTerminal numero = new RegexBasedTerminal("entero", "[0-9]+");
            
            RegexBasedTerminal doble = new RegexBasedTerminal("doble", "[0-9]+\\.[0-9]+");

            NonTerminal S = new NonTerminal("S"),// ACEPTACIOM

                        E = new NonTerminal("E"),
                        T= new NonTerminal("T"),
                        F = new NonTerminal("F"),
                        G = new NonTerminal("G"),
                        H = new NonTerminal("H"),
                        I = new NonTerminal("I"),
                        J = new NonTerminal("J"),
                        CON = new NonTerminal("CON"),
                        DECLA = new NonTerminal("DECLA"),
                        FUN = new NonTerminal("FUN")
                        ;

            S.Rule =E;
            E.Rule  = DECLA
                    | T
                    ;
            T.Rule = T + "+" + F
                    | T + "-" + F
                    | F
                    ;

            F.Rule = F + "/" + G
                | F + "*" + G
                | G
                ;
            G.Rule = G + "^" + H
                | H
                ;
            H.Rule = ToTerm("-") + I
                    | I
                    ;
            I.Rule = id + "++"
                | id + "--"
                | J
                ;
            J.Rule = id
                    | numero
                    | FUN
                    |doble
                    |ToTerm("(") + T + ToTerm(")")
                    |CON
                    ;
            FUN.Rule = ToTerm("cos") + "(" + T + ")"
                | ToTerm("sin") + "(" + T + ")"
                | ToTerm("tan") + "(" + T + ")"
                ;
            CON.Rule = ToTerm("e")
                    | ToTerm("pi")
                    ;
            DECLA.Rule = "var" + id + "=" + T
                ;
            this.Root = S;

            MarkPunctuation("(",")");//<para quitar nodos basura

        }


    }
}
