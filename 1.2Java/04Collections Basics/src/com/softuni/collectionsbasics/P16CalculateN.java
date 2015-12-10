package com.softuni.collectionsbasics;

import java.util.Scanner;

/**
 * Run this class using Ctrl+Shift+F10
 */
public class P16CalculateN {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int num = scanner.nextInt();
        System.out.println(factorial(num));
    }

        public static int factorial(int n) {
            int fact = 1; // this  will be the result
            for (int i = 1; i <= n; i++) {
                fact *= i;
            }
            return fact;
        }
}
