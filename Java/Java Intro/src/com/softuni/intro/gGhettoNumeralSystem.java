package com.softuni.intro;

import java.util.Scanner;

/**
 * ALT+SHIFT+F10 TO RUN THIS CLASS!
 */
public class gGhettoNumeralSystem {
    public static void main(String[] args) {
        Scanner Console = new Scanner(System.in);
        int input = Console.nextInt();
        String temp = Integer.toString(input);

        for (int i = 0; i < temp.length(); i++) {
            System.out.print(returnString(temp.charAt(i)));
        }

    }

    public static String returnString(Character getIt) {
        switch (getIt) {
            case '0': return "Gee";
            case '1': return "Bro";
            case '2': return "Zuz";
            case '3': return "Ma";
            case '4': return "Duh";
            case '5': return "Yo";
            case '6': return "Dis";
            case '7': return "Hood";
            case '8': return "Jam";
            case '9': return "Mack";
            default: return "invalid";
        }
    }
}
