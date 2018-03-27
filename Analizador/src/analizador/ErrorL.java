/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package analizador;

/**
 *
 * @author Jose2
 */
public class ErrorL {
    String error;
    String tipo;
    int linea;
    int columna;
    
    public ErrorL(String tipo,String error,int linea,int columna){
        this.tipo=tipo;
        this.error=error;
        this.linea=linea;
        this.columna=columna;
    }
}
