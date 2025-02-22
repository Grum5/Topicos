/*
    Archivo de prueba para aprender Java y Swing
    - Todo el archivo fue generado con gradle
*/

package org.example;

import javax.swing.*;

public class App {

    public static void main(String[] args) {

        // Se crea un frame 
        JFrame main_frame = new JFrame("Mi primera ventana");
        main_frame.setSize(600, 600);
        main_frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        // Se crea un panel
        JPanel panel = new JPanel();

        // Se crea el boton
        JButton btn = new JButton("boton");

        // Se agrega el boton al panel
        panel.add(btn);

        // Se agrega el panel al frame
        main_frame.add(panel);

        // Se muestra el frame
        main_frame.setVisible(true);

    }
}
