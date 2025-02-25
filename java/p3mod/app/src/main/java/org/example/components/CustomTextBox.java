
package org.example.components;

import javax.swing.*;
import javax.swing.border.LineBorder;
import java.awt.*;
import java.awt.event.KeyEvent;
import java.awt.event.KeyAdapter;

public class CustomTextBox extends JTextField{

    private String mode = "both";               // Tipos de caracteres que admite el CustomTextBox (Por default admite ambos)
    private Color bordeInvalido = Color.RED;
    private Color bordeValido = Color.GRAY;

    public CustomTextBox(){
        /* Constructor cuando no se selecciona el modo (Se inicializa en default) */
        super(15);
    }

    public CustomTextBox(String mode){
        /* Construtor cuando se selecciona el modo */

        super(15);
        setMode(mode);
        inputEvents();
    }

    private void inputEvents(){

        addKeyListener(new KeyAdapter() {

            @Override
            public void keyTyped(KeyEvent event){
                char key = event.getKeyChar();
                
                if (validateKey(key)){
                    setBorder(new LineBorder(bordeValido, 1));
                }
                else{
                    setBorder(new LineBorder(bordeInvalido, 2));
                    event.consume();
                }
            }
        });
    }

private boolean validateKey(char key){

        if(mode.equals("digits")){
            if (Character.isDigit(key) || key == KeyEvent.VK_BACK_SPACE){
                return true;
            }
            else{
                return false;
            }
        }

        else if(mode.equals("chars")){
            if (Character.isLetter(key) || !Character.isLetterOrDigit(key) || key == KeyEvent.VK_BACK_SPACE){
                return true;
            }
            else{
                return false;
            }
        }

        else{
            return true;
        }
}

    private void setMode(String mode) {
        /* Metodo para verificar que se seleccione el parametro adecuado */
        if (!mode.equals("digits") && !mode.equals("chars")) {
            throw new IllegalArgumentException("CustomTextBox mode parameter must be: 'digits' or 'chars'");
        }
        this.mode = mode;
    }

}
