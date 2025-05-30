
package org.example.components;

/**
 * Clase de utilidad para la validación de entradas de texto.
 */
public class InputValidator {

    /**
     * Verifica si un texto contiene solo números.
     *
     * @param text Texto a validar.
     * @return true si el texto contiene solo dígitos, false en caso contrario.
     */
    public static boolean onlyNumbers(String text) {
        int size = text.length();
        for (int index = 0; index < size; index++) {
            int asciiKey = (int) text.charAt(index);

            if (asciiKey < 48 || asciiKey > 57) {
                return false;
            }
        }
        return true;
    }

    /**
     * Verifica si un texto contiene solo letras.
     *
     * @param text Texto a validar.
     * @return true si el texto contiene solo letras, false en caso contrario.
     */
    public static boolean onlyLetters(String text) {
        int size = text.length();
        for (int index = 0; index < size; index++) {
            int asciiKey = (int) text.charAt(index);
            boolean validator = !((asciiKey >= 65 && asciiKey <= 90) || (asciiKey >= 97 && asciiKey <= 122));
            if (validator) {
                return false;
            }
        }
        return true;
    }
}
