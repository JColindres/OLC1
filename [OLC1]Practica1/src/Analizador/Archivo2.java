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


public class Archivo2{

	static Scanner sc = new Scanner(System.in);
	public static void main(String[] args){
            Archivo2 ac = new Archivo2();
        ac.SentenciaCiclos();
        ac.hacerOperaciones();
        ac.Matrices();
        ac.Combinadas(5,2);

	}
	void SentenciaCiclos (){
            int opcion=0;
		while(opcion!=7){
		System.out.println("Seleccione una opcion");
	System.out.println("1. For incremental en 1");
	System.out.println("2. For incremental en 3");
	System.out.println("3. For decremental");
	System.out.println("4. While con condicion");
	System.out.println("5. While con break");
	System.out.println("6. Do while");
	System.out.println("7. Salir");
	 int opcion2 = sc.nextInt();
	switch(opcion2) {
		case 1:
		System.out.println("For incremental");
	for(int number = 0; number < 10; number = number + (1) ){
		System.out.println(number + " ");

	}
	break;
		case 2:
		System.out.println("For incremental en 3");
	for(int number = 0; number < 20; number = number + (3) ){
		System.out.println(number + " ");

	}
	break;
		case 3:
		System.out.println("For decremental");
	for(int number = 20; number < 0; number = number + (-1) ){
		System.out.println(number + " ");

	}
	break;
		case 4:
		System.out.println("While con condicion");
	System.out.println("Ingrese el limite final");
	 int fin = sc.nextInt();
	 int inicio = 0;
	while(inicio<=fin){
		System.out.println(inicio + " ");
	inicio = inicio+1;

	}
	break;
		case 5:
		System.out.println("while con break");
	while(true){
		System.out.println("ingrese un numero");
	 int num = sc.nextInt();
	if(num==10){
		break;
	
	}
	else{
		System.out.println(num);

	}

	}
	break;
		case 6:
		System.out.println("Do while");
	System.out.println("ingrese un numero");
	 int num = sc.nextInt();
	do{
		System.out.println(num + " ");
	num = num+1;
	} while(num>10);
	break;
		case 7:
		break;
		default:
		System.out.println("Opcion Incorrecta");

	}

	}
	}
	int sumar (int op1 , int op2){
	return op1+op2;

	}
	int multiplicar (int op1 , int op2){
	return op1*op2;

	}
	String concatenar (int valor){
	return "El resultado es " + valor;

	}
	void hacerOperaciones (){
		 int operando1,operando2;
            int o2=0;
	while(o2!=3){
		System.out.println("Seleccione una opcion");
	System.out.println("1. Sumar");
	System.out.println("2. Multiplicar");
	System.out.println("3. Salir");
	 int op = sc.nextInt();
	switch(op) {
		case 1:
		System.out.println("ingrese el primer operando");
	 int op1 = sc.nextInt();
	System.out.println("ingrese el segundo operando");
	 int op2 = sc.nextInt();
	 int resultado = sumar(op1,op2);
	 String cadena = concatenar(resultado);
	System.out.println(cadena);
	break;
		case 2:
		System.out.println("ingrese el primer operando");
	  op1 = sc.nextInt();
	System.out.println("ingrese el segundo operando");
	  op2 = sc.nextInt();
	  resultado = multiplicar(op1,op2);
	  cadena = concatenar(resultado);
	System.out.println(cadena);
	break;
		case 3:
		break;
		default:
		System.out.println("Opcion Incorrecta");

	}

	}
	}
	void Matrices (){
		 int [][] matriz = new int [5][5];
	for(int i = 0; i < 5; i = i + (1) ){
		for(int j = 0; j < 5; j = j + (1) ){
		matriz[i][j] = i*2;

	}

	}
	System.out.println("Imprimir valores de las matrices");
	for(int i = 0; i < 5; i = i + (1) ){
		for(int j = 0; j < 5; j = j + (1) ){
		System.out.println(matriz[i][j]);

	}

	}
	}
	private String Combinadas (int num1 , int num2){
	 double Resultado;
	Resultado = multiplicar(5,num2)/2+10-sumar(10,num2)*4+10.10;
	return "El resultado es: " + Resultado;

	}

}

