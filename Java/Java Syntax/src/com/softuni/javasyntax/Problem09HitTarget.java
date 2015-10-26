package com.softuni.javasyntax;

import java.util.Scanner;

/**
 * To run this Class you need to press Ctrl+Alt+F10!!!
 */
public class Problem09HitTarget {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        int target = input.nextInt();

        for (int i = 1; i < 21; i++) {
            for (int j = 1; j < 21; j++) {
                if (i + j == target) {
                    System.out.println(i + " + " + j + " = " + target);
                }
                if (i - j == target) {
                    System.out.println(i + " - " + j + " = " + target);
                }
            }
        }
    }
}
