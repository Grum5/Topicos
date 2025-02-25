
package org.example.components;

public class InputValidator{
    
    public static boolean onlyNumbers(String text){
        int size = text.length();
        for (int index = 0; index < size; index++){
            int asciiKey = (int) text.charAt(index);

            if (asciiKey < 48 || asciiKey > 57) return false;
        }
        return true;
    }

    public static boolean onlyLetters(String text){
        int size = text.length();
        for (int index = 0; index < size; index++){
            int asciiKey = (int) text.charAt(index);
            boolean validator = !((asciiKey >= 65 && asciiKey <= 90) || (asciiKey >= 97 && asciiKey <= 122));
            if ( validator )  return false;
        }
        return true;
    }

}
