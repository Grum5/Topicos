package org.example;

import org.example.components.CustomButton;
import org.example.components.CustomTextBox;
import org.example.components.InputValidator;
import org.example.components.RFCValidator;

import javax.swing.*;
import java.awt.*;

public class App{

    public static void InputTest(){

        // Usando dos cadenas de texto de prueba (Numbers)
        String numbers = "1234567890";
        String falseNumbers = "sad123";

        System.out.println("\n----------------------------------------------------------------------\n");
        System.out.println("Validador de digitos");
        System.out.println("String 1: " + numbers + " | " + InputValidator.onlyNumbers(numbers));
        System.out.println("String 2: " + falseNumbers + " | " + InputValidator.onlyNumbers(falseNumbers));

        // Usando dos cadenas de texto de prueba (Letters)
        String letters = "Holaaa";
        String falseLetters = "Holaa!#123";

        System.out.println("\n----------------------------------------------------------------------\n");
        System.out.println("Validador de letras");
        System.out.println("String 1: " + letters + " | " + InputValidator.onlyLetters(letters));
        System.out.println("String 2: " + falseLetters + " | " + InputValidator.onlyLetters(falseLetters));

        System.out.println("\n----------------------------------------------------------------------\n");

        
    }

    public static void RFCTest(){

        // Usando un RFC de prueba de 12 caracteres
        String rfc1 = "PEBJ001122FB";

        // Usando RFC de prueba de 13 caracteres
        String rfc2 = "PEBJ001122FBC";

        // Mostrando en pantalla el funcionamiento de los metodos de RFCValidator
        System.out.println("Validando 2 RFC");
        System.out.println("RFC 1: " + rfc1 + " | Valido: " + RFCValidator.isRFCvalid(rfc1));
        System.out.println("RFC 2: " + rfc2 + " | Valido: " + RFCValidator.isRFCvalid(rfc2));

        // Usando un RFC de prueba para corregir
        String rfc3 = " pebj991122 wgb";

        // Usando un RFC de prueba invalido para corregir
        String rfc4 = "1234pebj123oi";
        
        System.out.println("\n----------------------------------------------------------------------\n");
        System.out.println("Arreglando RFC, si se arregla el RFC y no es valido regresa 'null'");
        System.out.println("El RFC corregido es: " + rfc3 + " | Y al arreglarlo se obtuvo lo siguiente:  " + RFCValidator.fixRFC(rfc3));
        
        System.out.println("El RFC 4 corregido es: " + rfc4 + " | Y al arreglarlo se obtivo lo siguiente: " + RFCValidator.fixRFC(rfc4));
        System.out.println("\n----------------------------------------------------------------------\n");

    }


    public static void main(String[] args){

        InputTest();
        RFCTest();

        JFrame frame = new JFrame("Hola mundo");
      
        // Usando un boton personalizado
        CustomButton btn = new CustomButton(
            "Boton personalizado",
            Color.DARK_GRAY,
            Color.RED
        );

        // Usando un textbox personalzado que solo acepta letras
        CustomTextBox chars = new CustomTextBox("chars");

        // Usando un textbox personalzado que solo acepta digitos
        CustomTextBox digits = new CustomTextBox("digits");

        btn.setBounds(100, 100, 200, 50);
        chars.setBounds(100, 200, 200, 25);
        digits.setBounds(100, 300, 200, 25);

        frame.add(btn);
        frame.add(chars);
        frame.add(digits);
        frame.setSize(400, 500);
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.setLayout(null);
        frame.setResizable(false);
        frame.setVisible(true);
    }
}
