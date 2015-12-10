package com.softuni.collectionsbasics;

import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * Run this class using Ctrl+Shift+F10
 */
public class P10ExtractAll {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        Pattern wordPattern =  Pattern.compile("\\b\\w+\\b");
        String textInput = scanner.nextLine();
        Matcher wordMatcher = wordPattern.matcher(textInput);
        HashSet<String> uniqueWords = new HashSet<>();

        while(wordMatcher.find()){
            uniqueWords.add(wordMatcher.group().toLowerCase());
        }
        ArrayList<String> uniqueList = new ArrayList<>(uniqueWords);
        Collections.sort(uniqueList,String.CASE_INSENSITIVE_ORDER);
        uniqueList.forEach(s -> System.out.print(s + " "));
    }
}