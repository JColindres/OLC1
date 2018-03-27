/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package analizador;

import Analisis.Lexico;
import Analisis.Sintactico;
import java.io.BufferedReader;
import java.io.StringReader;
import java.util.ArrayList;

/**
 *
 * @author Jose2
 */

public class Analizador {

    /**
     * @param args the command line arguments
     */
    
    public static ArrayList<ErrorL> listaE=new ArrayList();
    
    public static void main(String[] args) throws Exception {
        // TODO code application logic here
        // \n es el salto de linea
        if(2+5>2*3&&4==4){
            System.out.println("hola mundo");
        }
        String entrada="if 2+5>2*3 Then     EndIF \nDim variable1 As integer = 1+2*4/5 \n";
        System.out.println("ENTRADA VB--------------------");
        System.out.println(entrada);
        System.out.println("SALIDA JAVA---------------------");
        Sintactico sin = new Sintactico(
        new Lexico(new BufferedReader(new StringReader(entrada))));
        sin.parse();
        if(!listaE.isEmpty()){
            ErrorL e=(ErrorL)listaE.get(0);
            System.out.println(e.tipo+" "+e.error);
        }
    }
    
}
