package com.softuni.javasyntax;

import java.util.Scanner;
/**
 * To run this Class you need to press Ctrl+Alt+F10!!!
 */
public class Problem01RectangleArea {

    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        int n1 = input.nextInt();
        int n2 = input.nextInt();
        System.out.println(area(n1, n2));
    }

    public static int area(int n1, int n2) {
        return n1 * n2;
    }
}
