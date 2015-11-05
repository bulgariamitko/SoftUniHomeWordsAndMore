package com.softuni.collectionsbasics;

import java.util.Scanner;
import java.util.TreeMap;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * Run this class using Ctrl+Shift+F10
 */
public class P11MostFrequent {
    public static void main(String[] args) {
        TreeMap<String, Integer> strings = new TreeMap<>();
        Scanner input = new Scanner(System.in);
        String text = input.nextLine();
        Pattern pattern = Pattern.compile("[^a-z]*([a-z]+)[^a-z]+");
        Matcher wordExtractor = pattern.matcher(text.toLowerCase());

        while (wordExtractor.find()) {
            if (strings.containsKey(wordExtractor.group(1))) {
                strings.put(wordExtractor.group(1), strings.get(wordExtractor.group(1)) + 1);
            } else {
                strings.put(wordExtractor.group(1), 1);
            }
        }
        Integer maxLength = strings.values().stream().max(Integer::compare).get();

        for (String value : strings.keySet()) {
            if (strings.get(value) == maxLength) {
                System.out.printf("%s -> %d times%n" , value, maxLength);
            }
        }
    }
}
