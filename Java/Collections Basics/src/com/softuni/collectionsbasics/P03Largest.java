package com.softuni.collectionsbasics;

import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;

/**
 * Run this class using Ctrl+Shift+F10
 */
public class P03Largest {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        String line = input.nextLine();
        String[] words = line.split(" ");
        LinkedHashMap<String, Integer> all = new LinkedHashMap<>();
        for (String string : words) {
            Integer count = all.get(string);
            if (count == null) {
                count = 0;
            }
            all.put(string, count + 1);
        }
        Map.Entry<String, Integer> max = null;
        for (Map.Entry<String, Integer> value : all.entrySet()) {
            if (max == null || value.getValue().compareTo(max.getValue()) > 0) {
                max = value;
            }
        }
        for (int i = 0; i < max.getValue(); i++) {
            System.out.print(max.getKey() + " ");
        }
    }
}
