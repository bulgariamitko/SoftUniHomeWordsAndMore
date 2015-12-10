package com.softuni.intro;

import java.util.Scanner;

/**
 * ALT+SHIFT+F10 TO RUN THIS CLASS!
 */
public class kGetAverage {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        System.out.print("Enter n1: ");
        double n1 = input.nextDouble();
        System.out.print("Enter n2: ");
        double n2 = input.nextDouble();
        System.out.print("Enter n3: ");
        double n3 = input.nextDouble();

        average(n1, n2, n3);
    }

    public static void average(double n1, double n2, double n3) {
        double sum = n1 + n2 + n3;
        double resulat = sum / 3;
        System.out.println(String.format("%.2f", resulat));
    }
}
