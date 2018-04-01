/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Analizador;

/**
 *
 * @author piplo10
 */
import java.util.Scanner;


public class Archivo1{

	static Scanner sc = new Scanner(System.in);
	public static boolean Var_Boolean;
	private char Var_Char;
	static double Var_Double;
	public long Var_Long;
	static int Mi_nota = 100;
	public static void main(String[] args){
		SentenciaIf(500);
	SentenciaSwtich(2);
        TiposDeVariable();
        

	}
	public static void SentenciaSwtich (int nota){
		switch(nota) {
		case 1:
		System.out.println("Su numero ingresada es 1");
	break;
		case 2:
		System.out.println("Su numero ingresada es 2");
	break;
		case 3:
		System.out.println("Su numero ingresada es 3");
	break;
		default:
		System.out.println("ES OTRO NUMERO");

	}
	}
	public static void SentenciaIf (int nota){
		System.out.println("Sunota es " + nota);
	if(nota<=100 && nota>=0){
		if(nota<=100 && nota>=80){
		System.out.println("Gana con buena nota");

	}
	else if(nota<80 && nota>64){
		System.out.println("Gana");

	}
	else if(nota<65 && nota>60){
		System.out.println("Ufff, casi pierde, pero gana :D");

	}

	}
	else{
		System.out.println("La nota no es valida");

	}
	}
	static void TiposDeVariable (){
		Var_Boolean = 61<Mi_nota;
	if(Var_Boolean){
		System.out.println("Declaraciones  y Asignacion Correcta");

	}
	else{
		System.out.println("Declaraciones  y Asignacion Incorrecta");

	}
	}

}
