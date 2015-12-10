package com.softuni.javasyntax;

import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * To run this Class you need to press Ctrl+Alt+F10!!!
 */
public class Problem10ExtractWords {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        String patternString = "[A-Za-z]+";

        Pattern pattern = Pattern.compile(patternString);
        Matcher matcher = pattern.matcher(input.nextLine());

        while (matcher.find()) {
            System.out.print(matcher.group() + " ");
        }
    }
}
