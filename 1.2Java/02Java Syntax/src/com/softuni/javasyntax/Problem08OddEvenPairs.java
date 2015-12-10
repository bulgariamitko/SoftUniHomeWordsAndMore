package com.softuni.javasyntax;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

/**
 * To run this Class you need to press Ctrl+Alt+F10!!!
 */
public class Problem08OddEvenPairs {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        String[] values = input.nextLine().split(" ");

        if (values.length % 2 != 0) {
            System.out.println("Invalid length");
        } else {
            for (int i = 0; i < values.length; i += 2) {
                int num1 = Integer.parseInt(values[i]);
                int num2 = Integer.parseInt(values[i + 1]);

                boolean num1even = num1 % 2 == 0;
                boolean num2even = num2 % 2 == 0;

                System.out.print(num1 + ", " + num2 + " -> ");

                if (num1even == true && num2even == true) {
                    System.out.print("both are even");
                } else if (num1even != true && num2even != true) {
                    System.out.print("both are odd");
                } else {
                    System.out.print("different");
                }

                System.out.println();
            }
        }
    }
}
