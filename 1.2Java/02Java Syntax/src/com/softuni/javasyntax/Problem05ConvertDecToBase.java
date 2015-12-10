package com.softuni.javasyntax;

import java.util.Scanner;

/**
 * To run this Class you need to press Ctrl+Alt+F10!!!
 */
public class Problem05ConvertDecToBase {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        System.out.print("Decimal: ");
        int dec  = input.nextInt();
        String base = Integer.toString(dec, 7);

        System.out.print("Base-7: ");
        System.out.println(base);
    }
}
