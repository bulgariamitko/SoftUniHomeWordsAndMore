package com.softuni.javasyntax;

import java.util.Scanner;

/**
 * To run this Class you need to press Ctrl+Alt+F10!!!
 */
public class Problem03FormattingNumbers {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        System.out.print("a: ");
        int a = input.nextInt();
        System.out.print("b: ");
        float b = input.nextFloat();
        System.out.print("c: ");
        float c = input.nextFloat();

        String intAsHex = Integer.toHexString(a).toUpperCase();
        String intAsBinary = String.format("%10s", Integer.toBinaryString(a)).replace(' ', '0');

        System.out.format("|%-10s|%10s|%10.2f|%-10.3f|", intAsHex, intAsBinary, b, c);
    }
}
