package com.softuni.javasyntax;

import java.util.Scanner;

/**
 * To run this Class you need to press Ctrl+Alt+F10!!!
 */
public class Problem02TriangleArea {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        System.out.println("Enter three points for a triangle (x and y intercept):");
        int side1x  = input.nextInt();
        int side1y  = input.nextInt();
        int side2x  = input.nextInt();
        int side2y  = input.nextInt();
        int side3x  = input.nextInt();
        int side3y  = input.nextInt();

        System.out.println(area(side1x, side1y, side2x, side2y, side3x, side3y));

    }

    public static int area(int ax, int ay, int bx, int by, int cx, int cy) {
        int area = (ax*(by-cy) + bx*(cy-ay) + cx*(ay-by))/2;
        if (area < 0) {
            return area * -1;
        } else {
            return area;
        }
    }

}
