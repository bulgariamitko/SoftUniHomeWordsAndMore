package com.softuni.collectionsbasics;

import java.lang.reflect.Array;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;

/**
 * Run this class using Ctrl+Shift+F10
 */
public class P09Combine {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        String line1 = input.nextLine();
        String line2 = input.nextLine();
        ArrayList<Character> list1 = new ArrayList(Arrays.asList(line1.split(" ")));
        ArrayList<Character> list2 = new ArrayList(Arrays.asList(line2.split(" ")));
        for (int i = 0; i < list2.size(); i++) {
            if (!list1.contains(list2.get(i))) {
                list1.add(list2.get(i));
            }
        }
        for (int i = 0; i < list1.size(); i++) {
            System.out.print(list1.get(i) + " ");
        }
    }
}
