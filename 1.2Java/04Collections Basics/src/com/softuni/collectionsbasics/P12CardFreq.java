package com.softuni.collectionsbasics;

import java.util.LinkedHashMap;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * Run this class using Ctrl+Shift+F10
 */
public class P12CardFreq {
    public static void main(String[] args) {
        LinkedHashMap<String, Integer> strings = new LinkedHashMap<>();
        Scanner input = new Scanner(System.in);
        String text = input.nextLine();
        Pattern pattern = Pattern.compile("(\\w+)");
        Matcher wordExtractor = pattern.matcher(text);
        Double matchCounter = 0.00;

        while (wordExtractor.find()) {
            matchCounter++;
            if (strings.containsKey(wordExtractor.group(1))) {
                strings.put(wordExtractor.group(1), strings.get(wordExtractor.group(1)) + 1);
            } else {
                strings.put(wordExtractor.group(1), 1);
            }
        }
        Integer maxLength = strings.values().stream().max(Integer::compare).get();

        for (String key : strings.keySet()) {
            System.out.printf("%s -> %.2f%%%n", key, (strings.get(key) / matchCounter) * 100.00);
        }
    }
}
