package com.softuni.javasyntax;

import java.util.*;

/**
 * To run this Class you need to press Ctrl+Alt+F10!!!
 */
public class Problem07RandomizeNums {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        System.out.print("N: ");
        int n = input.nextInt();
        System.out.print("M: ");
        int m = input.nextInt();

        ArrayList<Integer> list = new ArrayList<>();
        for (int i = Math.min(n, m); i <= Math.max(n, m); i++) {
            list.add(i);
        }

        Random randomNum = new Random();
        int count = list.size();
        while (count > 0) {
            int randomIndex = randomNum.nextInt(count);
            System.out.format("%d ", list.remove(randomIndex));
            count--;
        }
    }
}
