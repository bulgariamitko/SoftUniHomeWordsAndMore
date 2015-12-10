package com.softuni.collectionsbasics;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * Run this class using Ctrl+Shift+F10
 */
public class Exam {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String line = scanner.nextLine();

        Pattern pattern = Pattern.compile("(double|int) ([a-z][a-zA-Z]*)");
        ArrayList<String> doubles = new ArrayList<>();
        ArrayList<String> ints = new ArrayList<>();

        while (!line.equals("//END_OF_CODE")) {
            Matcher matcher = pattern.matcher(line);
            while (matcher.find()) {
                String variable = matcher.group(1);
                String name = matcher.group(2);

                if (variable.equals("double")) {
                    doubles.add(name);
                } else {
                    ints.add(name);
                }
            }

            line = scanner.nextLine();
        }

        Collections.sort(doubles);
        Collections.sort(ints);

        System.out.printf("Doubles: %s\n", doubles.size() > 0 ? String.join(", ", doubles) : "None");
        System.out.printf("Ints: %s\n", ints.size() > 0 ? String.join(", ", ints) : "None");
    }
}
