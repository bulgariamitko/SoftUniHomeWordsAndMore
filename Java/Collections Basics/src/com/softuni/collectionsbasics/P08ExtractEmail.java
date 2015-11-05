package com.softuni.collectionsbasics;

import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * Run this class using Ctrl+Shift+F10
 */
public class P08ExtractEmail {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        String text = input.nextLine();
        Pattern wordPattern = Pattern.compile("[\\w.-_]*@\\w+[\\w.]*");

        Matcher wordMatcher = wordPattern.matcher(text.toLowerCase());
        while (wordMatcher.find()) {
            System.out.println(wordMatcher.group(0));
        }
    }
}
