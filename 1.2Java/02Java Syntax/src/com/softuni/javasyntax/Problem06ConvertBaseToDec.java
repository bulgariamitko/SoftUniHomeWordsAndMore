package com.softuni.javasyntax;

import java.util.Scanner;

/**
 * To run this Class you need to press Ctrl+Alt+F10!!!
 */
public class Problem06ConvertBaseToDec {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        System.out.print("Base-7: ");
        int base = Integer.parseInt(input.nextLine(), 7);
        String dec = Integer.toString(base, 10);

        System.out.print("Base-7: ");
        System.out.println(dec);
    }
}