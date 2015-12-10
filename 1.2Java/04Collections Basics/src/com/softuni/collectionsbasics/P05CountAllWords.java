package com.softuni.collectionsbasics;

import java.util.Scanner;

/**
 * Run this class using Ctrl+Shift+F10
 */
public class P05CountAllWords {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        String text = input.nextLine();
        String[] words = text.split("\\w+");
        System.out.println(words.length - 1);
    }
}
