/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ConexionCliente;

import java.net.*;
import java.io.*;

/**
 *
 * @author pablo
 */
public class Cliente {
 
    private static String HOST = "localhost";
    private static int PUERTO = 2017;
 
    public static void main(String args[]) {
         
        Socket socket;
        DataOutputStream mensaje;
         
        try {
            //Creamos nuestro socket
            socket = new Socket(HOST, PUERTO);
     
            mensaje = new DataOutputStream(socket.getOutputStream());
 
            //Enviamos un mensaje
            mensaje.writeUTF("Hola soy un cliente!!");
 
            //Cerramos la conexión
            socket.close();
 
        } catch (UnknownHostException e) {
            System.out.println("El host no existe o no está activo.");
        } catch (IOException e) {
            System.out.println("Error de entrada/salida.");
        }
         
    }
}
