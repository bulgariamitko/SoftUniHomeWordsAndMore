package com.softuni.javasyntax;

import java.util.Scanner;

/**
 * To run this Class you need to press Ctrl+Alt+F10!!!
 */
public class Problem13EvenOddEle {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String[] elements = scanner.nextLine().split(" ");

        int remainder = 0;

        String[] commandArguments = scanner.nextLine().split(" ");
        switch (commandArguments[2]) {
            case "odd":
                remainder = 1;
                break;
            case "even":
                remainder = 0;
                break;
        }

        int count = 0;
        int elementIndex = 0;

        while (count < Integer.parseInt(commandArguments[1]) && elementIndex < elements.length) {
            int number = Integer.parseInt(elements[elementIndex]);
            if (number % 2 == remainder) {
                System.out.print(number + " ");
                count++;
            }

            elementIndex++;
        }
    }
}
