package com.softuni.collectionsbasics;

import java.util.Arrays;
import java.util.Scanner;
import java.util.stream.Stream;

/**
 * Run this class using Ctrl+Shift+F10
 */
public class P15Implement {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        Integer searchedNumber = scanner.nextInt();
        scanner.nextLine();
        int[] arrayOfNumbers = Stream.of(scanner.nextLine().split(" ")).mapToInt(Integer::parseInt).toArray();
        Arrays.sort(arrayOfNumbers);
        System.out.println(binerySearchImplemention(arrayOfNumbers, 0, arrayOfNumbers.length - 1, searchedNumber));
    }

    private static int binerySearchImplemention(int[] array, int first, int last, int searchValue) {
        if (last < first) {
            return -1;
        }
        int middle = (first + last) >> 1;
        if (array[middle] > searchValue) {
            return binerySearchImplemention(array, first, middle - 1, searchValue);
        } else if (array[middle] < searchValue) {
            return binerySearchImplemention(array, middle + 1, last, searchValue);
        } else {
            return middle;
        }
    }
}
