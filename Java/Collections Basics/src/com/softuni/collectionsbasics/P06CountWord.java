package com.softuni.collectionsbasics;

import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * Run this class using Ctrl+Shift+F10
 */
public class P06CountWord {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        String text = input.nextLine();
        String searchedWord = input.nextLine();
        Pattern wordPattern = Pattern.compile("[^a-z]*" + searchedWord.toLowerCase() + "+[^a-z]+");

        Matcher wordMatcher = wordPattern.matcher(text.toLowerCase());
        Integer wordCounter = 0;
        while (wordMatcher.find()) {
            wordCounter++;
        }
        System.out.println(wordCounter);
    }
}
