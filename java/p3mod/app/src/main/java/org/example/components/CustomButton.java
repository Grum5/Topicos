
package org.example.components;

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

public class CustomButton extends JButton{
    /* 
        Clase personalizada de un boton
    */

    private Color defaultColor;                         // Color default del boton
    private Color newBackgroundColor = Color.GREEN;     // Color al que cambiara el boton

    public CustomButton(String text, Color defaultColor) {
        /* Contructor */

        // Llamar al construtor del padre
        super(text);
        this.defaultColor = defaultColor;

        btnConfig();
    }

    public CustomButton(String text, Color defaultColor, Color newBackgroundColor){
        /* Constructor para seleccionar el color al que se cambiara el newBackgroundColor */

        super(text);
        this.defaultColor = defaultColor;
        this.newBackgroundColor = newBackgroundColor;

        btnConfig();
    }

    private void btnConfig(){

        setOpaque(true);
        setContentAreaFilled(true);

        addMouseListener(new MouseAdapter() {

            @Override
            public void mouseEntered(MouseEvent event){
                setBackground(newBackgroundColor);
            }

            @Override
            public void mouseExited(MouseEvent event){
                setBackground(defaultColor);
            }

            @Override
            public void mouseClicked(MouseEvent event){
                if (event.getClickCount() == 2){
                    JOptionPane.showMessageDialog(
                        CustomButton.this,
                        "Diste doble click"
                    );
                }
            }
        });
    }

}

