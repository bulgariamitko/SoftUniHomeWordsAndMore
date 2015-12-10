package com.softuni.collectionsbasics;

import java.util.Scanner;

/**
 * Run this class using Ctrl+Shift+F10
 */
public class P07CountSubstrings {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        String text = input.nextLine();
        String searchedWord = input.nextLine();
        Integer wordCounter = 0;
        for (int i = 0; i < text.length() - searchedWord.length() + 1; i++) {
            String textSubstring = text.substring(i, i + searchedWord.length());
            if (textSubstring.toLowerCase().equals(searchedWord.toLowerCase())) {
                wordCounter++;
            }
        }
        System.out.println(wordCounter);
    }
}
