
package org.example.components;

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

/**
 * Clase que representa un botón personalizado con colores dinámicos y eventos de ratón.
 */
public class CustomButton extends JButton {

    /**
     * Color predeterminado del botón.
     */
    private Color defaultColor;

    /**
     * Color al que cambiará el botón cuando el mouse pase por encima.
     * Por defecto, es verde.
     */
    private Color newBackgroundColor = Color.GREEN;

    /**
     * Constructor de la clase CustomButton.
     *
     * @param text Texto que se mostrará en el botón.
     * @param defaultColor Color predeterminado del botón.
     */
    public CustomButton(String text, Color defaultColor) {
        super(text); // Llamar al constructor de la superclase JButton
        this.defaultColor = defaultColor;

        // Configurar propiedades y eventos del botón
        btnConfig();
    }

    /**
     * Constructor de la clase CustomButton con color personalizado al pasar el mouse.
     *
     * @param text Texto que se mostrará en el botón.
     * @param defaultColor Color predeterminado del botón.
     * @param newBackgroundColor Color al que cambiará el botón al pasar el mouse por encima.
     */
    public CustomButton(String text, Color defaultColor, Color newBackgroundColor) {
        super(text); // Llamar al constructor de la superclase JButton
        this.defaultColor = defaultColor;
        this.newBackgroundColor = newBackgroundColor;

        // Configurar propiedades y eventos del botón
        btnConfig();
    }

    /**
     * Configura el comportamiento del botón, incluyendo eventos de mouse.
     */
    private void btnConfig() {
        setOpaque(true);
        setContentAreaFilled(true);

        addMouseListener(new MouseAdapter() {
            @Override
            public void mouseEntered(MouseEvent event) {
                setBackground(newBackgroundColor);
            }

            @Override
            public void mouseExited(MouseEvent event) {
                setBackground(defaultColor);
            }

            @Override
            public void mouseClicked(MouseEvent event) {
                if (event.getClickCount() == 2) {
                    JOptionPane.showMessageDialog(
                        CustomButton.this,
                        "Diste doble click"
                    );
                }
            }
        });
    }
}
