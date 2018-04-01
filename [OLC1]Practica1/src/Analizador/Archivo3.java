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


public class Archivo3{

	static Scanner sc = new Scanner(System.in);
	public static void main(String[] args){
            Archivo3 ar = new Archivo3();
		ar.TercerArchivo();

	}
	void TercerArchivo (){
		 int op = 0;
	while(op!=8){
		System.out.println("Seleccione una opcion");
	System.out.println("2. Crear Matriz");
	System.out.println("1. Mostrar Transpuesta");
	System.out.println("4. Sumar Matrices");
	System.out.println("3. Serie Fibonacci");
	System.out.println("8. Salir");
	op = sc.nextInt();
	switch(op) {
		case 2:
		System.out.println("Ingrese la cantidad de filas");
	 int filas = sc.nextInt();
	System.out.println("Ingrese la cantidad de columnas");
	 int col = sc.nextInt();
	 int [][] matriz = new int [filas][col];
	for(int i = 0; i < 5; i = i + (1) ){
		for(int j = 0; j < 5; j = j + (1) ){
		matriz[i][j] = i*2;

	}

	}
	System.out.println("Imprimir valores de las matrices");
	 String impresionMatriz = "";
	for(int i = 0; i < 5; i = i + (1) ){
		impresionMatriz = "";
	for(int j = 0; j < 5; j = j + (1) ){
		impresionMatriz = impresionMatriz + "[" + matriz[i][j];

	}
	System.out.println(impresionMatriz);

	}
	break;
		case 1:
		System.out.println("Ingrese la cantidad de filas");
	  filas = sc.nextInt();
	System.out.println("Ingrese la cantidad de columnas");
	  col = sc.nextInt();
	 matriz = new int [filas][col];
	for(int i = 0; i < 5; i = i + (1) ){
		for(int j = 0; j < 5; j = j + (1) ){
		matriz[i][j] = i*2;

	}

	}
	System.out.println("-----------VALORES MATRIZ-----------");
	  impresionMatriz = "";
	for(int i = 0; i < 5; i = i + (1) ){
		impresionMatriz = "";
	for(int j = 0; j < 5; j = j + (1) ){
		impresionMatriz = impresionMatriz + "[" + matriz[i][j];

	}
	System.out.println(impresionMatriz);

	}
	System.out.println("-----------VALORES TRANSPUESTA-----------");
	 String impresionMatrizT = "";
	for(int i = 0; i < 5; i = i + (1) ){
		impresionMatrizT = "";
	for(int j = 0; j < 5; j = j + (1) ){
		impresionMatrizT = impresionMatrizT + "[" + matriz[j][i];

	}
	System.out.println(impresionMatrizT);

	}
	break;
		case 4:
		System.out.println("Ingrese la cantidad de filas");
	 int filas1 = sc.nextInt();
	System.out.println("Ingrese la cantidad de columnas");
	 int col1 = sc.nextInt();
	 int [][] matriz1 = new int [filas1][col1];
	for(int i = 0; i < 5; i = i + (1) ){
		for(int j = 0; j < 5; j = j + (1) ){
		matriz1[i][j] = i*2;

	}

	}
	 int [][] matriz2 = new int [filas1][col1];
	for(int i = 0; i < 5; i = i + (1) ){
		for(int j = 0; j < 5; j = j + (1) ){
		matriz2[i][j] = i*j;

	}

	}
	System.out.println("----------MATRIZ1----------");
	 String impresionMatriz1 = "";
	for(int i = 0; i < 5; i = i + (1) ){
		impresionMatriz1 = "";
	for(int j = 0; j < 5; j = j + (1) ){
		impresionMatriz1 = impresionMatriz1 + "[" + matriz1[i][j];

	}
	System.out.println(impresionMatriz1);

	}
	System.out.println("----------MATRIZ2----------");
	System.out.println("Imprimir valores de las matrices");
	 String impresionMatriz2 = "";
	for(int i = 0; i < 5; i = i + (1) ){
		impresionMatriz2 = "";
	for(int j = 0; j < 5; j = j + (1) ){
		impresionMatriz2 = impresionMatriz2 + "[" + matriz2[i][j];

	}
	System.out.println(impresionMatriz2);

	}
	System.out.println("----------MATRIZ1 + MATRIZ2----------");
	for(int i = 0; i < 5; i = i + (1) ){
		impresionMatriz2 = "";
	for(int j = 0; j < 5; j = j + (1) ){
		impresionMatriz2 = impresionMatriz2 + "[" + matriz1[i][j]+matriz2[i][j];

	}
	System.out.println(impresionMatriz2);

	}
	break;
		case 3:
		System.out.println("Ingrese el numero limite de la serie");
	 int limit = sc.nextInt();
	System.out.println("La serie de " + limit + " es:");
	 String res = "";
	for(int i = 0; i < 8; i = i + (1) ){
		if(i==limit){
		res = res + serieFibonacci(i)+0;

	}
	else{
		res = res + serieFibonacci(i)+0;

	}

	}
	System.out.println(res);
	break;
	
	}

	}
	}
	int serieFibonacci (int n){
	 int res=0;
	if(n>1){
		return serieFibonacci(n-1)+serieFibonacci(n-2)+0;

	}
	else if(n==1 || n==0){
		res = n;

	}
	return res;

	}

}
