/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ConexionServidor;

import Analisis.Lexico;
import Analisis.Sintactico;
import java.io.BufferedInputStream;
import java.io.BufferedOutputStream;
import java.io.BufferedReader;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileOutputStream;
import java.io.FileReader;
import java.io.StringReader;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.ArrayList;
//import compi1._proyecto1.ejempo;

/**
 *
 * @author Toshiba
 */
public class Servidor extends Thread {

    public static ArrayList nombres = new ArrayList<String>();

    Interfaz inter = new Interfaz();

    public void run() {

        ServerSocket server;
        Socket connection;

        BufferedInputStream bis;
        BufferedOutputStream bos;
        byte[] receivedData;
        int in;
        String file, mensajeRecibido, mensaje2;

        try {
            server = new ServerSocket(5000);
            while (true) {
                connection = server.accept();
                inter.jTextArea2.append("se ha conectado el cliente\n");
                receivedData = new byte[1024];

                bis = new BufferedInputStream(connection.getInputStream());
                DataInputStream dis = new DataInputStream(connection.getInputStream());

                mensaje2 = dis.readUTF();

                if (mensaje2.equals("archivo")) {
                    mensajeRecibido = dis.readUTF();

                    file = dis.readUTF();

                    file = file.substring(file.indexOf('\\') + 1, file.length());

                    if (mensajeRecibido.equals("1")) {
                        file = "Proyecto1\\" + file;
                    } else if (mensajeRecibido.equals("2")) {
                        file = "Proyecto2\\" + file;
                    }
                    nombres.add(file);

                    bos = new BufferedOutputStream(new FileOutputStream(file));
                    while ((in = bis.read(receivedData)) != -1) {
                        bos.write(receivedData, 0, in);
                    }
                    bos.close();
                    dis.close();
                    //inter.jTextArea2.append("se ha recivido un archivo\n");
                } else {

                    String path = "C:\\Users\\pablo\\Documents\\1er-Sem-2018\\OLC1\\[OLC1]Proyecto_Servidor\\Proyecto1";
                    String files, cadenatotal = "";
                    File folder = new File(path);
                    File[] listOfFiles = folder.listFiles();

                    for (int i = 0; i < listOfFiles.length; i++) {
                        if (listOfFiles[i].isFile()) {
                            files = listOfFiles[i].getName();
                            if (files.endsWith(".java") || files.endsWith(".JAVA")) {
                                cadenatotal = muestraContenido(path + "\\" + files);
                                String datos = cadenatotal;
                                Lexico lex = new Lexico(new BufferedReader(new StringReader(datos)));
                                Sintactico sin = new Sintactico(lex);
                                inter.errores(datos);
                                
                                try {
                                    sin.parse();
                                } catch (Exception e) {
                                }
                                System.out.println("finalizo");
                            }
                        }
                    }

                    String path2 = "C:\\Users\\pablo\\Documents\\1er-Sem-2018\\OLC1\\[OLC1]Proyecto_Servidor\\Proyecto2";
                    String files2, cadenatotal2 = "";
                    File folder2 = new File(path2);
                    File[] listOfFiles2 = folder2.listFiles();

                    for (int i = 0; i < listOfFiles2.length; i++) {
                        if (listOfFiles2[i].isFile()) {
                            files2 = listOfFiles2[i].getName();
                            if (files2.endsWith(".java") || files2.endsWith(".JAVA")) {
                                cadenatotal2 = muestraContenido(path2 + "\\" + files2);
                                String datos2 = cadenatotal2;
                                Lexico lex = new Lexico(new BufferedReader(new StringReader(datos2)));
                                Sintactico sin = new Sintactico(lex);
                                inter.errores(datos2);
                                
                                try {
                                    sin.parse();
                                } catch (Exception e) {
                                }
                            }
                        }
                    }
                    System.out.println("Fin");

                }
            }
        } catch (Exception e) {
            System.err.println(e);
        }

    }

    public String muestraContenido(String archivo) {
        String cadena, cadenatotal = " ";
        try {
            FileReader f = new FileReader(archivo);
            BufferedReader b = new BufferedReader(f);
            while ((cadena = b.readLine()) != null) {
                cadenatotal = cadenatotal + cadena + "\n";
            }
        } catch (Exception e) {
            System.err.println(e);
        }
        return (cadenatotal);
    }

}
