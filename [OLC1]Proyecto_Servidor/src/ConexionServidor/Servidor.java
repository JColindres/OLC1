/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ConexionServidor;

import java.net.*;
import java.io.*;

/**
 *
 * @author pablo
 */
public class Servidor {
    private static int PUERTO = 2017;
 
    public static void main(String args[]) {
         
        BufferedReader entrada;
        DataOutputStream salida;
        Socket socket;
        ServerSocket serverSocket;
         
        try {
            serverSocket = new ServerSocket(PUERTO);
 
            System.out.println("Esperando una conexión...");
 
            socket = serverSocket.accept();
 
            System.out.println("Un cliente se ha conectado...");
 
            // Para los canales de entrada y salida de datos
 
            entrada = new BufferedReader(new InputStreamReader(
                    socket.getInputStream()));
 
            salida = new DataOutputStream(socket.getOutputStream());
 
            System.out.println("Confirmando conexion al cliente....");
 
            salida.writeUTF("Conexión exitosa...");
 
            // Para recibir el mensaje
 
            String mensajeRecibido = entrada.readLine();
 
            System.out.println(mensajeRecibido);
 
            salida.writeUTF("Se recibio tu mensaje.");
 
            salida.writeUTF("Gracias por conectarte.");
 
            System.out.println("Cerrando conexión...");
 
            // Cerrando la conexón
            serverSocket.close();
 
        } catch (IOException e) {
            System.out.println("Error de entrada/salida."  + e.getMessage());
        }
 
    }
}
