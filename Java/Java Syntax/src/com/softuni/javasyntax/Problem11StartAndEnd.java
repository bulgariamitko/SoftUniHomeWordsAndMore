package com.softuni.javasyntax;

import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * To run this Class you need to press Ctrl+Alt+F10!!!
 */
public class Problem11StartAndEnd {
    public static void main(String[] args) {
        System.out.println("Enter your line: ");
        Scanner scanner = new Scanner(System.in);
        String line = scanner.nextLine();
        Pattern regex = Pattern.compile("\\b[A-Z][a-zA-Z]*[A-Z]\\b|\\b[A-Z]\\b");
        Matcher match = regex.matcher(line);

        while (match.find()){
            System.out.print(match.group(0) + " ");
        }
    }
}
