package com.softuni.collectionsbasics;

import java.util.*;

/**
 * Run this class using Ctrl+Shift+F10
 */

public class P01SortArray {

    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        Integer howMuch = input.nextInt();

        ArrayList<Integer> nums = new ArrayList<>();
        for (int i = 0; i < howMuch; i++) {
            nums.add(input.nextInt());
        }

        Collections.sort(nums);

        for (int i = 0; i < nums.size(); i++) {
            System.out.print(nums.get(i) + " ");
        }
    }
}
