package com.softuni.javasyntax;

import java.util.HashMap;
import java.util.Scanner;

/**
 * To run this Class you need to press Ctrl+Alt+F10!!!
 */
public class Problem14MagicWords {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        String[] lines = input.nextLine().split(" ");

        System.out.println(MagicWords(lines[0], lines[1]));
    }

    public static boolean MagicWords(String word1, String word2) {
        Boolean result = true;
        HashMap<Character, Character> unique = new HashMap<>();
        for (int i = 0; i < word1.length(); i++) {
            if (unique.containsKey(word1.charAt(i)) && !unique.containsValue(word2.charAt(i))) {
                result = false;
            } else {
                unique.put(word1.charAt(i), word2.charAt(i));
            }
        }
        return result;
    }
}
