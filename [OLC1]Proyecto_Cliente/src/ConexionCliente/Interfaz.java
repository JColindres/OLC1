/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ConexionCliente;

import Analisis.Lexico;
import Analisis.Sintactico;
import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileWriter;
import java.io.IOException;
import java.io.StringReader;
import java.io.*;
import java.net.Socket;
import java.util.ArrayList;
import java.util.Scanner;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.JFileChooser;
import javax.swing.text.BadLocationException;
import javax.swing.tree.DefaultMutableTreeNode;
import javax.swing.tree.DefaultTreeModel;

/**
 *
 * @author piplo10
 */
public class Interfaz extends javax.swing.JFrame {

    DefaultTreeModel model;

    public Interfaz() {
        initComponents();
        model = (DefaultTreeModel) jTree1.getModel();
    }

    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        jTabbedPane1 = new javax.swing.JTabbedPane();
        jScrollPane1 = new javax.swing.JScrollPane();
        jTextArea1 = new javax.swing.JTextArea();
        jTabbedPane2 = new javax.swing.JTabbedPane();
        jScrollPane2 = new javax.swing.JScrollPane();
        jTextArea2 = new javax.swing.JTextArea();
        jTabbedPane3 = new javax.swing.JTabbedPane();
        jScrollPane3 = new javax.swing.JScrollPane();
        jTextArea3 = new javax.swing.JTextArea();
        Fila = new java.awt.Label();
        FilaVB = new java.awt.Label();
        FilaJava = new java.awt.Label();
        Fila1 = new java.awt.Label();
        jTabbedPane4 = new javax.swing.JTabbedPane();
        jScrollPane4 = new javax.swing.JScrollPane();
        jTextArea4 = new javax.swing.JTextArea();
        Fila2 = new java.awt.Label();
        ColumnaVB = new java.awt.Label();
        Fila3 = new java.awt.Label();
        ColumnaJava = new java.awt.Label();
        jScrollPane5 = new javax.swing.JScrollPane();
        jTree1 = new javax.swing.JTree();
        jMenuBar1 = new javax.swing.JMenuBar();
        jMenu1 = new javax.swing.JMenu();
        jMenuItem1 = new javax.swing.JMenuItem();
        jMenuItem2 = new javax.swing.JMenuItem();
        jMenuItem3 = new javax.swing.JMenuItem();
        jMenu4 = new javax.swing.JMenu();
        jMenuItem4 = new javax.swing.JMenuItem();
        jMenuItem5 = new javax.swing.JMenuItem();
        jMenu2 = new javax.swing.JMenu();
        jMenuItem6 = new javax.swing.JMenuItem();
        jMenuItem7 = new javax.swing.JMenuItem();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);

        jTextArea1.setColumns(20);
        jTextArea1.setRows(5);
        jTextArea1.addCaretListener(new javax.swing.event.CaretListener() {
            public void caretUpdate(javax.swing.event.CaretEvent evt) {
                jTextArea1CaretUpdate(evt);
            }
        });
        jScrollPane1.setViewportView(jTextArea1);

        jTabbedPane1.addTab("CPReport", jScrollPane1);

        jTextArea2.setColumns(20);
        jTextArea2.setRows(5);
        jTextArea2.addCaretListener(new javax.swing.event.CaretListener() {
            public void caretUpdate(javax.swing.event.CaretEvent evt) {
                jTextArea2CaretUpdate(evt);
            }
        });
        jScrollPane2.setViewportView(jTextArea2);

        jTabbedPane2.addTab("Consola", jScrollPane2);

        jTextArea3.setColumns(20);
        jTextArea3.setRows(5);
        jScrollPane3.setViewportView(jTextArea3);

        jTabbedPane3.addTab("Errores Sintacticos", jScrollPane3);

        Fila.setText("Fila:");

        FilaVB.setText("0");

        FilaJava.setText("0");

        Fila1.setText("Fila:");

        jTextArea4.setColumns(20);
        jTextArea4.setRows(5);
        jScrollPane4.setViewportView(jTextArea4);

        jTabbedPane4.addTab("Errores Lexicos", jScrollPane4);

        Fila2.setText("Columna:");

        ColumnaVB.setText("0");

        Fila3.setText("Columna:");

        ColumnaJava.setText("0");

        javax.swing.tree.DefaultMutableTreeNode treeNode1 = new javax.swing.tree.DefaultMutableTreeNode("Json");
        javax.swing.tree.DefaultMutableTreeNode treeNode2 = new javax.swing.tree.DefaultMutableTreeNode("score");
        javax.swing.tree.DefaultMutableTreeNode treeNode3 = new javax.swing.tree.DefaultMutableTreeNode("0");
        treeNode2.add(treeNode3);
        treeNode1.add(treeNode2);
        treeNode2 = new javax.swing.tree.DefaultMutableTreeNode("clases");
        treeNode3 = new javax.swing.tree.DefaultMutableTreeNode("clase1");
        treeNode2.add(treeNode3);
        treeNode1.add(treeNode2);
        treeNode2 = new javax.swing.tree.DefaultMutableTreeNode("metodos");
        treeNode3 = new javax.swing.tree.DefaultMutableTreeNode("metodo1");
        treeNode2.add(treeNode3);
        treeNode1.add(treeNode2);
        treeNode2 = new javax.swing.tree.DefaultMutableTreeNode("variables");
        treeNode3 = new javax.swing.tree.DefaultMutableTreeNode("variable1");
        treeNode2.add(treeNode3);
        treeNode1.add(treeNode2);
        treeNode2 = new javax.swing.tree.DefaultMutableTreeNode("comentarios");
        treeNode3 = new javax.swing.tree.DefaultMutableTreeNode("comentario");
        treeNode2.add(treeNode3);
        treeNode1.add(treeNode2);
        jTree1.setModel(new javax.swing.tree.DefaultTreeModel(treeNode1));
        jScrollPane5.setViewportView(jTree1);

        jMenu1.setText("Archivo");

        jMenuItem1.setLabel("Abrir");
        jMenuItem1.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jMenuItem1ActionPerformed(evt);
            }
        });
        jMenu1.add(jMenuItem1);

        jMenuItem2.setLabel("Guardar");
        jMenuItem2.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jMenuItem2ActionPerformed(evt);
            }
        });
        jMenu1.add(jMenuItem2);

        jMenuItem3.setLabel("Salir");
        jMenuItem3.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jMenuItem3ActionPerformed(evt);
            }
        });
        jMenu1.add(jMenuItem3);

        jMenuBar1.add(jMenu1);

        jMenu4.setText("Analisis");

        jMenuItem4.setText("Analizar Proyectos");
        jMenuItem4.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jMenuItem4ActionPerformed(evt);
            }
        });
        jMenu4.add(jMenuItem4);

        jMenuItem5.setText("Analizar");
        jMenuItem5.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jMenuItem5ActionPerformed(evt);
            }
        });
        jMenu4.add(jMenuItem5);

        jMenuBar1.add(jMenu4);

        jMenu2.setText("Reporte");

        jMenuItem6.setText("Arbol Json");
        jMenuItem6.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jMenuItem6ActionPerformed(evt);
            }
        });
        jMenu2.add(jMenuItem6);

        jMenuItem7.setText("html");
        jMenu2.add(jMenuItem7);

        jMenuBar1.add(jMenu2);

        setJMenuBar(jMenuBar1);

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(layout.createSequentialGroup()
                        .addContainerGap()
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                            .addComponent(jTabbedPane3)
                            .addComponent(jTabbedPane1, javax.swing.GroupLayout.DEFAULT_SIZE, 400, Short.MAX_VALUE)))
                    .addGroup(layout.createSequentialGroup()
                        .addGap(82, 82, 82)
                        .addComponent(Fila, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(FilaVB, javax.swing.GroupLayout.PREFERRED_SIZE, 38, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addGap(49, 49, 49)
                        .addComponent(Fila2, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(ColumnaVB, javax.swing.GroupLayout.PREFERRED_SIZE, 38, javax.swing.GroupLayout.PREFERRED_SIZE)))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                    .addComponent(jTabbedPane2, javax.swing.GroupLayout.DEFAULT_SIZE, 400, Short.MAX_VALUE)
                    .addComponent(jTabbedPane4)
                    .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                        .addComponent(Fila1, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(FilaJava, javax.swing.GroupLayout.PREFERRED_SIZE, 32, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addGap(50, 50, 50)
                        .addComponent(Fila3, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(ColumnaJava, javax.swing.GroupLayout.PREFERRED_SIZE, 38, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addGap(81, 81, 81))
                    .addComponent(jScrollPane5))
                .addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(layout.createSequentialGroup()
                        .addComponent(jTabbedPane1, javax.swing.GroupLayout.PREFERRED_SIZE, 400, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                    .addComponent(Fila, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                                    .addComponent(FilaVB, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                                .addComponent(Fila2, javax.swing.GroupLayout.Alignment.TRAILING, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                            .addComponent(ColumnaVB, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)))
                    .addGroup(layout.createSequentialGroup()
                        .addComponent(jTabbedPane2, javax.swing.GroupLayout.PREFERRED_SIZE, 196, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(Fila1, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addComponent(FilaJava, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addComponent(Fila3, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addComponent(ColumnaJava, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(jScrollPane5, javax.swing.GroupLayout.PREFERRED_SIZE, 184, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addGap(0, 0, Short.MAX_VALUE)))
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING)
                    .addComponent(jTabbedPane3, javax.swing.GroupLayout.PREFERRED_SIZE, 194, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(jTabbedPane4, javax.swing.GroupLayout.PREFERRED_SIZE, 194, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addContainerGap())
        );

        jTabbedPane2.getAccessibleContext().setAccessibleName("Java");
        FilaVB.getAccessibleContext().setAccessibleName("FilaVB");
        FilaJava.getAccessibleContext().setAccessibleName("FilaJava");

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private void jMenuItem1ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jMenuItem1ActionPerformed

        JFileChooser fc = new JFileChooser();
        StringBuilder sb = new StringBuilder();
        if (fc.showOpenDialog(null) == JFileChooser.APPROVE_OPTION) {

            File file = fc.getSelectedFile();
            try {
                Scanner input = new Scanner(file);

                while (input.hasNext()) {

                    sb.append(input.nextLine());
                    sb.append("\n");
                }
                input.close();

            } catch (FileNotFoundException ex) {
                Logger.getLogger(Interfaz.class.getName()).log(Level.SEVERE, null, ex);
            }
        } else {
            sb.append("No se selecciono ningun archivo");
        }
        jTextArea1.setText(sb.toString());
    }//GEN-LAST:event_jMenuItem1ActionPerformed

    private void jMenuItem4ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jMenuItem4ActionPerformed

        JFileChooser file = new JFileChooser();
        file.setDialogTitle("Seleccionar primer proyecto");
        file.showOpenDialog(this);

        File abre = file.getCurrentDirectory();
        System.out.println(abre);

        String path = String.valueOf(abre);

        String files;
        File folder = new File(path);
        File[] listOfFiles = folder.listFiles();

        for (int i = 0; i < listOfFiles.length; i++) {

            if (listOfFiles[i].isFile()) {
                files = listOfFiles[i].getName();
                if (files.endsWith(".java") || files.endsWith(".JAVA")) {
                    BufferedInputStream bis;
                    BufferedOutputStream bos;
                    int in;
                    byte[] byteArray;
                    final String filename = abre + "\\" + files;

                    try {
                        final File localFile = new File(filename);
                        Socket client = new Socket("localhost", 5000);

                        bis = new BufferedInputStream(new FileInputStream(localFile));
                        bos = new BufferedOutputStream(client.getOutputStream());

                        DataOutputStream dos = new DataOutputStream(client.getOutputStream());
                        dos.writeUTF("archivo");
                        dos.writeUTF("1");
                        dos.writeUTF(localFile.getName());
                        byteArray = new byte[8192];
                        while ((in = bis.read(byteArray)) != -1) {
                            bos.write(byteArray, 0, in);
                        }

                        bis.close();
                        bos.close();

                    } catch (Exception e) {
                        System.err.println(e);
                    }
                }
            }
        }
        System.out.println("Fin");

        JFileChooser file2 = new JFileChooser();
        file2.setDialogTitle("Seleccionar segundo proyecto");
        file2.showOpenDialog(this);

        File abre2 = file2.getCurrentDirectory();
        System.out.println(abre2);

        String path2 = String.valueOf(abre2);

        String files2;
        File folder2 = new File(path2);
        File[] listOfFiles2 = folder2.listFiles();

        for (int i = 0; i < listOfFiles2.length; i++) {

            if (listOfFiles2[i].isFile()) {
                files2 = listOfFiles2[i].getName();
                if (files2.endsWith(".java") || files2.endsWith(".JAVA")) {
                    BufferedInputStream bis;
                    BufferedOutputStream bos;
                    int in;
                    byte[] byteArray;
                    final String filename = abre2 + "\\" + files2;

                    try {
                        final File localFile = new File(filename);
                        Socket client = new Socket("localhost", 5000);

                        bis = new BufferedInputStream(new FileInputStream(localFile));
                        bos = new BufferedOutputStream(client.getOutputStream());

                        DataOutputStream dos = new DataOutputStream(client.getOutputStream());
                        dos.writeUTF("archivo");
                        dos.writeUTF("2");
                        dos.writeUTF(localFile.getName());
                        byteArray = new byte[8192];
                        while ((in = bis.read(byteArray)) != -1) {
                            bos.write(byteArray, 0, in);
                        }

                        bis.close();
                        bos.close();

                    } catch (Exception e) {
                        System.err.println(e);
                    }
                }
            }
        }
        System.out.println("Fin");

        BufferedOutputStream bos;

        try {

            Socket client = new Socket("localhost", 5000);

            bos = new BufferedOutputStream(client.getOutputStream());

            DataOutputStream dos = new DataOutputStream(client.getOutputStream());
            dos.writeUTF("leer");
            bos.close();
        } catch (Exception e) {
            System.err.println(e);
        }

    }//GEN-LAST:event_jMenuItem4ActionPerformed


    private void jMenuItem2ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jMenuItem2ActionPerformed

        final JFileChooser SaveAs = new JFileChooser();
        SaveAs.setApproveButtonText("Guardar");

        File fileName = new File(SaveAs.getSelectedFile() + ".cp");
        try {
            if (fileName == null) {
                return;
            }
            BufferedWriter outFile = new BufferedWriter(new FileWriter(fileName));
            outFile.write(jTextArea2.getText());

            outFile.close();
        } catch (IOException ex) {
        }
    }//GEN-LAST:event_jMenuItem2ActionPerformed

    private void jMenuItem3ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jMenuItem3ActionPerformed
        System.exit(0);
    }//GEN-LAST:event_jMenuItem3ActionPerformed

    private void jTextArea1CaretUpdate(javax.swing.event.CaretEvent evt) {//GEN-FIRST:event_jTextArea1CaretUpdate
        int pos = evt.getDot();
        try {
            int fila = jTextArea1.getLineOfOffset(pos) + 1;
            int columna = pos - jTextArea1.getLineStartOffset(fila - 1) + 1;
            FilaVB.setText(fila + "");
            ColumnaVB.setText(columna + "");
        } catch (BadLocationException ex) {
            Logger.getLogger(Interfaz.class.getName()).log(Level.SEVERE, null, ex);
        }
    }//GEN-LAST:event_jTextArea1CaretUpdate

    private void jTextArea2CaretUpdate(javax.swing.event.CaretEvent evt) {//GEN-FIRST:event_jTextArea2CaretUpdate
        int pos = evt.getDot();
        try {
            int fila = jTextArea2.getLineOfOffset(pos) + 1;
            int columna = pos - jTextArea2.getLineStartOffset(fila - 1) + 1;
            FilaJava.setText(fila + "");
            ColumnaJava.setText(columna + "");
        } catch (BadLocationException ex) {
            Logger.getLogger(Interfaz.class.getName()).log(Level.SEVERE, null, ex);
        }
    }//GEN-LAST:event_jTextArea2CaretUpdate

    private void jMenuItem5ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jMenuItem5ActionPerformed
        // TODO add your handling code here:

        String entrada = jTextArea1.getText();
        Lexico lex = new Lexico(new BufferedReader(new StringReader(entrada)));
        Sintactico sin = new Sintactico(lex);
        try {

            sin.parse();
            jTextArea2.setText("");
            jTextArea3.setText("");
            jTextArea4.setText("");
            for (int x = 0; x < sin.al.size(); x++) {
                jTextArea2.append((String) sin.al.get(x));
            }
            jTextArea3.setText("---------------Errores Sintacticos---------------\n\n");
            for (int x = 0; x < sin.erroresS.size(); x++) {
                jTextArea3.append((String) sin.erroresS.get(x) + "\n");
            }
            for (int x = 0; x < sin.erroresS1.size(); x++) {
                jTextArea3.append((String) sin.erroresS1.get(x) + "\n");
            }
            jTextArea4.setText("---------------Errores Lexicos-------------------\n\n");
            for (int x = 0; x < lex.erroresL.size(); x++) {
                jTextArea4.append((String) lex.erroresL.get(x));
            }
            jTextArea2.append("\n");
            jTextArea3.append("\n");
            jTextArea4.append("\n");

        } catch (Exception ex) {

            Logger.getLogger(Interfaz.class.getName()).log(Level.SEVERE, null, ex);

        }
    }//GEN-LAST:event_jMenuItem5ActionPerformed

    DefaultMutableTreeNode selectednode;
    private void jMenuItem6ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jMenuItem6ActionPerformed

        ArrayList ccc = new ArrayList();
        StringBuilder sb = new StringBuilder();
        String pathClases = "C:\\Users\\pablo\\Documents\\1er-Sem-2018\\OLC1\\[OLC1]Proyecto_Servidor\\clases.txt";
        File c = new File(pathClases);
        try {
            Scanner archivoClase = new Scanner(c);
            while (archivoClase.hasNext()) {

                sb.append(archivoClase.nextLine());
                sb.append("\n");
            }
            archivoClase.close();
            String clases = sb.toString();
            String[] partsClases = clases.split(",");
            for (int x = 1; x < partsClases.length; x++) {
                selectednode = (DefaultMutableTreeNode) jTree1.getLastSelectedPathComponent();
                if (selectednode != null) {
                    selectednode.insert(new DefaultMutableTreeNode(partsClases[x]), selectednode.getIndex(selectednode.getLastChild()));
                    System.out.println(sb);
                    System.out.println(partsClases[x]);
                }
            }

        } catch (FileNotFoundException ex) {
            Logger.getLogger(Interfaz.class.getName()).log(Level.SEVERE, null, ex);
        }
    }//GEN-LAST:event_jMenuItem6ActionPerformed

    /**
     * @param args the command line arguments
     */
    public static void main(String args[]) {
        /* Set the Nimbus look and feel */
        //<editor-fold defaultstate="collapsed" desc=" Look and feel setting code (optional) ">
        /* If Nimbus (introduced in Java SE 6) is not available, stay with the default look and feel.
         * For details see http://download.oracle.com/javase/tutorial/uiswing/lookandfeel/plaf.html 
         */
        try {
            for (javax.swing.UIManager.LookAndFeelInfo info : javax.swing.UIManager.getInstalledLookAndFeels()) {
                if ("Nimbus".equals(info.getName())) {
                    javax.swing.UIManager.setLookAndFeel(info.getClassName());
                    break;
                }
            }
        } catch (ClassNotFoundException ex) {
            java.util.logging.Logger.getLogger(Interfaz.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (InstantiationException ex) {
            java.util.logging.Logger.getLogger(Interfaz.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (IllegalAccessException ex) {
            java.util.logging.Logger.getLogger(Interfaz.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (javax.swing.UnsupportedLookAndFeelException ex) {
            java.util.logging.Logger.getLogger(Interfaz.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        }
        //</editor-fold>
        //</editor-fold>

        /* Create and display the form */
        java.awt.EventQueue.invokeLater(new Runnable() {
            public void run() {
                new Interfaz().setVisible(true);
            }
        });
    }


    // Variables declaration - do not modify//GEN-BEGIN:variables
    private java.awt.Label ColumnaJava;
    private java.awt.Label ColumnaVB;
    private java.awt.Label Fila;
    private java.awt.Label Fila1;
    private java.awt.Label Fila2;
    private java.awt.Label Fila3;
    private java.awt.Label FilaJava;
    private java.awt.Label FilaVB;
    private javax.swing.JMenu jMenu1;
    private javax.swing.JMenu jMenu2;
    private javax.swing.JMenu jMenu4;
    private javax.swing.JMenuBar jMenuBar1;
    private javax.swing.JMenuItem jMenuItem1;
    private javax.swing.JMenuItem jMenuItem2;
    private javax.swing.JMenuItem jMenuItem3;
    private javax.swing.JMenuItem jMenuItem4;
    private javax.swing.JMenuItem jMenuItem5;
    private javax.swing.JMenuItem jMenuItem6;
    private javax.swing.JMenuItem jMenuItem7;
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JScrollPane jScrollPane2;
    private javax.swing.JScrollPane jScrollPane3;
    private javax.swing.JScrollPane jScrollPane4;
    private javax.swing.JScrollPane jScrollPane5;
    private javax.swing.JTabbedPane jTabbedPane1;
    private javax.swing.JTabbedPane jTabbedPane2;
    private javax.swing.JTabbedPane jTabbedPane3;
    private javax.swing.JTabbedPane jTabbedPane4;
    private javax.swing.JTextArea jTextArea1;
    private javax.swing.JTextArea jTextArea2;
    private javax.swing.JTextArea jTextArea3;
    private javax.swing.JTextArea jTextArea4;
    private javax.swing.JTree jTree1;
    // End of variables declaration//GEN-END:variables
}
