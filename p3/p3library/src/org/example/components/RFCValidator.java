
package org.example.components;

/**
 * Clase de utilidad para la validación y corrección de RFCs en México.
 */
public class RFCValidator {

    /**
     * Verifica si un RFC es válido.
     * Un RFC válido debe cumplir con los siguientes criterios:
     * <ul>
     *     <li>Debe tener una longitud de 12 caracteres (personas físicas) o 13 caracteres (personas morales).</li>
     *     <li>Los primeros 4 caracteres deben ser letras mayúsculas (nombre o razón social).</li>
     *     <li>Los siguientes 6 caracteres deben ser números (fecha de nacimiento o constitución).</li>
     *     <li>Los últimos 2 o 3 caracteres pueden ser letras o números.</li>
     * </ul>
     *
     * @param rfc RFC a validar.
     * @return true si el RFC es válido, false en caso contrario.
     */
    public static boolean isRFCvalid(String rfc) {
        if (rfc == null || (rfc.length() != 12 && rfc.length() != 13)) {
            return false;
        }

        for (int index = 0; index < rfc.length(); index++) {
            char key = rfc.charAt(index);

            if (index < 4) {
                // Primeros 4 caracteres deben ser letras mayúsculas
                if (key < 'A' || key > 'Z') {
                    return false;
                }
            } else if (index < 10) {
                // Los siguientes 6 caracteres deben ser números
                if (key < '0' || key > '9') {
                    return false;
                }
            } else {
                // Últimos caracteres pueden ser letras o números
                if (!((key >= 'A' && key <= 'Z') || (key >= '0' && key <= '9'))) {
                    return false;
                }
            }
        }

        return true;
    }

    /**
     * Corrige el formato de un RFC dado:
     * <ul>
     *     <li>Elimina espacios en blanco antes y después del RFC.</li>
     *     <li>Convierte todas las letras a mayúsculas.</li>
     *     <li>Verifica si el RFC corregido es válido.</li>
     * </ul>
     *
     * @param rfc RFC a corregir.
     * @return RFC corregido si es válido, null en caso contrario.
     */
    public static String fixRFC(String rfc) {

        String newRFC = rfc;

        if (newRFC == null) {
            return null;
        }

        newRFC = newRFC.replace(" ","");
        newRFC = newRFC.toUpperCase();

        if (isRFCvalid(newRFC)) {
            return newRFC;
        }

        return null;
    }
}
