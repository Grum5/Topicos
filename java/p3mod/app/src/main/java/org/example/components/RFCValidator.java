
package org.example.components;

public class RFCValidator {

    public static boolean isRFCvalid(String rfc){

        if (rfc == null || (rfc.length() != 12 && rfc.length() != 13)) {
            return false;
        }

        for (int index = 0; index < rfc.length(); index++){
            char key = rfc.charAt(index);

            if (index < 4){
                if (key < 'A' || key > 'Z') return false;
            }
            else if (index < 10){
                if (key < '0' || key > '9') return false;
            }
            else {
                if (!((key >= 'A' && key <= 'Z') || (key >= '0' && key <= '9'))) return false;
            }
        }

        return true;
        
    }

    public static String fixRFC(String rfc){
        
        if (rfc == null){
            return null;
        }

        rfc = rfc.trim().toUpperCase();

        if (isRFCvalid(rfc)){
            return rfc;
        }

        return null;
    }

}
