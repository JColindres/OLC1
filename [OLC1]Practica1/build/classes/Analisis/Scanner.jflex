
package Analisis;
import java_cup.runtime.Symbol;
import java.util.LinkedList;
import java.util.ArrayList;

%%
%cupsym sym
%class Lexico
%cup
%public
%unicode
%line
%column
%char

//------------------------------------------------------------------------
//EXPRESIONES REGULARES
Comentario2 = "#" [^\r\n]* [^\r\n]
Comentario1 = "#/" [^/] ~"/#" | "#/" "/"+ "#"

entero =[0-9]+ 
decimal =[0-9]+ "."? [0-9]*
cadena =[\"] [^\"\n]* [\"\n]
letra =[a-zA-ZÑñ]+
iden ={letra}({letra}|{entero}|"_")*({letra}|{entero})*
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

    public ArrayList erroresL = new ArrayList();

    public static LinkedList<TError> TablaEL = new LinkedList<TError>();
%}

%%

//RESERVADAS
"Dim"            {return new Symbol(sym.dim,yycolumn,yyline,yytext());} 
"As"             {return new Symbol(sym.as,yycolumn,yyline,yytext());}  
"Integer"        {return new Symbol(sym.resInteger,yycolumn,yyline,yytext());}
"String"         {return new Symbol(sym.resString,yycolumn,yyline,yytext());}
"Module"         {return new Symbol(sym.module,yycolumn,yyline,yytext());}
"End"            {return new Symbol(sym.end,yycolumn,yyline,yytext());}
"Public"         {return new Symbol(sym.resPublic,yycolumn,yyline,yytext());}
"Private"        {return new Symbol(sym.resPrivate,yycolumn,yyline,yytext());}
"Static"         {return new Symbol(sym.resStatic,yycolumn,yyline,yytext());}
"Boolean"        {return new Symbol(sym.resBoolean,yycolumn,yyline,yytext());}
"Char"           {return new Symbol(sym.resChar,yycolumn,yyline,yytext());}
"Double"         {return new Symbol(sym.resDouble,yycolumn,yyline,yytext());}
"Long"           {return new Symbol(sym.resLong,yycolumn,yyline,yytext());}
"Console.WriteLine"   {return new Symbol(sym.cwl,yycolumn,yyline,yytext());}
"Console.ReadLine"    {return new Symbol(sym.crl,yycolumn,yyline,yytext());}
"Sub"            {return new Symbol(sym.sub,yycolumn,yyline,yytext());}
"If"             {return new Symbol(sym.resIf,yycolumn,yyline,yytext());}
"ElseIf"         {return new Symbol(sym.resElseIf,yycolumn,yyline,yytext());}
"Then"           {return new Symbol(sym.resThen,yycolumn,yyline,yytext());}
"Else"           {return new Symbol(sym.resElse,yycolumn,yyline,yytext());}
"While"          {return new Symbol(sym.resWhile,yycolumn,yyline,yytext());}
"For"            {return new Symbol(sym.resFor,yycolumn,yyline,yytext());}
"To"             {return new Symbol(sym.resTo,yycolumn,yyline,yytext());}
"Step"           {return new Symbol(sym.step,yycolumn,yyline,yytext());}
"Next"           {return new Symbol(sym.next,yycolumn,yyline,yytext());}
"Do"             {return new Symbol(sym.resDo,yycolumn,yyline,yytext());}
"Loop Until"     {return new Symbol(sym.loopUntil,yycolumn,yyline,yytext());}
"Select"         {return new Symbol(sym.select,yycolumn,yyline,yytext());}
"Case"           {return new Symbol(sym.resCase,yycolumn,yyline,yytext());}
"Exit"           {return new Symbol(sym.exit,yycolumn,yyline,yytext());}
"Main"           {return new Symbol(sym.main,yycolumn,yyline,yytext());}
"ByVal"          {return new Symbol(sym.byval,yycolumn,yyline,yytext());}
"Function"       {return new Symbol(sym.func,yycolumn,yyline,yytext());}
"Return"         {return new Symbol(sym.resReturn,yycolumn,yyline,yytext());}


//SIMBOLOS
"+"              {return new Symbol(sym.mas,yycolumn,yyline,yytext());}     
"-"              {return new Symbol(sym.menos,yycolumn,yyline,yytext());}     
"*"              {return new Symbol(sym.mul,yycolumn,yyline,yytext());}     
"/"              {return new Symbol(sym.div,yycolumn,yyline,yytext());} 

"<"              {return new Symbol(sym.menorq,yycolumn,yyline,yytext());}
"<="             {return new Symbol(sym.menorIgual,yycolumn,yyline,yytext());}
">"              {return new Symbol(sym.mayorq,yycolumn,yyline,yytext());}
">="             {return new Symbol(sym.mayorIgual,yycolumn,yyline,yytext());}
"<>"             {return new Symbol(sym.menorMayor,yycolumn,yyline,yytext());}
"="              {return new Symbol(sym.igual,yycolumn,yyline,yytext());} 
","              {return new Symbol(sym.coma,yycolumn,yyline,yytext());}  
"("              {return new Symbol(sym.parentesisA,yycolumn,yyline,yytext());}
")"              {return new Symbol(sym.parentesisC,yycolumn,yyline,yytext());}
"["              {return new Symbol(sym.corA,yycolumn,yyline,yytext());}
"]"              {return new Symbol(sym.corC,yycolumn,yyline,yytext());}

"And"            {return new Symbol(sym.and,yycolumn,yyline,yytext());}
"Or"             {return new Symbol(sym.or,yycolumn,yyline,yytext());}
"Not"            {return new Symbol(sym.not,yycolumn,yyline,yytext());}
"&"              {return new Symbol(sym.and2,yycolumn,yyline,yytext());}

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
[ \t\r\f\n]+     {/* Se ignoran */}


/* Cualquier Otro   ERROR LEXICO*/
.   {
	System.err.println("Error lexico: "+yytext()+ " Linea:"+(yyline+1)+" Columna:"+(yycolumn+1));
        TError datos = new TError(yytext(),yyline,yycolumn,"Error Lexico","simbolo no existe en el lenguaje");
	TablaEL.add(datos);

        erroresL.add("Error lexico: "+yytext()+ " Linea:"+(yyline+1)+" Columna:"+(yycolumn+1)+"\n");

	}



