
package org.example;
import org.example.components.CustomButton;
import org.example.components.CustomTextBox;
import org.example.components.InputValidator;

import javax.swing.*;
import java.awt.*;

public class App{

    public static void main(String[] args){

        JFrame frame = new JFrame("Hola mundo");
        CustomButton btn = new CustomButton(
            "Botooon",
            Color.DARK_GRAY,
            Color.RED
        );
        CustomTextBox input = new CustomTextBox("chars");

        btn.setBounds(100, 100, 200, 50);
        input.setBounds(100, 200, 200, 25);

        frame.add(btn);
        frame.add(input);
        frame.setSize(400, 500);
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.setLayout(null);
        frame.setResizable(false);
        frame.setVisible(true);
    }
}
