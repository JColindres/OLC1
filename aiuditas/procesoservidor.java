/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package compi1._proyecto1;

import java.io.BufferedInputStream;
import java.io.BufferedOutputStream;
import java.io.BufferedReader;
import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.FileReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.StringReader;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.ArrayList;
//import compi1._proyecto1.ejempo;
/**
 *
 * @author Toshiba
 */
public class procesoservidor extends Thread {
    public String es="0";
   public static ArrayList<String> nombres = new ArrayList<String>();
   
   public static ArrayList<String> idclasesproy1 = new ArrayList<String>();
   public static ArrayList<String> idmetodosproy1 = new ArrayList<String>();
   public static ArrayList<String> idvariablesproy1 = new ArrayList<String>();
   public static ArrayList<String> tipovariableproy1 = new ArrayList<String>();
   public static ArrayList<String> parametodosproy1 = new ArrayList<String>();
   public static ArrayList<String> lineasmetodoproy1 = new ArrayList<String>();
   public static ArrayList<String> comentarioproy1 = new ArrayList<String>();
   
   public static ArrayList<String> idclasesproy_1 = new ArrayList<String>();
   public static ArrayList<String> idmetodosproy_1 = new ArrayList<String>();
   public static ArrayList<String> idvariablesproy_1 = new ArrayList<String>();
   public static ArrayList<String> tipovariableproy_1 = new ArrayList<String>();
   public static ArrayList<String> parametodosproy_1 = new ArrayList<String>();
   public static ArrayList<String> lineasmetodoproy_1 = new ArrayList<String>();
   public static ArrayList<String> comentarioproy_1 = new ArrayList<String>();
   
   public static ArrayList<String> clasesrepetidas = new ArrayList<String>();
   
   ejempo hhs =new ejempo("hola");
    public void run()

    {
                           
                        ServerSocket server;
                        Socket connection;
 
                        DataOutputStream output;
                        BufferedInputStream bis;
                        BufferedOutputStream bos;
                        BufferedReader entrada;
                        byte[] receivedData;
                        int in;
                        String file,mensajeRecibido,mensaje2;
 
                        try{
                            //Servidor Socket en el puerto 5000
                            server = new ServerSocket( 5000 );
                            while ( true ) {
                                //Aceptar conexiones
                                connection = server.accept();
                                //hhs.jTextArea2.append("se ha conectado el cliente\n");
                                //Buffer de 1024 bytes
                                receivedData = new byte[1024];
                                
                                
                                
                                bis = new BufferedInputStream(connection.getInputStream());
                                DataInputStream dis=new DataInputStream(connection.getInputStream());
                                
                                
                                mensaje2=dis.readUTF();
                                
                                if(mensaje2.equals("archivo")){
                                    mensajeRecibido = dis.readUTF();
                                
                                    //Recibimos el nombre del fichero
                                    file = dis.readUTF();
                                
                                    file = file.substring(file.indexOf('\\')+1,file.length());
                                
                                    if(mensajeRecibido.equals("1")){
                                        file="Proyecto1\\"+file;
                                    }else if(mensajeRecibido.equals("2")) {
                                        file="Proyecto2\\"+file;
                                    }
                                    nombres.add(file);
                                    
                                    //Para guardar fichero recibido                              
                                    bos = new BufferedOutputStream(new FileOutputStream(file));
                                    while ((in = bis.read(receivedData)) != -1){
                                        bos.write(receivedData,0,in);
                                    }
                                    bos.close();
                                    dis.close();
                                    hhs.jTextArea2.append("se ha recivido un archivo\n");
                                }else{
                                    
                                   String path = "C:\\Users\\Toshiba\\Documents\\NetBeansProjects\\[compi1]_proyecto1\\Proyecto1"; 
                                   String files,cadenatotal="";
                                   File folder = new File(path);
                                   File[] listOfFiles = folder.listFiles(); 

                                   for (int i = 0; i < listOfFiles.length; i++) {
                                        if (listOfFiles[i].isFile()) {
                                                files = listOfFiles[i].getName();
                                                if (files.endsWith(".java") || files.endsWith(".JAVA")){   
                                                       cadenatotal= muestraContenido(path+"\\"+files);
                                                         String datos = cadenatotal;
                                                         //System.out.println(datos);
                                                         Analizador_Lexico lexico= new Analizador_Lexico(new BufferedReader(new StringReader(datos)));
                                                         sintactico sintac = new sintactico(lexico);
        
                                                         try{
                                                               sintac.parse();  
                                                         }catch (Exception e){            
                                                         }
                                                         System.out.println("finalizo");
                                                }
                                        }
                                    }
                                   ///////////////////////
                                   
                                   
                                   ///////////////////////
                                   
                                   String path2 = "C:\\Users\\Toshiba\\Documents\\NetBeansProjects\\[compi1]_proyecto1\\Proyecto2"; 
                                   String files2,cadenatotal2="";
                                   File folder2 = new File(path2);
                                   File[] listOfFiles2 = folder2.listFiles(); 

                                   for (int i = 0; i < listOfFiles2.length; i++) {
                                        if (listOfFiles2[i].isFile()) {
                                                files2 = listOfFiles2[i].getName();
                                                if (files2.endsWith(".java") || files2.endsWith(".JAVA")){   
                                                       cadenatotal2= muestraContenido(path2+"\\"+files2);
                                                       String datos2= cadenatotal2;
                                                       Analizador_Lexico lexico= new Analizador_Lexico(new BufferedReader(new StringReader(datos2)));
                                                       sintactico sintac = new sintactico(lexico);
        
                                                        try{
                                                            sintac.parse();  
                                                        }catch (Exception e){            
                                                        }
                                                }
                                        }
                                    }
                                    System.out.println("Fin");
                                    
                                    
                                } 
                            }
                        }catch (Exception e ) {
                            System.err.println(e); 
                        }

    }
    
    public String  muestraContenido(String archivo){
        String cadena,cadenatotal=" ";
        try  {
            FileReader f = new FileReader(archivo);
            BufferedReader b = new BufferedReader(f);     
            while((cadena = b.readLine())!=null) {
                cadenatotal=cadenatotal+cadena+"\n";
            }
        }catch(Exception e){
            System.err.println(e);
        }
        return(cadenatotal);
    }
    
}
