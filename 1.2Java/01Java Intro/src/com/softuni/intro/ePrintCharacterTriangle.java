package com.softuni.intro;

import java.util.Scanner;

/**
 * ALT+SHIFT+F10 TO RUN THIS CLASS!
 */
public class ePrintCharacterTriangle {
    public static void main(String[] args) {
        Scanner Console = new Scanner(System.in);
        int number = Console.nextInt();

        for (int i = 1; i <= number; i++) {
            for (int j = 0; j < i; j++) {
                System.out.print((char) (j + 97) + " ");
            }
            System.out.println();
        }
        for (int i = number - 1; i > 0; i--) {
            for (int j = 0; j < i; j++) {
                System.out.print((char) (j + 97) + " ");
            }
            System.out.println();
        }
    }
}
