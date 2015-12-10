package com.softuni.intro;

import java.util.Scanner;

/**
 * ALT+SHIFT+F10 TO RUN THIS CLASS!
 */
public class fSumNumbers {
    public static void main(String[] args) {
        Scanner Console = new Scanner(System.in);
        int number = Console.nextInt();
        int sum = 0;

        for (int i = 1; i <= number; i++) {
            sum += i;
        }
        System.out.println(sum);
    }
}
