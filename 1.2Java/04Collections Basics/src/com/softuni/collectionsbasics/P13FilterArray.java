package com.softuni.collectionsbasics;

import java.util.*;
import java.util.stream.Collectors;

/**
 * Run this class using Ctrl+Shift+F10
 */
public class P13FilterArray {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        ArrayList<String> list = new ArrayList<>(Arrays.asList(input.nextLine().split(" ")));
        ArrayList<String> filter = new ArrayList<>(list.stream().filter(p -> p.length() > 3).collect(Collectors.toList()));
        if (filter.size() != 0) {
            for (String str : filter) {
                System.out.print(str + " ");
            }
        } else {
            System.out.println("(empty)");
        }
    }
}
