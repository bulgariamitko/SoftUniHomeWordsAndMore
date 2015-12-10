package com.softuni.javasyntax;

import java.util.Scanner;

/**
 * To run this Class you need to press Ctrl+Alt+F10!!!
 */
public class Problem04CalculateExpression {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        System.out.print("a: ");
        double a = input.nextDouble();
        System.out.print("b: ");
        double b = input.nextDouble();
        System.out.print("c: ");
        double c = input.nextDouble();

        double res1 = (a * a + b * b) / (a * a - b * b);
        double power = (a + b + c) / Math.sqrt(c);
        double result1 = Math.pow(res1, power);

        double res2 =  a * a + b * b - c * c * c;
        double power2 = a - b;
        double result2 = Math.pow(res2, power2);

        double diff = Math.abs((a + b + c) / 3 - (result1 + result2) / 2);

        System.out.printf("F1 result: %.2f; F2 result: %.2f; Diff: %.2f", result1, result2, diff);
    }
}
