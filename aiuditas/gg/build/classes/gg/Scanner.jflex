package gg;
import java_cup.runtime.Symbol;

//------------------------------------------------------------------------

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
cimilla=[\"]*
palabras={letra}({letra})*
%state COMENTARIO
%state htmml
%state repor
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

//-------------------------------------------------------------------------

%%

//RESERVADAS
""          {return new Symbol(sym.noni,yycolumn,yyline,yytext());}
"Dim"           {return new Symbol(sym.dim,yycolumn,yyline,yytext());}
"As"            {return new Symbol(sym.as,yycolumn,yyline,yytext());} 
"Object"           {return new Symbol(sym.resObject,yycolumn,yyline,yytext());}
"int"           {return new Symbol(sym.resInteger,yycolumn,yyline,yytext());}
"String"        {return new Symbol(sym.resString,yycolumn,yyline,yytext());}
"Module"        {return new Symbol(sym.module,yycolumn,yyline,yytext());}
"End"           {return new Symbol(sym.end,yycolumn,yyline,yytext());}
"Public"        {return new Symbol(sym.resPublic,yycolumn,yyline,yytext());}
"Private"       {return new Symbol(sym.resPrivate,yycolumn,yyline,yytext());}
"Protected"     {return new Symbol(sym.resProtected,yycolumn,yyline,yytext());}
"final"         {return new Symbol(sym.resfinal,yycolumn,yyline,yytext());}
"Static"        {return new Symbol(sym.resStatic,yycolumn,yyline,yytext());}
"boolean"       {return new Symbol(sym.resBoolean,yycolumn,yyline,yytext());}
"char"          {return new Symbol(sym.resChar,yycolumn,yyline,yytext());}
"double"        {return new Symbol(sym.resDouble,yycolumn,yyline,yytext());}
"Long"          {return new Symbol(sym.resLong,yycolumn,yyline,yytext());}
"Console.WriteLine"   {return new Symbol(sym.cwl,yycolumn,yyline,yytext());}
"Sub"           {return new Symbol(sym.sub,yycolumn,yyline,yytext());}
"If"            {return new Symbol(sym.resIf,yycolumn,yyline,yytext());}
"Then"          {return new Symbol(sym.resThen,yycolumn,yyline,yytext());}
"Else"          {return new Symbol(sym.resElse,yycolumn,yyline,yytext());}
"While"         {return new Symbol(sym.resWhile,yycolumn,yyline,yytext());}
"For"           {return new Symbol(sym.resFor,yycolumn,yyline,yytext());}
"To"            {return new Symbol(sym.resTo,yycolumn,yyline,yytext());}
"Step"          {return new Symbol(sym.step,yycolumn,yyline,yytext());}
"Next"          {return new Symbol(sym.next,yycolumn,yyline,yytext());}
"Do"            {return new Symbol(sym.resDo,yycolumn,yyline,yytext());}
"Loop"          {return new Symbol(sym.loop,yycolumn,yyline,yytext());}
"Until"         {return new Symbol(sym.Until,yycolumn,yyline,yytext());}
"Select"        {return new Symbol(sym.select,yycolumn,yyline,yytext());}
"Case"          {return new Symbol(sym.resCase,yycolumn,yyline,yytext());}
"Exit"          {return new Symbol(sym.exit,yycolumn,yyline,yytext());}
"ID"            {return new Symbol(sym.iddd,yycolumn,yyline,yytext());}
"num"           {return new Symbol(sym.num,yycolumn,yyline,yytext());}
"multiplicar"   {return new Symbol(sym.mul2,yycolumn,yyline,yytext());}
"suma"          {return new Symbol(sym.mas2,yycolumn,yyline,yytext());}
"resta"         {return new Symbol(sym.menos2,yycolumn,yyline,yytext());}
"dividir"       {return new Symbol(sym.div2,yycolumn,yyline,yytext());}
"ByVal"         {return new Symbol(sym.byval,yycolumn,yyline,yytext());}
"return"        {return new Symbol(sym.retu,yycolumn,yyline,yytext());}
"main"          {return new Symbol(sym.main,yycolumn,yyline,yytext());}
"End If"        {return new Symbol(sym.resEndIf,yycolumn,yyline,yytext());}
"elseif"        {return new Symbol(sym.elseif,yycolumn,yyline,yytext());}
"End Module"    {return new Symbol(sym.endmodul,yycolumn,yyline,yytext());}
"End Sub"       {return new Symbol(sym.endsu,yycolumn,yyline,yytext());}
"Function"      {return new Symbol(sym.func,yycolumn,yyline,yytext());}
"End Function"  {return new Symbol(sym.endfunc,yycolumn,yyline,yytext());}
"Console.ReadLine"  {return new Symbol(sym.rwl,yycolumn,yyline,yytext());}
"import"        {return new Symbol(sym.importt,yycolumn,yyline,yytext());}
"class"         {return new Symbol(sym.clase,yycolumn,yyline,yytext());}
"void"          {return new Symbol(sym.voide,yycolumn,yyline,yytext());}
"new"           {return new Symbol(sym.neww,yycolumn,yyline,yytext());}
"break"        {return new Symbol(sym.resbreak,yycolumn,yyline,yytext());}
"switch"        {return new Symbol(sym.resswitch,yycolumn,yyline,yytext());}
"default"       {return new Symbol(sym.resdefault,yycolumn,yyline,yytext());}
"Clases"       {return new Symbol(sym.jclas,yycolumn,yyline,yytext());}
"Variables"       {return new Symbol(sym.jvara,yycolumn,yyline,yytext());}
"Metodos"       {return new Symbol(sym.jmeto,yycolumn,yyline,yytext());}
"Comentarios"       {return new Symbol(sym.jcome,yycolumn,yyline,yytext());}

//SIMBOLOS
"+"             {return new Symbol(sym.mas,yycolumn,yyline,yytext());}     
"-"             {return new Symbol(sym.menos,yycolumn,yyline,yytext());}     
"*"             {return new Symbol(sym.mul,yycolumn,yyline,yytext());}     
"/"             {return new Symbol(sym.div,yycolumn,yyline,yytext());}     
"%"             {return new Symbol(sym.mod,yycolumn,yyline,yytext());}     
"^"             {return new Symbol(sym.pot,yycolumn,yyline,yytext());}
"_"             {return new Symbol(sym.potb,yycolumn,yyline,yytext());}
"'"             {return new Symbol(sym.comina,yycolumn,yyline,yytext());}
"<"             {return new Symbol(sym.menorq,yycolumn,yyline,yytext());}
"<="            {return new Symbol(sym.menorIgual,yycolumn,yyline,yytext());}
">"             {return new Symbol(sym.mayorq,yycolumn,yyline,yytext());}
">="            {return new Symbol(sym.mayorIgual,yycolumn,yyline,yytext());}
"!="            {return new Symbol(sym.diferente,yycolumn,yyline,yytext());}
"=="            {return new Symbol(sym.igualigual,yycolumn,yyline,yytext());} 
"="             {return new Symbol(sym.igual,yycolumn,yyline,yytext());} 
";"             {return new Symbol(sym.puntoComa,yycolumn,yyline,yytext());}  
","             {return new Symbol(sym.coma,yycolumn,yyline,yytext());}  
"("             {return new Symbol(sym.parentesisA,yycolumn,yyline,yytext());}
")"             {return new Symbol(sym.parentesisC,yycolumn,yyline,yytext());}
"{"             {return new Symbol(sym.parentA,yycolumn,yyline,yytext());}
"}"             {return new Symbol(sym.parentC,yycolumn,yyline,yytext());}
":"             {return new Symbol(sym.dosp,yycolumn,yyline,yytext());}
"++"            {return new Symbol(sym.masmas,yycolumn,yyline,yytext());}
"--"            {return new Symbol(sym.menmen,yycolumn,yyline,yytext());}

"&&"            {return new Symbol(sym.andD,yycolumn,yyline,yytext());}
"||"            {return new Symbol(sym.orR,yycolumn,yyline,yytext());}
"!"             {return new Symbol(sym.not,yycolumn,yyline,yytext());}
"/*"		{yybegin(COMENTARIO);System.out.println("Aqui inicia el esado con /*");return new Symbol(sym.inic,yycolumn,yyline,yytext());}
"<html>"        {return new Symbol(sym.htmll,yycolumn,yyline,yytext());}



<COMENTARIO> {
[\n]		{System.out.println ("Una linea de comentario");}
"*"		{}
[^"*/"]         {}
"*/"		{yybegin(YYINITIAL);System.out.println ("Aqui Termina el comentario con */");}
}



"<head"        {return new Symbol(sym.head,yycolumn,yyline,yytext());}
"</head>"       {return new Symbol(sym.fhead,yycolumn,yyline,yytext());}
"<body"        {return new Symbol(sym.bodyy,yycolumn,yyline,yytext());}
"</body>"       {return new Symbol(sym.fbody,yycolumn,yyline,yytext());}
"<h1"          {return new Symbol(sym.h1,yycolumn,yyline,yytext());}
"</h1>"         {return new Symbol(sym.fh1,yycolumn,yyline,yytext());}
"<h2"          {return new Symbol(sym.h2,yycolumn,yyline,yytext());}
"</h2>"         {return new Symbol(sym.fh2,yycolumn,yyline,yytext());}
"<h3"          {return new Symbol(sym.h3,yycolumn,yyline,yytext());}
"</h3>"         {return new Symbol(sym.fh3,yycolumn,yyline,yytext());}
"<h4"          {return new Symbol(sym.h4,yycolumn,yyline,yytext());}
"</h4>"         {return new Symbol(sym.fh4,yycolumn,yyline,yytext());}
"<h5"          {return new Symbol(sym.h5,yycolumn,yyline,yytext());}
"</h5>"         {return new Symbol(sym.fh5,yycolumn,yyline,yytext());}
"<h6"          {return new Symbol(sym.h6,yycolumn,yyline,yytext());}
"</h6>"         {return new Symbol(sym.fh6,yycolumn,yyline,yytext());}
"<title"       {return new Symbol(sym.title,yycolumn,yyline,yytext());}
"</title>"      {return new Symbol(sym.ftitle,yycolumn,yyline,yytext());}
"<table"       {return new Symbol(sym.table,yycolumn,yyline,yytext());}
"</table>"      {return new Symbol(sym.ftable,yycolumn,yyline,yytext());}
"<th"          {return new Symbol(sym.th,yycolumn,yyline,yytext());}
"</th>"         {return new Symbol(sym.fth,yycolumn,yyline,yytext());}
"<td"          {return new Symbol(sym.td,yycolumn,yyline,yytext());}
"</td>"         {return new Symbol(sym.ftd,yycolumn,yyline,yytext());}
"<tr"          {return new Symbol(sym.tr,yycolumn,yyline,yytext());}
"</tr>"         {return new Symbol(sym.ftr,yycolumn,yyline,yytext());}
"<div"         {return new Symbol(sym.divh,yycolumn,yyline,yytext());}
"</div>"        {return new Symbol(sym.fdivh,yycolumn,yyline,yytext());}
"<p"           {return new Symbol(sym.p,yycolumn,yyline,yytext());}
"</p>"          {return new Symbol(sym.fp,yycolumn,yyline,yytext());}
"<br"          {return new Symbol(sym.br,yycolumn,yyline,yytext());}
"</br>"         {return new Symbol(sym.fbr,yycolumn,yyline,yytext());}
"<hr"          {return new Symbol(sym.hr,yycolumn,yyline,yytext());}
"</hr>"         {return new Symbol(sym.fhr,yycolumn,yyline,yytext());}
"<color"       {return new Symbol(sym.color,yycolumn,yyline,yytext());}
"="             {return new Symbol(sym.igualh,yycolumn,yyline,yytext());} 
"\""            {return new Symbol(sym.comih,yycolumn,yyline,yytext());} 
"<"             {return new Symbol(sym.menorqh,yycolumn,yyline,yytext());}
">"             {return new Symbol(sym.mayorqh,yycolumn,yyline,yytext());}
"rojo"          {return new Symbol(sym.rojo,yycolumn,yyline,yytext());}
"amarillo"      {return new Symbol(sym.amarillo,yycolumn,yyline,yytext());}
"azul"          {return new Symbol(sym.azul,yycolumn,yyline,yytext());}
"verde"         {return new Symbol(sym.verde,yycolumn,yyline,yytext());}
"gris"          {return new Symbol(sym.gris,yycolumn,yyline,yytext());}
"anaranjado"    {return new Symbol(sym.anaranjado,yycolumn,yyline,yytext());}
"morado"        {return new Symbol(sym.morado,yycolumn,yyline,yytext());}
"textcolor"     {return new Symbol(sym.textcolor,yycolumn,yyline,yytext());}
"align"         {return new Symbol(sym.align,yycolumn,yyline,yytext());}
"izquierda"     {return new Symbol(sym.izquierda,yycolumn,yyline,yytext());}
"derecha"       {return new Symbol(sym.derecha,yycolumn,yyline,yytext());}
"centrado"      {return new Symbol(sym.centrado,yycolumn,yyline,yytext());}
"font"          {return new Symbol(sym.font,yycolumn,yyline,yytext());}
"</html>"       {return new Symbol(sym.fhtml,yycolumn,yyline,yytext());}
"$$"            {System.out.println("Aqui inicia el esado con <report>");return new Symbol(sym.reportt ,yycolumn,yyline,yytext());}



"Print"         {return new Symbol(sym.prin,yycolumn,yyline,yytext());}
"result"        {return new Symbol(sym.resul,yycolumn,yyline,yytext());}
"score"        {return new Symbol(sym.scoree,yycolumn,yyline,yytext());}
"."             {return new Symbol(sym.puntor,yycolumn,yyline,yytext());}
";"             {return new Symbol(sym.puntoComar,yycolumn,yyline,yytext());}  
","             {return new Symbol(sym.comar,yycolumn,yyline,yytext());}  
"("             {return new Symbol(sym.parentesisAr,yycolumn,yyline,yytext());}
")"             {return new Symbol(sym.parentesisCr,yycolumn,yyline,yytext());}
"["             {return new Symbol(sym.llamaA,yycolumn,yyline,yytext());}
"]"             {return new Symbol(sym.llamaC,yycolumn,yyline,yytext());}

"$$"            {System.out.println("Aqui termina el esado con <report>");return new Symbol(sym.freportt ,yycolumn,yyline,yytext());}



{entero}        {return new Symbol(sym.entero,yycolumn,yyline,yytext());}
{decimal}       {return new Symbol(sym.decimal,yycolumn,yyline,yytext());}
{cadena}        {return new Symbol(sym.cadena,yycolumn,yyline,yytext());}
{bool}          {return new Symbol(sym.bool,yycolumn,yyline,yytext());}
{iden}          {return new Symbol(sym.iden,yycolumn,yyline,yytext());}
{caracter}      {return new Symbol(sym.caracter,yycolumn,yyline,yytext());}
{cimilla}       {return new Symbol(sym.comi,yycolumn,yyline,yytext());}
{palabras}      {return new Symbol(sym.palabra,yycolumn,yyline,yytext());}

/* COMENTARIOS */
{Comentario2}   { /* Se ignoran */}
{Comentario1}   { /* Se ignoran */}

/* BLANCOS */
[ \t\r\f\n]+    {/* Se ignoran */}


/* Cualquier Otro   ERROR LEXICO*/
.   {
	System.err.println("Error lexico: "+yytext()+ " Linea:"+(yyline+1)+" Columna:"+(yycolumn+1));
    }