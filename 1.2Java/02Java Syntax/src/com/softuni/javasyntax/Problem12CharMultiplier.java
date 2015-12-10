package com.softuni.javasyntax;

import java.util.Scanner;

/**
 * To run this Class you need to press Ctrl+Alt+F10!!!
 */
public class Problem12CharMultiplier {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        String[] strings = input.nextLine().split(" ");

        Integer result = MultiplierString(strings[0], strings[1]);
        System.out.println(result);
    }

    public static Integer MultiplierString(String input1, String input2) {
        Integer total = 0;
        if (input1.length() == input2.length()) {
            for (int i = 0; i < input1.length(); i++) {
                total += input1.charAt(i) * input2.charAt(i);
            }
        } else if (input1.length() > input2.length()) {
            Integer index = input2.length();
            for (int i = 0; i < input2.length(); i++) {
                total += input1.charAt(i) * input2.charAt(i);
            }
            for (int j = index; j < input1.length(); j++) {
                total += input1.charAt(j);
            }
        } else if (input1.length() < input2.length()) {
            Integer index = input1.length();
            for (int i = 0; i < input1.length(); i++) {
                total += input1.charAt(i) * input2.charAt(i);
            }
            for (int j = index; j < input2.length(); j++) {
                total += input2.charAt(j);
            }
        }
        return total;
    }
}
