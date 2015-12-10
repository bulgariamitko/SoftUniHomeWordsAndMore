package com.softuni.collectionsbasics;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.Scanner;
import java.util.stream.Collectors;

/**
 * Run this class using Ctrl+Shift+F10
 */
public class P14SortArr {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        ArrayList<String> list = new ArrayList<>(Arrays.asList(input.nextLine().split(" ")));
        String order = input.nextLine();
        if (order.equals("Ascending")) {
            list.stream().sorted().forEach(s -> System.out.print(s + " "));
        } else {
            Collections.reverse(list);
            list = new ArrayList<>(list.stream().sorted().collect(Collectors.toList()));
            Collections.reverse(list);
            list.forEach(s -> System.out.print(s + " "));
        }
    }
}
