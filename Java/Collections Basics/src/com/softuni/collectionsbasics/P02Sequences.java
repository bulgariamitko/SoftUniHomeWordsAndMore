package com.softuni.collectionsbasics;

import java.util.Scanner;

/**
 * Run this class using Ctrl+Shift+F10
 */
public class P02Sequences {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        String line = input.nextLine();
        String[] words = line.split(" ");
        System.out.print(words[0]);
        for (int i = 1; i < words.length; i++) {
            if (words[i].equals(words[i - 1])) {
                System.out.print(" " + words[i]);
            } else {
                System.out.println();
                System.out.print(words[i]);
            }

        }
    }
}
