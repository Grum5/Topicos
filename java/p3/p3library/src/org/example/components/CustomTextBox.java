
package org.example.components;

import javax.swing.*;
import javax.swing.border.LineBorder;
import java.awt.*;
import java.awt.event.KeyEvent;
import java.awt.event.KeyAdapter;

/**
 * CustomTextBox es un campo de texto personalizado con validación de entrada.
 * Puede configurarse para aceptar solo números, solo letras o ambos.
 */
public class CustomTextBox extends JTextField {

    /**
     * Modo de entrada permitido: "digits" (solo números), "chars" (solo letras) o "both" (ambos, por defecto).
     */
    private String mode = "both";

    /**
     * Color del borde cuando la entrada es inválida.
     */
    private Color bordeInvalido = Color.RED;

    /**
     * Color del borde cuando la entrada es válida.
     */
    private Color bordeValido = Color.GRAY;

    /**
     * Constructor por defecto. Inicializa el campo de texto con tamaño 15 y modo "both".
     */
    public CustomTextBox() {
        super(15);
    }

    /**
     * Constructor que permite seleccionar el modo de validación.
     *
     * @param mode Modo de entrada: "digits" (solo números) o "chars" (solo letras).
     * @throws IllegalArgumentException si el modo no es "digits" o "chars".
     */
    public CustomTextBox(String mode) {
        super(15);
        setMode(mode);
        inputEvents();
    }

    /**
     * Configura los eventos de entrada para validar el texto ingresado.
     */
    private void inputEvents() {
        addKeyListener(new KeyAdapter() {
            @Override
            public void keyTyped(KeyEvent event) {
                char key = event.getKeyChar();

                if (validateKey(key)) {
                    setBorder(new LineBorder(bordeValido, 1));
                } else {
                    setBorder(new LineBorder(bordeInvalido, 2));
                    event.consume(); // Bloquea la entrada inválida
                }
            }
        });
    }

    /**
     * Valida si el carácter ingresado es válido según el modo seleccionado.
     *
     * @param key Carácter ingresado.
     * @return true si la tecla es válida, false si debe bloquearse.
     */
    private boolean validateKey(char key) {
        if (mode.equals("digits")) {
            return Character.isDigit(key) || key == KeyEvent.VK_BACK_SPACE;
        } else if (mode.equals("chars")) {
            return Character.isLetter(key) || !Character.isLetterOrDigit(key) || key == KeyEvent.VK_BACK_SPACE;
        } else {
            return true; // Modo "both" permite cualquier carácter
        }
    }

    /**
     * Establece el modo de validación del campo de texto.
     *
     * @param mode Modo de entrada: "digits" (solo números) o "chars" (solo letras).
     * @throws IllegalArgumentException si el modo no es válido.
     */
    private void setMode(String mode) {
        if (!mode.equals("digits") && !mode.equals("chars")) {
            throw new IllegalArgumentException("CustomTextBox mode parameter must be: 'digits' or 'chars'");
        }
        this.mode = mode;
    }
}
