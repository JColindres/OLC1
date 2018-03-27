
package Analisis;
import java_cup.runtime.Symbol;
import analizador.*;
%%
%cupsym sym
%class Lexico
%cup
%public
%unicode
%line
%column
%char
%ignorecase

//------------------------------------------------------------------------
//EXPRESIONES REGULARES
Comentario2 = "#" [^\r\n]* [^\r\n]
Comentario1 = "#/" [^/] ~"/#" | "#/" "/"+ "#"

entero =[0-9]+ 
decimal =[0-9]+ "."? [0-9]*
cadena =[\"] [^\"\n]* [\"\n]
letra =[a-zA-ZÑñ]+
iden ={letra}({letra}|{entero}|"_")*
caracter="'"[^]"'"
bool=("verdadero"|"falso"|"1"|"0")



//-------------------------------------------------------------------------

%{
    //codigo de java
    String nombre;
    public void imprimir(String dato,String cadena){
    	//System.out.println(dato+" : "+cadena);
    }
    public void imprimir(String cadena){
    	//System.out.println(cadena+" soy reservada");
    }
%}

%%

//RESERVADAS
"Dim"              {return new Symbol(sym.dim,yycolumn,yyline,yytext());} 
"As"              {return new Symbol(sym.as,yycolumn,yyline,yytext());} 
"Integer"         {return new Symbol(sym.resInteger,yycolumn,yyline,yytext());}
"String"         {return new Symbol(sym.resString,yycolumn,yyline,yytext());}

"If"             {return new Symbol(sym.resIf,yycolumn,yyline,yytext());}
"Then"         {return new Symbol(sym.resThen,yycolumn,yyline,yytext());}
"EndIf"         {return new Symbol(sym.resEndIf,yycolumn,yyline,yytext());}
"\n"             {return new Symbol(sym.salto,yycolumn,yyline,yytext());}

">"              {return new Symbol(sym.mayor,yycolumn,yyline,yytext());}     
"<"              {return new Symbol(sym.menor,yycolumn,yyline,yytext());}     
"="              {return new Symbol(sym.igual,yycolumn,yyline,yytext());}  

//SIMBOLOS
"+"              {return new Symbol(sym.mas,yycolumn,yyline,yytext());}     
"-"              {return new Symbol(sym.menos,yycolumn,yyline,yytext());}     
"*"              {return new Symbol(sym.mul,yycolumn,yyline,yytext());}     
"/"              {return new Symbol(sym.div,yycolumn,yyline,yytext());}     
"%"              {return new Symbol(sym.mod,yycolumn,yyline,yytext());}     
"^"              {return new Symbol(sym.pot,yycolumn,yyline,yytext());}


";"              {return new Symbol(sym.puntoComa,yycolumn,yyline,yytext());}  
","              {return new Symbol(sym.coma,yycolumn,yyline,yytext());}  


{entero}         {return new Symbol(sym.entero,yycolumn,yyline,yytext());}
{decimal}        {return new Symbol(sym.decimal,yycolumn,yyline,yytext());}
{cadena}         {return new Symbol(sym.cadena,yycolumn,yyline,yytext());}
{bool}           {return new Symbol(sym.bool,yycolumn,yyline,yytext());}
{iden}           {return new Symbol(sym.iden,yycolumn,yyline,yytext());}
{caracter}       {return new Symbol(sym.caracter,yycolumn,yyline,yytext());}

/* COMENTARIOS */
{Comentario2}    { /* Se ignoran */}
{Comentario1}     { /* Se ignoran */}

/* BLANCOS */
[ \t\r\f]+     {/* Se ignoran */}


/* Cualquier Otro   ERROR LEXICO*/
.   {
        ErrorL e=new ErrorL("Error lexico",yytext(),yyline,yycolumn);
        Analizador.listaE.add(e);
	System.err.println("Error lexico: "+yytext()+ " Linea:"+(yyline+1)+" Columna:"+(yycolumn+1));
			}


